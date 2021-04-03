using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarOfRightsWeb.Data
{
    public class Regiment
    {
        [Key]
        public int ID { get; set; }


        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string DisplayName { get; set; }

        [MaxLength(128)]
        public string Faction { get; set; }

        [MaxLength(128)]
        public string State { get; set; }

        public string Number { get; set; }
        
        [Column(TypeName = "TEXT")]
        public string Description { get; set; }


        public ICollection<MapRegiment> MapRegiments { get; set; }
    }
}
