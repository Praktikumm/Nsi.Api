using Nsi.Application.Common.Dto.Category;
using Nsi.Domain.Entities;

namespace Nsi.Application.Common.Interfaces;

public interface ICategoryService
{
    Task<Guid> CreateAsync(CreateCategoryDto category, ApplicationUser user, CancellationToken cancellationToken);

    Task<Domain.Entities.Category?> GetCategoryById(Guid id);
    
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}