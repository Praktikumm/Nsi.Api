using Microsoft.AspNetCore.Identity;

namespace Nsi.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public IList<ApplicationUserRole> Roles { get; set; }
    public IList<Category> Categories { get; set; }
}