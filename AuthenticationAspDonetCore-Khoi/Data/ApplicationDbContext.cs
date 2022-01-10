using System;
using System.Collections.Generic;
using System.Text;
using AuthenticationAspDonetCore_Khoi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAspDonetCore_Khoi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<ApplicationUser> ApplicationUsers { set; get; }
        public DbSet<Category> Categories { set; get; }
    }
}