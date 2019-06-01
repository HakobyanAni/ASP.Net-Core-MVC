using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Enumerations;

namespace DataAccessLayer.Entities
{
    public class UserEntity : IdentityUser
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }
        public int ClientId { get; set; }
        public RoleEnum Role { get; set; }
        public bool Deleted { get; set; }
    }
}
