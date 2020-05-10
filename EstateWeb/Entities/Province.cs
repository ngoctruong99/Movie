using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EstateWeb.Entities
{
    public class Province 
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<District> Districts { get; set; }
    }
}
