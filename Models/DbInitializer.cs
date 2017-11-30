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
            if (context.Roles.Any(r => r.Name == "Admin")) return;

            //Create the Administartor Role
            await roleManager.CreateAsync(new IdentityRole("Admin"));

            //Create the default Admin account and apply the Administrator role
            string user = "a@a.a";
            string password = "P@$$w0rd";
            string username = "a";
            await userManager.CreateAsync(new ApplicationUser { UserName = username , Email = user, EmailConfirmed = true }, password);
            await userManager.AddToRoleAsync(await userManager.FindByNameAsync(user), "Admin");


            //If there is already an Administrator role, abort
            if (context.Roles.Any(r => r.Name == "Member")) return;

            //Create the Administartor Role
            await roleManager.CreateAsync(new IdentityRole("Member"));

            //Create the default Admin account and apply the Administrator role
            string muser = "m@m.m";
            string mpassword = "P@$$w0rd";
            string musername = "m";
            await userManager.CreateAsync(new ApplicationUser { UserName = musername, Email = muser, EmailConfirmed = true }, mpassword);
            await userManager.AddToRoleAsync(await userManager.FindByNameAsync(muser), "Member");



            context.SaveChanges();
        }
    }

}
