using System.ComponentModel.DataAnnotations;

namespace WarOfRightsWeb.Data
{
    public class MapRegimentWeapon
    {
        [Key]
        public string ID { get; set; }


        public string MapRegimentID { get; set; }

        public MapRegiment MapRegiment { get; set; }


        public string WeaponID { get; set; }

        public Weapon Weapon { get; set; }


        public int? Count { get; set; }

    }
}
