using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateWeb.Entities
{
    public class Seat
    {
        public Seat(string seatName, bool status, string roomId)
        {
            SeatName = seatName;
            Status = status;
            RoomId = roomId;
        }

        public int SeatId { get; set; }
        public string SeatName { get; set; }
        public Room Room { get; set; }
        public bool Status { get; set; }
        public string RoomId { get; set; }
        
    }

}
