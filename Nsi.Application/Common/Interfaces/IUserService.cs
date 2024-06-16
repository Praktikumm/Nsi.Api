using Nsi.Domain.Entities;

namespace Nsi.Application.Common.Interfaces;

public interface IUserService
{
    Task<ApplicationUser?> FindById(string id);
    Task<ApplicationUser?> FindByUserName(string userName);
}