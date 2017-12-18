namespace ProjetoDiscoteca.Musicas.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ALB_ALBUNS",
                c => new
                    {
                        ALB_ID = c.Int(nullable: false, identity: true),
                        ALB_ANO = c.Int(nullable: false),
                        ALB_NOME = c.String(nullable: false, maxLength: 100),
                        ALB_OBSERVACOES = c.String(maxLength: 1000),
                        ALB_EMAIL = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.ALB_ID);
            
            CreateTable(
                "dbo.MUS_MUSICAS",
                c => new
                    {
                        MUS_ID = c.Long(nullable: false, identity: true),
                        MUS_NOME = c.String(nullable: false, maxLength: 50),
                        ALB_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MUS_ID)
                .ForeignKey("dbo.ALB_ALBUNS", t => t.ALB_ID, cascadeDelete: true)
                .Index(t => t.ALB_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MUS_MUSICAS", "ALB_ID", "dbo.ALB_ALBUNS");
            DropIndex("dbo.MUS_MUSICAS", new[] { "ALB_ID" });
            DropTable("dbo.MUS_MUSICAS");
            DropTable("dbo.ALB_ALBUNS");
        }
    }
}
