namespace Fazenda.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Despesas", "Quantidade", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Despesas", "Quantidade", c => c.Int(nullable: false));
        }
    }
}
