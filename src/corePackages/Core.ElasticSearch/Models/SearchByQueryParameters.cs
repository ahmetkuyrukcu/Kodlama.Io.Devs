namespace Core.ElasticSearch.Models;

public class SearchByQueryParameters : SearchParameters
{
    public string QueryName { get; set; }

    public string Query { get; set; }

    public IEnumerable<string> Fields { get; set; }
}