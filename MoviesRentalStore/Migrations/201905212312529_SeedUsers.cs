namespace MoviesRentalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'477dde3c-6bec-4dab-9a97-d54a76998201', N'jimkata@yahoo.fr', 0, N'ABPZxKiPqWngE/pFmQiExGwD0REPsrNfk1iDRTKWFLiPb/jkmQr5AIt9swEHMrkvRg==', N'81872164-fae5-461b-86e2-2aae38a8ca1b', NULL, 0, 0, NULL, 1, 0, N'jimkata@yahoo.fr');
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f880cf45-1eb5-471f-ad58-9002279a238c', N'blackbrian@yahoo.fr', 0, N'ACh+PHziNbcn3fc0UQEOAcJCdzUBKaHcQw6SZczk8je1qropXYXBc34wlwGdvSkD+Q==', N'0a961f49-4fcc-4f36-8559-4d763a35d8c9', NULL, 0, 0, NULL, 1, 0, N'blackbrian@yahoo.fr');

            
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b0d0607e-90ad-44c8-834c-50b9dce015b7', N'canManageMovies');

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f880cf45-1eb5-471f-ad58-9002279a238c', N'b0d0607e-90ad-44c8-834c-50b9dce015b7');
            ");
        }

        public override void Down()
        {
        }
    }
}
