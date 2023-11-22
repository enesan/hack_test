using Microsoft.AspNetCore.Identity;

namespace Domain.Identity;

public class ApplicationUser : IdentityUser<int>
{
    public int Group { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }
    public string? University { get; set; }
    
    public virtual ICollection<ApplicationUserRole> Roles { get; set; }
}