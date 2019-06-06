using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.DAL.Entities
{
    public class ClientEntity : BaseEntity
    {
        public ClientEntity()
        {
            this.Users = new List<UserEntity>();
        }
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; }
    }
}
