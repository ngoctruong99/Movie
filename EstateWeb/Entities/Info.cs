using System;
using System.Collections.Generic;

namespace EstateWeb.Entities
{
    public class Info : BaseEntity
    {
        internal readonly int Province;


        public int Phone { get; set; }
        public bool Gender { get; set; }


        public User User { get; set; }

        public int UserId { get; set; }
    }
}
