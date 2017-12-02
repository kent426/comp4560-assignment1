using ass2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ass2.Models
{
    public class DbInitializer
    {

        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
       RoleManager<IdentityRole> roleManager, ILogger<DbInitializer> logger)
        {


            //If there is already an Administrator role, abort
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {

                //Create the Administartor Role
                await roleManager.CreateAsync(new IdentityRole("Admin"));

                //Create the default Admin account and apply the Administrator role
                string user = "a@a.a";
                string password = "P@$$w0rd";
                string username = "a";
                await userManager.CreateAsync(new ApplicationUser { UserName = username, Email = user, EmailConfirmed = true }, password);
                await userManager.AddToRoleAsync(await userManager.FindByNameAsync(user), "Admin");
            }

            //If there is already an Administrator role, abort
            if (!context.Roles.Any(r => r.Name == "Member"))
            {

                //Create the Administartor Role
                await roleManager.CreateAsync(new IdentityRole("Member"));

                //Create the default Admin account and apply the Administrator role
                string muser = "m@m.m";
                string mpassword = "P@$$w0rd";
                string musername = "m";
                await userManager.CreateAsync(new ApplicationUser { UserName = musername, Email = muser, EmailConfirmed = true }, mpassword);
                await userManager.AddToRoleAsync(await userManager.FindByNameAsync(muser), "Member");


            }

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

            //context.ActivityCategories.AddAsyncAddOrUpdate(t => t.ActivityDescription, GetCategories().ToArray());

            if (!context.ActivityCategories.Any(r => r.ActivityDescription == "Garage Sale"))
            {
                foreach (ActivityCategory s in categories)
                {
                    context.ActivityCategories.Add(s);
                }
            }
            context.SaveChanges();

            List<Event> events = new List<Event>()
            {
                new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,17,8,30,0),
                    EventToDateTime = new DateTime(2017,10,17,10,30,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,15,10,30,0),
                    IsActive = true,
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Senior’s Golf Tournament")
                 },
                 new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,18,8,30,0),
                    EventToDateTime = new DateTime(2017,10,18,10,30,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,15,10,30,0),
                    IsActive = true,
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Leadership General Assembly Meeting" )               },
                 new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,20,5,30,0),
                    EventToDateTime = new DateTime(2017,10,20,7,15,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,15,7,15,0),
                    IsActive = true,
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Youth Bowling Tournament" )
                 },
                  new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,20,7,00,0),
                    EventToDateTime = new DateTime(2017,10,20,8,00,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,15,8,00,0),
                    IsActive = true,
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Young ladies cooking lessons" )
                 },
                   new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,21,8,30,0),
                    EventToDateTime = new DateTime(2017,10,21,10,30,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,15,10,30,0),
                    IsActive = true,
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Youth craft lessons" )
                 },
                    new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,21,10,30,0),
                    EventToDateTime = new DateTime(2017,10,21,12,00,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,15,12,00,0),
                    IsActive = true,
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Youth choir practice" )
                 },
                     new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,21,12,0,0),
                    EventToDateTime = new DateTime(2017,10,21,13,30,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,12,13,30,0),
                    IsActive = true,
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Lunch Sunday" )
                 },
                      new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,22,7,30,0),
                    EventToDateTime = new DateTime(2017,10,22,8,30,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,12,8,30,0),
                    IsActive = true,
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Pancake Breakfast" )
                 },
                       new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,22,8,30,0),
                    EventToDateTime = new DateTime(2017,10,22,10,30,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,12,10,30,0),
                    IsActive = true,
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Swimming Lessons for the youth" )
                 },
                       new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,22,8,30,0),
                    EventToDateTime = new DateTime(2017,10,22,10,30,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,12,10,30,0),
                    IsActive = true,
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Swimming Exercise for parents" )
                 },
                         new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,22,10,30,0),
                    EventToDateTime = new DateTime(2017,10,22,12,00,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,12,12,00,0),
                    IsActive = true,
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Bingo Tournament" )
                 },
                          new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,22,12,0,0),
                    EventToDateTime = new DateTime(2017,10,22,13,00,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,15,13,00,0),
                    IsActive = true,
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "BBQ Lunch" )

                 },
                           new Event()
                {
                    EventFromDateTime= new DateTime(2017,10,22,13,00,0),
                    EventToDateTime = new DateTime(2017,10,22,18,00,0),
                    EnteredByUsername = "someone",
                    CreationDate = new DateTime(2017,10,15,18,00,0),
                    IsActive = true,
                    ActivityCategory = context.ActivityCategories.FirstOrDefault(c =>  c.ActivityDescription == "Garage Sale" )
                 }
            };


            if (!context.Events.Any(r => r.EnteredByUsername == "someone"))
            {
                foreach (Event e in events)
                {
                    context.Events.Add(e);
                }
            }

            context.SaveChanges();
        }
    }

}
