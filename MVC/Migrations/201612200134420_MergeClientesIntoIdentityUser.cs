namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MergeClientesIntoIdentityUser : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Clientes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 255),
                        Endereco = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
