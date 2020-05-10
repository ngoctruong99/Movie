using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstateWeb.Entities
{
    public class TimeSlot
    {
        [Key]
        public int TimeSlotId { get; set; }
        public DateTime DateSlot { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public Room Room { get; set; }

        public string RoomId { get; set; }


    }
}
