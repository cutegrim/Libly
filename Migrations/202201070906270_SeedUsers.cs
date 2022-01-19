namespace Libly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'35cdd956-8e07-4da5-87a5-10bd40227df3', N'admin@libly.com', 0, N'AK+4UxMUPpFpO7PqsA3Znlj0H1pBwHh9YrI+vo7hy0WN8jZGtkz9RnzONvqXptqW1Q==', N'29412502-11dc-4fb9-87eb-cd2a2399cccb', NULL, 0, 0, NULL, 1, 0, N'admin@libly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b982524b-44ff-46d8-ab49-2c620f1418c5', N'guest@libly.com', 0, N'AOW0VVT1hCqTE7DXUc0I7H6m7XmspBBrvn0O7tvj8zWQfnkIJfKh0Ko0F8zDuxbovg==', N'52bc5f00-e165-46ee-9156-7ed1f34239f4', NULL, 0, 0, NULL, 1, 0, N'guest@libly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5df71a12-bebb-4257-8620-87fe20883bbf', N'CanManageBooks')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'35cdd956-8e07-4da5-87a5-10bd40227df3', N'5df71a12-bebb-4257-8620-87fe20883bbf')


");
        }
        
        public override void Down()
        {
        }
    }
}
