using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarOfRightsWeb.Common;

namespace WarOfRightsWeb.Data
{
    public class Regiment
    {
        [Key]
        [Required]
        [MaxLength(255)]
        public string ID { get; set; }


        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(127)]
        public string Faction { get; set; }

        [MaxLength(127)]
        public string State { get; set; }

        [MaxLength(127)]
        public string Number { get; set; }
        
        [Column(TypeName = "TEXT")]
        public string Description { get; set; }

        [MaxLength(127)]
        public RegimentType Type { get; set; }



        public ICollection<MapRegiment> MapRegiments { get; set; }
    }
}
