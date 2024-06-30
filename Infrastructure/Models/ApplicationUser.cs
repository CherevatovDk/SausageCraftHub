using Infrastructure1.Enums;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure1.Models;

public class ApplicationUser:IdentityUser
{
    public Role Role { get; set; }
    
}