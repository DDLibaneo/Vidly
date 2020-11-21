namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnModelCreating : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customers", newName: "Customer");
            RenameTable(name: "dbo.MembershipTypes", newName: "MembershipType");
            RenameTable(name: "dbo.Genres", newName: "Genre");
            RenameTable(name: "dbo.Movies", newName: "Movie");
            RenameTable(name: "dbo.Rentals", newName: "Rental");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Rental", newName: "Rentals");
            RenameTable(name: "dbo.Movie", newName: "Movies");
            RenameTable(name: "dbo.Genre", newName: "Genres");
            RenameTable(name: "dbo.MembershipType", newName: "MembershipTypes");
            RenameTable(name: "dbo.Customer", newName: "Customers");
        }
    }
}
