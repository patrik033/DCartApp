using DCartWeb.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DCartWeb.Models.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<SelectListItem> RoleList { get; set; }
        public User User { get; set; } = new User();
        public IdentityRole Roles { get; set; } = new IdentityRole();
        public string OldRole { get; set; }
    }
}
