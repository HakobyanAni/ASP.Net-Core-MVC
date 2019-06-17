using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Models
{
    public class ClientModel : BaseModel
    {
        public ClientModel()
        {
            this.Users = new List<UserModel>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public List<UserModel> Users { get; set; }
    }
}
