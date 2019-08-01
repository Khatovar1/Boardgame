using System;

namespace BoardGameGroup.Models
{
    public class BoardgameDisplayModel
    {
        public int ID { get; set; }
        public int BoardgameID { get; set; }
        public DateTime DisplayDate { get; set; }
        public DisplaySource Source { get; set; }
    }

    public enum DisplaySource
    {
        WWW,
        Webservice
    }
}