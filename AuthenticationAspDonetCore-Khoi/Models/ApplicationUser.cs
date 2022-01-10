using System;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationAspDonetCore_Khoi.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CredentialId { get; set; }
        public string HealthCareId { get; set; }
    }
}