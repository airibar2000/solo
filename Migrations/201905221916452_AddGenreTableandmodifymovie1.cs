namespace solo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreTableandmodifymovie1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Byte(nullable: false),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            AlterColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
            DropColumn("dbo.Movies", "Genres_GenreId");
            DropColumn("dbo.Movies", "Genres_GenreName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genres_GenreName", c => c.String());
            AddColumn("dbo.Movies", "Genres_GenreId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AlterColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            DropTable("dbo.Genres");
        }
    }
}
