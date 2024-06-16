using Nsi.Application.Common.Dto.Category;
using Riok.Mapperly.Abstractions;

namespace Nsi.Application.Common.Mappers;

[Mapper]
public static partial class CategoryMapper
{
    public static CategoryDetailsDto MapToCategoryDetailsDto(this Domain.Entities.Category category)
    {
        return new CategoryDetailsDto(category.Title, category.Content, category.Id);
    }
}