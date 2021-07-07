namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_yetkilendirmeeklendi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Yetkis",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Role = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.RoleID);
            
            AddColumn("dbo.Admins", "Yetki_RoleID", c => c.Int());
            CreateIndex("dbo.Admins", "Yetki_RoleID");
            AddForeignKey("dbo.Admins", "Yetki_RoleID", "dbo.Yetkis", "RoleID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "Yetki_RoleID", "dbo.Yetkis");
            DropIndex("dbo.Admins", new[] { "Yetki_RoleID" });
            DropColumn("dbo.Admins", "Yetki_RoleID");
            DropTable("dbo.Yetkis");
        }
    }
}
