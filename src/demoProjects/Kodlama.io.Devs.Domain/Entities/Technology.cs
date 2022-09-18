using Core.Persistence.Repositories;

namespace Kodlama.Io.Devs.Domain.Entities;

public class Technology : Entity
{
    public string Name { get; set; }

    public Guid ProgrammingLanguageId { get; set; }

    public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }

    public Technology()
    {
    }

    public Technology(Guid id, string name) : base(id)
    {
        Name = name;
    }
}