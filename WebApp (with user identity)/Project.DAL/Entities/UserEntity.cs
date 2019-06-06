using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Project.DAL.Enumeration;

namespace Project.DAL.Entities
{
    public class UserEntity : IdentityUser<int>
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }
        public int ClientId { get; set; }
       // public RoleEnum Role { get; set; }
        public bool Deleted { get; set; }
    }
}
