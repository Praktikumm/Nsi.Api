using Microsoft.AspNetCore.Identity;

namespace Nsi.Domain.Entities;

public class ApplicationRole : IdentityRole<string>
{
    public IList<ApplicationUserRole> UserRoles { get; set; }
}