namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStringLengthAnnotationToPhoneFieldOnUserModels : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE AspNetUsers DROP CONSTRAINT DF__AspNetUse__Phone__3F466844");
            AlterColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false));
        }
    }
}
