using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CFAStudentTracker.Models
{
    public class Helpers
    {
        private IdentityDbContext ident = new IdentityDbContext();
        private RoleStore<IdentityRole> roleStore;
        private RoleManager<IdentityRole> roleManager;
        private UserStore<ApplicationUser> userStore;
        private UserManager<ApplicationUser> userManager;

        public Helpers()
        {
            roleStore = new RoleStore<IdentityRole>(ident);
            roleManager = new RoleManager<IdentityRole>(roleStore);
            userStore = new UserStore<ApplicationUser>(ident);
            userManager = new UserManager<ApplicationUser>(userStore);
    }
        public List<SelectListItem> GetRoles()
        {
            var i = roleManager.Roles;
            List<SelectListItem> roles = new List<SelectListItem>();
            foreach (var x in i)
            {
                roles.Add(new SelectListItem { Text = x.Name, Value = x.Name });
            }
            return roles;
        }

        public void SetRole(string UserID, string Role)
        {
            userManager.AddToRole(UserID, Role);
        }

    }
}