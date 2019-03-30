using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation_Layer.Models
{
    public class UserModel : IdentityUser
    {
        public int BirthYear { get; set; }
    }
}
