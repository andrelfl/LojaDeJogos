using LojaDeJogos.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LojaDeJogos.Startup))]
namespace LojaDeJogos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            // Role "Admin"
            if (!roleManager.RoleExists("Admin"))
            {
                // não existe "Admin"
                // criar essa role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            // Role "User"
            if (!roleManager.RoleExists("User"))
            {
                // não existe "User"
                // criar essa role
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }

            // criar "Admin"
            var user = new ApplicationUser();
            user.UserName = "admin@mail.pt";
            user.Email = "admin@mail.pt";
            string userPWD = "passwordAdmin";
            var chkUser = userManager.Create(user, userPWD);

            //Adicionar o Utilizador à respetiva Role-Admin
            if (chkUser.Succeeded)
            {
                var result1 = userManager.AddToRole(user.Id, "Admin");
                result1 = userManager.AddToRole(user.Id, "User");
            }

            // criar "User"
            var user2 = new ApplicationUser();
            user2.UserName = "user@mail.pt";
            user2.Email = "user@mail.pt";
            string user2PWD = "passwordUser";
            var chkUser2 = userManager.Create(user2, user2PWD);

            //Adicionar o Utilizador à respetiva Role-Admin
            if (chkUser2.Succeeded)
            {
                var result1 = userManager.AddToRole(user2.Id, "User");
            }
        }
    }
}
