namespace BoardGameGroup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inil : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoardgameModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BoardgameName = c.String(),
                        MinPlayers = c.Int(nullable: false),
                        MaxPlayers = c.Int(nullable: false),
                        MinAge = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BoardgameModels");
        }
    }
}
