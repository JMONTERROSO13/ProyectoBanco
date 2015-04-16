namespace ProyectoBanco.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using ProyectoBanco.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProyectoBanco.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProyectoBanco.Models.ApplicationDbContext context)
        {
            if(!context.Users.Any(u => u.UserName ==  "Administrador")){
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Administrador" };

                manager.Create(user, "Admin123");
                var AdminRole = new  IdentityRole{ Name = "Admin"} ;

                roleManager.Create(AdminRole);
                var UserRole = new IdentityRole{Name = "Usuario"};
                
                roleManager.Create(UserRole);
                manager.AddToRole(user.Id, "Admin");

            }
        }
    }
}
