using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UI.Models;

namespace UI.Data;

public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
{
    
}