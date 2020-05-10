using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EstateWeb.Entities
{
    public class Room 
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        [Key]
        public string RoomId { get; set; }
        public string RoomType { get; set; }
        public int TotalSeat { get; set; }
        public ICollection<Seat> Seats { get; set; }
        public ICollection<TimeSlot> TimeSlots { get; set; }

        public ICollection<Address> Addresses { get; set; }

    }
}
