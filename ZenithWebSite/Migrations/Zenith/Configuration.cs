namespace ZenithWebSite.Migrations.Zenith
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithDataLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithDataLib.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Zenith";
        }

        protected override void Seed(ZenithDataLib.Models.ApplicationDbContext context)
        {
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

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("Member"))
                roleManager.Create(new IdentityRole("Member"));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string[] emails = { "a@a.a", "m@m.m" };
            if (userManager.FindByEmail(emails[0]) == null)
            {
                var user = new ApplicationUser
                {
                    Email = emails[0],
                    UserName = "a",
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Admin");
            }
            if (userManager.FindByEmail(emails[1]) == null)
            {
                var user = new ApplicationUser
                {
                    Email = emails[1],
                    UserName = "m",
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Member");
            }

            context.ActivityCategories.AddOrUpdate(t => t.ActivityDescription, GetCategories().ToArray());
            context.SaveChanges();
            context.Events.AddOrUpdate(t => t.ActivityCategoryId, GetEvents(context).ToArray());
            context.SaveChanges();

        }

        private List<ActivityCategory> GetCategories()
        {
            List<ActivityCategory> categories = new List<ActivityCategory>()
            {
                new ActivityCategory()  {

                    ActivityDescription = "Senior’s Golf Tournament",
                    CreationDate = new DateTime(2017,10,17,8,30,0)
                },
                new ActivityCategory()  {

                    ActivityDescription = "Leadership General Assembly Meeting",
                    CreationDate = new DateTime(2017,10,18,8,30,0)
                },
                new ActivityCategory()  {

                    ActivityDescription = "Youth Bowling Tournament",
                    CreationDate = new DateTime(2017,10,17,8,30,0)
                },
                new ActivityCategory()  {

                    ActivityDescription = "Young ladies cooking lessons",
                    CreationDate = new DateTime(2017,10,18,8,30,0)
                },
                new ActivityCategory()  {

                    ActivityDescription = "Youth craft lessons",
                    CreationDate = new DateTime(2017,10,18,8,30,0)
                },
                new ActivityCategory()  {

                    ActivityDescription = "Youth choir practice",
                    CreationDate = new DateTime(2017,10,18,8,30,0)

                },
                new ActivityCategory()  {

                    ActivityDescription = "Lunch Sunday",
                    CreationDate = new DateTime(2017,10,18,8,30,0)

                },
                new ActivityCategory()  {

                    ActivityDescription = "Pancake Breakfast",
                    CreationDate = new DateTime(2017,10,18,8,30,0)

                },
                new ActivityCategory()  {

                    ActivityDescription = "Swimming Lessons for the youth",
                    CreationDate = new DateTime(2017,10,18,8,30,0)

                },
                new ActivityCategory()  {

                    ActivityDescription = "Swimming Exercise for parents",
                    CreationDate = new DateTime(2017,10,18,8,30,0)

                },
                new ActivityCategory()  {

                    ActivityDescription = "Bingo Tournament",
                    CreationDate = new DateTime(2017,10,18,8,30,0)

                },
                new ActivityCategory()  {

                    ActivityDescription = "BBQ Lunch",
                    CreationDate = new DateTime(2017,10,18,8,30,0)
                },
                new ActivityCategory()  {
                    ActivityDescription = "Garage Sale",
                    CreationDate = new DateTime(2017,10,18,8,30,0)

                }
            };

            return categories;

        }

        private List<Event> GetEvents(ApplicationDbContext appdbc)
        {
            List<Event> events = new List<Event>()
            {
                new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,17,8,30,0),
                    EventToDateTime = new DateTime(2017,10,17,10,30,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,15,10,30,0),
                    IsActive = true,
                    ActivityCategory = appdbc.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Senior’s Golf Tournament")
                 },
                 new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,18,8,30,0),
                    EventToDateTime = new DateTime(2017,10,18,10,30,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,15,10,30,0),
                    IsActive = true,
                    ActivityCategory = appdbc.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Leadership General Assembly Meeting" )               },
                 new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,20,5,30,0),
                    EventToDateTime = new DateTime(2017,10,20,7,15,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,15,7,15,0),
                    IsActive = true,
                    ActivityCategory = appdbc.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Youth Bowling Tournament" )
                 },
                  new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,20,7,00,0),
                    EventToDateTime = new DateTime(2017,10,20,8,00,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,15,8,00,0),
                    IsActive = true,
                    ActivityCategory = appdbc.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Young ladies cooking lessons" )
                 },
                   new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,21,8,30,0),
                    EventToDateTime = new DateTime(2017,10,21,10,30,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,15,10,30,0),
                    IsActive = true,
                    ActivityCategory = appdbc.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Youth craft lessons" )
                 },
                    new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,21,10,30,0),
                    EventToDateTime = new DateTime(2017,10,21,12,00,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,15,12,00,0),
                    IsActive = true,
                    ActivityCategory = appdbc.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Youth choir practice" )
                 },
                     new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,21,12,0,0),
                    EventToDateTime = new DateTime(2017,10,21,13,30,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,12,13,30,0),
                    IsActive = true,
                    ActivityCategory = appdbc.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Lunch Sunday" )
                 },
                      new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,22,7,30,0),
                    EventToDateTime = new DateTime(2017,10,22,8,30,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,12,8,30,0),
                    IsActive = true,
                    ActivityCategory = appdbc.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Pancake Breakfast" )
                 },
                       new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,22,8,30,0),
                    EventToDateTime = new DateTime(2017,10,22,10,30,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,12,10,30,0),
                    IsActive = true,
                    ActivityCategory = appdbc.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Swimming Lessons for the youth" )
                 },
                       new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,22,8,30,0),
                    EventToDateTime = new DateTime(2017,10,22,10,30,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,12,10,30,0),
                    IsActive = true,
                    ActivityCategory = appdbc.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Swimming Exercise for parents" )
                 },
                         new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,22,10,30,0),
                    EventToDateTime = new DateTime(2017,10,22,12,00,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,12,12,00,0),
                    IsActive = true,
                    ActivityCategory = appdbc.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Bingo Tournament" )
                 },
                          new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,22,12,0,0),
                    EventToDateTime = new DateTime(2017,10,22,13,00,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,15,13,00,0),
                    IsActive = true,
                    ActivityCategory = appdbc.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "BBQ Lunch" )

                 },
                           new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,22,13,00,0),
                    EventToDateTime = new DateTime(2017,10,22,18,00,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,15,18,00,0),
                    IsActive = true,
                    ActivityCategory = appdbc.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Garage Sale" )
                 }
            };

            return events;
        }






        //public virtual List<Event> Events { get; set; }
    }
            

    
}
