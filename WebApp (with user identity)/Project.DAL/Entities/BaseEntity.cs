using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Entities
{
    public class BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdatedByUserId { get; set; }
        public bool Deleted { get; set; }
        public UserEntity UpdatedByUser { get; set; }
        public UserEntity CreatedByUser { get; set; }
    }
}
