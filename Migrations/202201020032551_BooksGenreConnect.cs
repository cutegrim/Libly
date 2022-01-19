namespace Libly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BooksGenreConnect : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Books",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        Author = c.String(),
                        NumberInStock = c.Byte(nullable: false),
                        
                    })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Books", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Books", "GenreId");
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
           
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropColumn("dbo.Books", "GenreId");
            DropTable("dbo.Books");
        }
    }
}
