namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c297ac3f-3ed7-4399-a5bd-3e5ac9b1fc10', N'guest@vidly.com', 0, N'AHg6Rh3OQaeGQalVLMCwHfya3yaQKRv8AwYYCG01OwDiPiVl4DkclzzCxuIp0xMw3Q==', N'c0567176-0357-44a7-b4e3-54fc92ef0da8', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c876f514-1e64-4613-8882-38c1b8893fe6', N'admin@Vidly.com', 0, N'ANNO8tydb5X0gj1fgYdGXWGkRI/AUrMVTlgkMQ4lAguZUDDkfK2jDny5B8Kjk33cZw==', N'3c11a981-c666-469b-9fa4-9db4a961fa19', NULL, 0, 0, NULL, 1, 0, N'admin@Vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e5ecfde9-2ebb-4b39-b131-7dd482b79ce3', N'CanManagMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c876f514-1e64-4613-8882-38c1b8893fe6', N'e5ecfde9-2ebb-4b39-b131-7dd482b79ce3')

");
        }
        
        public override void Down()
        {
        }
    }
}
