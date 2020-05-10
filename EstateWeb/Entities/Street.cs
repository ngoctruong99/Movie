using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EstateWeb.Entities
{
    public class Street
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]

        public int Id { get; set; }
        public string Name { get; set; }

        public District District { get; set; }

        public int DistrictId { get; set; }
    }
}
