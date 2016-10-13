namespace FinalDutExpressSystem.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalDutExpressSystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "FinalDutExpressSystem.Models.ApplicationDbContext";
        }
       
          
        
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);
        }

        bool Roles(ApplicationDbContext context)
        {


            LoginViewModel obj = new LoginViewModel();
            IdentityResult ir1, ir2;
            var roleMan = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir1 = roleMan.Create(new IdentityRole("Admin"));

            var userMan = new UserManager<ApplicationUser>
                (new UserStore<ApplicationUser>(context));
            ir2 = roleMan.Create(new IdentityRole("Students"));

            var user = new ApplicationUser()
            {
                UserName = "admin@dutexpress.com",
                PasswordHash = "Password1!#",
            };

            ;
            if (ir1.Succeeded == false)
                return ir1.Succeeded;
            ir1 = userMan.AddToRole(user.Id, "Admin");
            return ir1.Succeeded;



        }
        //  This method will be called after migrating to the latest version.

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data. E.g.
        //
        //    context.People.AddOrUpdate(
        //      p => p.FullName,
        //      new Person { FullName = "Andrew Peters" },
        //      new Person { FullName = "Brice Lambson" },
        //      new Person { FullName = "Rowan Miller" }
        //    );
        //
    }
    }

