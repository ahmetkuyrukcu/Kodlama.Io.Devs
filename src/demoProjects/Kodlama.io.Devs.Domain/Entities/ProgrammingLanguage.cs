﻿using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities;

public class ProgrammingLanguage : Entity
{
    public string Name { get; set; }

    public ProgrammingLanguage()
    {
    }

    public ProgrammingLanguage(Guid id, string name) : base(id)
    {
        Name = name;
    }
}