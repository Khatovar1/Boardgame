namespace BoardGameGroup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Display : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoardgameDisplayModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BoardgameID = c.Int(nullable: false),
                        DisplayDate = c.DateTime(nullable: false),
                        Source = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.BoardgameModels", "BoardgameName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BoardgameModels", "BoardgameName", c => c.String());
            DropTable("dbo.BoardgameDisplayModels");
        }
    }
}
