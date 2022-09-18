using Core.Persistence.Repositories;

namespace Kodlama.Io.Devs.Domain.Entities;

public class ProgrammingLanguage : Entity
{
    public string Name { get; set; }

    public virtual ICollection<Technology> Technologies { get; set; }

    public ProgrammingLanguage()
    {
    }

    public ProgrammingLanguage(Guid id, string name) : base(id)
    {
        Name = name;
    }
}