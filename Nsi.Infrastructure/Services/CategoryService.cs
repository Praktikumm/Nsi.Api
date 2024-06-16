using Nsi.Application.Common.Dto.Category;
using Nsi.Application.Common.Exceptions;
using Nsi.Application.Common.Interfaces;
using Nsi.Domain.Entities;

namespace Nsi.Infrastructure.Services;

public class CategoryService : ICategoryService
{
    private readonly INsiDbContext _dbContext;

    public CategoryService(INsiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _dbContext.Categories.FindAsync(id);
        if (category == null) throw new NotFoundException("Category not found");

        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Guid> CreateAsync(CreateCategoryDto category, ApplicationUser user, CancellationToken cancellationToken)
    {
        var guid = Guid.NewGuid();
        var newCategory = new Category
        {
            Id = guid,
            Title = category.Title,
            Content = category.Content,
            User = user
        };

        _dbContext.Categories.Add(newCategory);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return newCategory.Id;
    }

    public async Task<Category?> GetCategoryById(Guid id)
    {
        return await _dbContext.Categories.FindAsync(id);
    } 
}