using System;
using System.Linq;
using AuthenticationAspDonetCore_Khoi.Data;
using AuthenticationAspDonetCore_Khoi.Initiallizer;
using AuthenticationAspDonetCore_Khoi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAspDonetCore_Khoi.Initializer
{
    public class DbInitailizer: IDbInitailizer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IDbInitailizer _dbInitailizerImplementation;


        public DbInitailizer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch(Exception ex)
            {

            }

            if (_db.Roles.Any(r => r.Name == "Admin")) return;
            if (_db.Roles.Any(r => r.Name == "Staff")) return;

            _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("Staff")).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "dangkhoi1@gmail.com",
                Email = "dangkhoi1@gmail.com",
                EmailConfirmed = true,
                FullName = "Admin"
            },"Dangkhoi123@").GetAwaiter().GetResult() ;

            ApplicationUser userAdmin = _db.ApplicationUsers.Where(u => u.Email == "dangkhoi1@gmail.com").FirstOrDefault();

            _userManager.AddToRoleAsync(userAdmin,"Admin").GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "Staffrole@gmail.com",
                Email = "Staffrole@gmail.com",
                EmailConfirmed = true,
                FullName = "Staff"
            },"Dangkhoi123@").GetAwaiter().GetResult() ;

            ApplicationUser userStaff = _db.ApplicationUsers.Where(u => u.Email == "Staffrole@gmail.com").FirstOrDefault();

            _userManager.AddToRoleAsync(userStaff,"Staff").GetAwaiter().GetResult();
        }
        
    }
} 