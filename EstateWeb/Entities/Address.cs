using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateWeb.Entities
{
    public class Address : BaseEntity
    {

        public int Province { get; set; }

        public int District { get; set; }

        public int Ward { get; set; }

        public int Street { get; set; }

        public string NO { get; set; }
        public Room Room { get; set; }

        public string RoomId { get; set; }
    }
}
