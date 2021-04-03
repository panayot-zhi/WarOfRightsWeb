using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarOfRightsWeb.Data
{
    public class MapRegimentWeapon
    {
        [Key]
        public int ID { get; set; }


        public int MapRegimentID { get; set; }

        public MapRegiment MapRegiment { get; set; }


        public int WeaponID { get; set; }

        public Weapon Weapon { get; set; }


        public int? Count { get; set; }

        public int? Percent { get; set; }

    }
}
