using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using Nsi.Application.Common.Dto.Category;
using Nsi.Application.Common.Exceptions;
using Nsi.Application.Common.Interfaces;

namespace Nsi.Application.Category.Commands;

public record CreateCategoryCommand(CreateCategoryDto Request) : IRequest<string>;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, string>
{
   private readonly ICategoryService _categoryService;
   private readonly IHttpContextAccessor _httpContextAccessor;
   private readonly IUserService _userService;
   
   public CreateCategoryCommandHandler(ICategoryService categoryService, IHttpContextAccessor httpContextAccessor, IUserService userService)
   {
      _categoryService = categoryService;
      _httpContextAccessor = httpContextAccessor;
      _userService = userService;
   }
   
   public async Task<string> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
   {
      var ctx = _httpContextAccessor.HttpContext.User;
      var username = ctx.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
      if (username == null) throw new NotFoundException("User not found");

      var user = await _userService.FindByUserName(username.Value);
      if (user == null) throw new NotFoundException("User not found");
      var result = await _categoryService.CreateAsync(request.Request, user, cancellationToken);
      return result.ToString();
   }
}