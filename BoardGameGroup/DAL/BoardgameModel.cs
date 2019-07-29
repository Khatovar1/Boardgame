using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardGameGroup.DAL
{
    public class BoardgameModel
    {
        public int ID { get; set; }
        public string BoardgameName { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int MinAge { get; set; }
    }
}