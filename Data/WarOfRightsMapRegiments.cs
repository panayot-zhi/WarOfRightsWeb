using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarOfRightsWeb.Data
{
    public class MapRegiment
    {
        [Key]
        public string ID { get; set; }


        public string MapID { get; set; }

        public Map Map { get; set; }


        public string RegimentID { get; set; }

        public Regiment Regiment { get; set; }


        public int Order { get; set; }


        public ICollection<MapRegimentWeapon> MapRegimentWeapons { get; set; }

    }
}
