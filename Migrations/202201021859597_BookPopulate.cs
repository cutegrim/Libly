namespace Libly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookPopulate : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Books ( Name, PublishDate, Author, NumberInStock, GenreId) VALUES ( 'Game of Thrones', '1/8/1996', 'George Martin', 10, 2)");
            Sql("INSERT INTO Books ( Name, PublishDate, Author, NumberInStock, GenreId) VALUES ( 'Hitchhikers guide to the galaxy', '8/4/2005', 'Dougles Adams', 15, 5)");
            Sql("INSERT INTO Books ( Name, PublishDate, Author, NumberInStock, GenreId) VALUES ( 'Lolita',  '1/9/1961', 'Vladimir Nabokov', 20, 2)");
        }
        
        public override void Down()
        {
        }
    }
}
