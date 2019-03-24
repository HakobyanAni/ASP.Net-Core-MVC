using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Representation_Layer_MVC_.Enums;

namespace Representation_Layer_MVC_
{
    public class Guest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GuestSex Sex { get; set; }
        public GuestType Type { get; set; }
        public string BaggageWeight { get; set; }
    }
}
