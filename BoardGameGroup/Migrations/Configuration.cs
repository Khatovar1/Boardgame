namespace BoardGameGroup.Migrations
{
    using BoardGameGroup.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BoardGameGroup.DAL.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BoardGameGroup.DAL.DatabaseContext context)
        {
            context.Boardgames.AddOrUpdate(x => x.ID,
                new BoardgameModel() { ID = 1, BoardgameName = "Five Tribes", MinPlayers = 2, MaxPlayers = 4, MinAge = 13 },
                new BoardgameModel() { ID = 2, BoardgameName = "Patchwork", MinPlayers = 2, MaxPlayers = 2, MinAge = 8 },
                new BoardgameModel() { ID = 3, BoardgameName = "Battlestar Galactica", MinPlayers = 3, MaxPlayers = 6, MinAge = 10 },
                new BoardgameModel() { ID = 4, BoardgameName = "Dead of Winter", MinPlayers = 2, MaxPlayers = 5, MinAge = 13 },
                new BoardgameModel() { ID = 5, BoardgameName = "Game of Thrones", MinPlayers = 3, MaxPlayers = 6, MinAge = 14 },
                new BoardgameModel() { ID = 6, BoardgameName = "Valhalla", MinPlayers = 1, MaxPlayers = 6, MinAge = 13 },
                new BoardgameModel() { ID = 7, BoardgameName = "Neuroshima Hex", MinPlayers = 1, MaxPlayers = 4, MinAge = 13 },
                new BoardgameModel() { ID = 8, BoardgameName = "Space Explorers", MinPlayers = 2, MaxPlayers = 4, MinAge = 10 },
                new BoardgameModel() { ID = 9, BoardgameName = "Love Letter", MinPlayers = 2, MaxPlayers = 4, MinAge = 10 },
                new BoardgameModel() { ID = 10, BoardgameName = "Ghost Stories", MinPlayers = 1, MaxPlayers = 4, MinAge = 12 },
                new BoardgameModel() { ID = 11, BoardgameName = "Battles of Westeros", MinPlayers = 2, MaxPlayers = 2, MinAge = 12 },
                new BoardgameModel() { ID = 12, BoardgameName = "Catan", MinPlayers = 3, MaxPlayers = 4, MinAge = 10 }                
                );
        }
    }
}
