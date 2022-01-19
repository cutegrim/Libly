namespace Libly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookPropertiesRequiredState : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Author", c => c.String());
        }
    }
}
