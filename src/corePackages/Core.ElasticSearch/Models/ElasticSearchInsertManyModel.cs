namespace Core.ElasticSearch.Models;

public class ElasticSearchInsertManyModel : ElasticSearchModel
{
    public IEnumerable<object> Items { get; set; }
}