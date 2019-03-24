using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Representation_Layer_MVC_.Enums;

namespace Representation_Layer_MVC_
{
    public class Room
    {
        public string Number { get; set; }
        public RoomType Type { get; set; }
        public bool IsFee { get; set; }
        public int MaxGuests { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Guest> Guests { get; set; } 
        public List<string> Photos { get; set; }
    }
}
