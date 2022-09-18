using System.Linq.Dynamic.Core;
using System.Text;

namespace Core.Persistence.Dynamic;

public static class IQueryableDynamicFilterExtensions
{
    private static readonly IDictionary<string, string> Operators = new Dictionary<string, string>
    {
        { "eq", "=" },
        { "neq", "!=" },
        { "lt", "<" },
        { "lte", "<=" },
        { "gt", ">" },
        { "gte", ">=" },
        { "isnull", "== null" },
        { "isnotnull", "!= null" },
        { "startswith", "StartsWith" },
        { "endswith", "EndsWith" },
        { "contains", "Contains" },
        { "doesnotcontain", "Contains" },
    };

    public static IQueryable<T> ToDynamic<T>(this IQueryable<T> query, Dynamic dynamic)
    {
        if (dynamic.Filter != null)
        {
            query = Filter(query, dynamic.Filter);
        }

        if (dynamic.Sort != null && dynamic.Sort.Any())
        {
            query = Sort(query, dynamic.Sort);
        }

        return query;
    }

    public static IList<Filter> GetAllFilters(Filter filter)
    {
        List<Filter> filters = new();
        GetFilters(filter, filters);

        return filters;
    }

    public static string Transform(Filter filter, IList<Filter> filters)
    {
        int index = filters.IndexOf(filter);
        string comparison = Operators[filter.Operator];
        StringBuilder where = new();

        if (!string.IsNullOrEmpty(filter.Value))
        {
            if (filter.Operator == "doesnotcontain")
            {
                where.Append($"(!np({filter.Field}).{comparison}(@{index}))");
            }
            else if (comparison is "StartsWith" or "EndsWith" or "Contains")
            {
                where.Append($"(np({filter.Field}).{comparison}(@{index}))");
            }
            else
            {
                where.Append($"np({filter.Field}) {comparison} @{index}");
            }
        }
        else if (filter.Operator is "isnull" or "isnotnull")
        {
            where.Append($"np({filter.Field}) {comparison}");
        }

        if (filter.Logic is not null && filter.Filters is not null && filter.Filters.Any())
        {
            return $"{where} {filter.Logic} ({string.Join($" {filter.Logic} ", filter.Filters.Select(f => Transform(f, filters)).ToArray())})";
        }

        return where.ToString();
    }

    private static void GetFilters(Filter filter, ICollection<Filter> filters)
    {
        filters.Add(filter);

        if (filter.Filters == null || !filter.Filters.Any())
        {
            return;
        }

        foreach (var item in filter.Filters)
        {
            GetFilters(item, filters);
        }
    }

    private static IQueryable<T> Filter<T>(IQueryable<T> queryable, Filter filter)
    {
        IList<Filter> filters = GetAllFilters(filter);
        object[] values = filters.Select(f => f.Value).ToArray();
        string where = Transform(filter, filters);
        queryable = queryable.Where(where, values);

        return queryable;
    }

    private static IQueryable<T> Sort<T>(IQueryable<T> queryable, IEnumerable<Sort> sort)
    {
        IEnumerable<Sort> sortList = sort.ToList();

        if (sortList.Any())
        {
            string ordering = string.Join(",", sortList.Select(s => $"{s.Field} {s.Dir}"));

            return queryable.OrderBy(ordering);
        }

        return queryable;
    }
}