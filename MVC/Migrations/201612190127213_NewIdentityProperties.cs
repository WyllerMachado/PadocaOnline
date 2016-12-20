namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewIdentityProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nome", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "Endereco", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Endereco");
            DropColumn("dbo.AspNetUsers", "Nome");
        }
    }
}
