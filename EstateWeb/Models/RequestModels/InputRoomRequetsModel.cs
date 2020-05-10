using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateWeb.Models.RequestModels
{
    public class InputRoomRequetsModel
    {
        public string RoomId { get; set; }
        public string RoomType { get; set; }
        public int TotalSeat { get; set; }

    }
}
