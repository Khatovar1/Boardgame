using BoardGameGroup.Models;
using System.Data.Entity;

namespace BoardGameGroup.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<BoardgameModel> Boardgames { get; set; }
        public DbSet<BoardgameDisplayModel> BoardgameDisplays { get; set; }
    }
}