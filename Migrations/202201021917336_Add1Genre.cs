namespace Libly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add1Genre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Fantasy')");
        }
        
        public override void Down()
        {
        }
    }
}
