namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersAndFornadas : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Nome], [Endereco]) VALUES (N'317af657-385c-4eb4-b276-c5b10decdcb5', N'admin@padocaonline.com', 0, N'ADLFB9Y9WKTU3heKn8Ogd4zsHW8PFn2vbgXodlYPl1UfGCRQPk0Gjcyj55I2lcRmWw==', N'6bf6e9ce-c391-43ce-a085-b9d3f59c73c8', NULL, 0, 0, NULL, 1, 0, N'admin@padocaonline.com', N'Admin', N'Avenida Presidente Vargas, 2000')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Nome], [Endereco]) VALUES (N'888d69e9-c024-40a0-a8ff-565249d65b62', N'guest@padocaonline.com', 0, N'AN2r93OcGZJJ+VZIFOKi7CQ5OZqr8e9lkyL/HHkRcgcBPjMIAVTk7VZYjPxOCF4wyg==', N'3dd1638b-4214-44fb-9ee6-c437dea7322c', NULL, 0, 0, NULL, 1, 0, N'guest@padocaonline.com', N'Guest', N'Avenida Presidente Vargas, 2500')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'46e873c8-143e-41ee-8598-37fc32184398', N'GerenciaFornadas')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'317af657-385c-4eb4-b276-c5b10decdcb5', N'46e873c8-143e-41ee-8598-37fc32184398')
SET IDENTITY_INSERT [dbo].[Fornadas] ON
INSERT INTO [dbo].[Fornadas] ([Id], [Descricao], [DataHora]) VALUES (1, N'Baguetes, pães e muito mais! Confira!', N'2016-12-19 15:30:00')
INSERT INTO [dbo].[Fornadas] ([Id], [Descricao], [DataHora]) VALUES (2, N'Baguetes, pães e muito mais! Confira!', N'2016-12-19 17:05:00')
INSERT INTO [dbo].[Fornadas] ([Id], [Descricao], [DataHora]) VALUES (4, N'Baguetes, pães e muito mais! Confira!', N'2016-12-19 17:40:00')
INSERT INTO [dbo].[Fornadas] ([Id], [Descricao], [DataHora]) VALUES (5, N'Baguetes, pães e muito mais! Confira!', N'2016-12-19 18:05:00')
SET IDENTITY_INSERT [dbo].[Fornadas] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
