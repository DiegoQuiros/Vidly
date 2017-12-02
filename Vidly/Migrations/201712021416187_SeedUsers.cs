namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0e63893a-0fac-4572-9faf-2fdddc6ba61c', N'guest@vidly.com', 0, N'ANb5GPXK2HV1rrSm4+bctuNxDqQTSnhjLZcHjWNvINXwWzgm3KNn6orYgWUmQ6GGRA==', N'5d8f5ef5-e39a-41e8-8af1-bb15dcadad16', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'66112e97-a0b7-41ef-8fbf-8f70594e0563', N'admin@vidly.com', 0, N'AIIsx+HMy1FmSUyT9EKf3PuHQvWsBkwF/cuGMLtusSah9jENvCVHQr7EvwJwO4QTfw==', N'9624b170-c3d8-45d2-8ffb-ad825ec484da', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'842db25a-dd44-40ec-8260-c252ca3dd450', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'66112e97-a0b7-41ef-8fbf-8f70594e0563', N'842db25a-dd44-40ec-8260-c252ca3dd450')

");
        }
        
        public override void Down()
        {
        }
    }
}
