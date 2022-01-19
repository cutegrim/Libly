namespace Libly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameToMembership : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Memberships SET Name = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE Memberships SET Name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE Memberships SET Name = 'Annual' WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
