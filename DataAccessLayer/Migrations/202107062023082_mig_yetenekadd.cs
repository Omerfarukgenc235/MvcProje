namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_yetenekadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Yeteneks",
                c => new
                    {
                        YetenekID = c.Int(nullable: false, identity: true),
                        YetenekAdi = c.String(maxLength: 50),
                        Yetenekyuzde = c.Int(nullable: false),
                        YetenekDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.YetenekID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Yeteneks");
        }
    }
}
