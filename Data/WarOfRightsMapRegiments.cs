using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarOfRightsWeb.Data
{
    public class MapRegiment
    {
        public int ID { get; set; }

        public int MapID { get; set; }

        public Map Map { get; set; }

        public int RegimentID { get; set; }

        public Regiment Regiment { get; set; }

        public ICollection<MapRegimentWeapon> MapRegimentWeapons { get; set; }

    }
}
