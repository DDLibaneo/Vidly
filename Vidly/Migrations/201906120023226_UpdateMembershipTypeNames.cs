namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = '' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Beginner' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Intermediate' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Professional' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
