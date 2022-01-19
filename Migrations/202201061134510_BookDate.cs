namespace Libly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "PublishDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "PublishDate", c => c.DateTime(nullable: false));
        }
    }
}
