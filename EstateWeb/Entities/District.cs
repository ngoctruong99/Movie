using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EstateWeb.Entities
{
    public class District
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]

        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public Province Province { get; set; }


        public ICollection<Ward> Wards { get; set; }

        public ICollection<Street> Streets { get; set; }
    }
}
