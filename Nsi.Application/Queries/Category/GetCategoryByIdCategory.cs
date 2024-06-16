using MediatR;
using Nsi.Application.Common.Dto.Category;
using Nsi.Application.Common.Exceptions;
using Nsi.Application.Common.Interfaces;
using Nsi.Application.Common.Mappers;

namespace Nsi.Application.Queries.Category;

public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDetailsDto>;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDetailsDto>
{
    private readonly ICategoryService _categoryService;

    public GetCategoryByIdQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<CategoryDetailsDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _categoryService.GetCategoryById(request.Id);
        if (post == null) throw new NotFoundException("Category not found");
        return post.MapToCategoryDetailsDto();
    }
};