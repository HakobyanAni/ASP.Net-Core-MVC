using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Models
{
    public class BaseModel
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int UpdatedByUserId { get; set; }
        public int CreatedByUserId { get; set; }
        public bool Deleted { get; set; }
    }
}
