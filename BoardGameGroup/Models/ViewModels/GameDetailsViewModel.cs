using System.Collections.Generic;

namespace BoardGameGroup.Models
{
    public class GameDetailsViewModel
    {
        public BoardgameModel Boardgame { get; set; }
        public List<BoardgameDisplayModel> GameDisplaysList { get; set; }
    }
}