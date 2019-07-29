using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BoardGameGroup.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<BoardgameModel> Boardgames { get; set; }
    }
}