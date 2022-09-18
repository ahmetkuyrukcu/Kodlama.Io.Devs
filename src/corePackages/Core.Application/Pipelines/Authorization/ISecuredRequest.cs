namespace Core.Application.Pipelines.Authorization;

public interface ISecuredRequest
{
    public IEnumerable<string> Roles { get; }
}