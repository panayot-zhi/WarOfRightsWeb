using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WarOfRightsWeb.Constants;

namespace WarOfRightsWeb.Data
{
    public class Map
    {
        [Key]
        [Required]
        [MaxLength(255)]
        public string ID { get; set; }


        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string AreaName { get; set; }

        [Column(TypeName = "TEXT")]
        public string Description { get; set; }

        [MaxLength(255)]
        public string DateTimeDescription { get; set; }

        [MaxLength(127)]
        public string DefendingTeam { get; set; }

        [Column(TypeName = "DECIMAL(6,4)")]
        public decimal? TransferOnDeath { get; set; }

        public int? RoundTime { get; set; }

        public int? WaveTime { get; set; }

        [Column(TypeName = "DECIMAL(6,4)")]
        public decimal? CaptureSpeed { get; set; }

        [Column(TypeName = "DECIMAL(6,4)")]
        public decimal? NeutralizeSpeed { get; set; }

        public int? TicketsUSA { get; set; }

        public int? TicketsCSA { get; set; }

        public int? FinalPushTime { get; set; }


        [MaxLength(255)]
        public string SkirmishImagePath { get; set; }

        [MaxLength(255)]
        public string SpawnImagePath { get; set; }

        [MaxLength(255)]
        public string LoadingImagePath { get; set; }

        public int Order { get; set; }

        public ICollection<MapRegiment> MapRegiments { get; set; }

        [NotMapped]
        public IList<MapRegiment> MapCSARegiments =>
            MapRegiments?.Where(x => x.Regiment.Faction.Equals(Labels.CSA)).ToList();

        [NotMapped]
        public IList<MapRegiment> MapUSARegiments =>
            MapRegiments?.Where(x => x.Regiment.Faction.Equals(Labels.USA)).ToList();

    }
}
