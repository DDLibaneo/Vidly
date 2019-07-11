namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'05bab67f-f0ac-44f6-8b8e-5945c49b6844', N'guest@vidly.com', 0, N'AFARmHBAdzA9cbl1o/dnPvaVQ7koN6zMYXxCdbAGy/gVF2VLhFL/tGHGw6ygxbaVKA==', N'a74859a5-12b9-4654-bbd1-9a7345ba278f', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2670e144-a46e-4d1b-80bc-e94097fdd43f', N'admin@vidly.com', 0, N'ABpsDU4ngY3ysaY/XJ06fXpm9I2wn8RPi1qUAbsZuxCVDMXK9OkET9XvWT4u6ka9AA==', N'6927c782-7a21-424d-a1ed-f8ed79de4407', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c680469a-1800-46e7-83c4-4e59a1e2ef6c', N'CanManageMovies')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2670e144-a46e-4d1b-80bc-e94097fdd43f', N'c680469a-1800-46e7-83c4-4e59a1e2ef6c')
            ");            
        }
        
        public override void Down()
        {
        }
    }
}
