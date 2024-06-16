using Microsoft.EntityFrameworkCore;
using Nsi.Domain.Entities;

namespace Nsi.Application.Common.Interfaces;

public interface INsiDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    DbSet<Domain.Entities.Category> Categories { get; }

    DbSet<ApplicationUser> Users { get; }
}