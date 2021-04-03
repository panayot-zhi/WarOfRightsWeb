using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarOfRightsWeb.Data.Migrations;

namespace WarOfRightsWeb.Data
{
    public class Regiment
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(128)]
        public string Faction { get; set; }

        [MaxLength(256)]
        public string DisplayName { get; set; }

        [Column(TypeName = "TEXT")]
        public string Description { get; set; }

        [MaxLength(512)]
        public string Parameters { get; set; }

        public ICollection<MapRegiment> MapRegiments { get; set; }
    }
}
