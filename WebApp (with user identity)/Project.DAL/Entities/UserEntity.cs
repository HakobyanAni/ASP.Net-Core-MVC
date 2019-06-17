using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Project.DAL.Entities
{
    public class UserEntity : IdentityUser<int>
    {
        [Required]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedByUserId { get; set; }
        public int? CreatedByUserId { get; set; }
        public bool Deleted { get; set; }
        public int ClientId { get; set; }
        public ClientEntity Client { get; set; }
    }
}
