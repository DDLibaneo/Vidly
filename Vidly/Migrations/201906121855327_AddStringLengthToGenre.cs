namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStringLengthToGenre : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Definition", c => c.String(maxLength: 700));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Definition", c => c.String());
        }
    }
}
