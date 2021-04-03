using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarOfRightsWeb.Data
{
    public class Map
    {
        [Key]
        public int ID { get; set; }


        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string DisplayName { get; set; }

        [Column(TypeName = "TEXT")]
        public string Description { get; set; }

        [MaxLength(256)]
        public string DateTimeDescription { get; set; }

        [MaxLength(128)]
        public string DefendingTeam { get; set; }

        public decimal? TransferOnDeath { get; set; }

        public int? RoundTime { get; set; }

        public int? WaveTime { get; set; }

        public decimal? CaptureSpeed { get; set; }

        public decimal? NeutralizeSpeed { get; set; }

        public int? TicketsUSA { get; set; }

        public int? TicketsCSA { get; set; }

        public int? FinalPushTime { get; set; }

        
        [MaxLength(256)]
        public string SkirmishImagePath { get; set; }

        [MaxLength(256)]
        public string SpawnImagePath { get; set; }

        [MaxLength(256)]
        public string LoadingImagePath { get; set; }

        
        public ICollection<MapRegiment> MapRegiments { get; set; }

    }
}
