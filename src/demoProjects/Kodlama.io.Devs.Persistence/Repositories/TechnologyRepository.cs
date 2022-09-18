using Core.Persistence.Repositories;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using Kodlama.Io.Devs.Persistence.Contexts;

namespace Kodlama.Io.Devs.Persistence.Repositories;

public class TechnologyRepository : EfRepositoryBase<Technology, BaseDbContext>, ITechnologyRepository
{
    public TechnologyRepository(BaseDbContext context) : base(context)
    {
    }
}