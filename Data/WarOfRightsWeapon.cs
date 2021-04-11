using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarOfRightsWeb.Data
{
    public class Weapon
    {
        [Key]
        [Required]
        [MaxLength(255)]
        public string ID { get; set; }


        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "TEXT")]
        public string Description { get; set; }

        [MaxLength(512)]
        public string ParametersDescription { get; set; }


        public ICollection<MapRegimentWeapon> MapRegimentWeapons { get; set; }
    }
}
