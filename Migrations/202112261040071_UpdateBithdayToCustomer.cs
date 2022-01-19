namespace Libly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBithdayToCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = '1/1/2000' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
