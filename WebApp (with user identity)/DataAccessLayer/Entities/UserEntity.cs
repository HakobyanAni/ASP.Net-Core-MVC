using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class UserEntity : IdentityUser
    {
        //public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public int ClientId { get; set; }
        public int RoleId { get; set; }
        public bool Deleted { get; set; }
    }
}
