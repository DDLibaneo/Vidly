namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name, Definition) VALUES ('Action', '')");
            Sql("INSERT INTO Genres (Name, Definition) VALUES ('Comedy', '')");
            Sql("INSERT INTO Genres (Name, Definition) VALUES ('Sci-Fi', '')");
            Sql("INSERT INTO Genres (Name, Definition) VALUES ('Horror', '')");
            Sql("INSERT INTO Genres (Name, Definition) VALUES ('Romance', '')");
            Sql("INSERT INTO Genres (Name, Definition) VALUES ('Thriller', '')");
            Sql("INSERT INTO Genres (Name, Definition) VALUES ('Drama', '')");
            Sql("INSERT INTO Genres (Name, Definition) VALUES ('Mystery', '')");
            Sql("INSERT INTO Genres (Name, Definition) VALUES ('Crime', '')");
            Sql("INSERT INTO Genres (Name, Definition) VALUES ('Animation', '')");
            Sql("INSERT INTO Genres (Name, Definition) VALUES ('Adventure', '')");
            Sql("INSERT INTO Genres (Name, Definition) VALUES ('Fantasy', '')");
            Sql("INSERT INTO Genres (Name, Definition) VALUES ('Comedy-Romance', '')");            
        }
        
        public override void Down()
        {
        }
    }
}
