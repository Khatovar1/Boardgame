using Foolproof;
using System.ComponentModel.DataAnnotations;

namespace BoardGameGroup.Models
{
    public class BoardgameModel
    {
        public int ID { get; set; }

        [Required]
        public string BoardgameName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int MinPlayers { get; set; }

        [GreaterThanOrEqualTo("MinPlayers")]
        public int MaxPlayers { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int MinAge { get; set; }
    }
}