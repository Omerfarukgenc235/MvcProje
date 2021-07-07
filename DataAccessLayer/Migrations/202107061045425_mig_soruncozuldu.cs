namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_soruncozuldu : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Admins", name: "Yetki_RoleID", newName: "Yetkis_RoleID");
            RenameIndex(table: "dbo.Admins", name: "IX_Yetki_RoleID", newName: "IX_Yetkis_RoleID");
            AddColumn("dbo.Admins", "AdminDurum", c => c.Boolean(nullable: false));
            AddColumn("dbo.Admins", "AdminYetkiID", c => c.Int(nullable: false));
            DropColumn("dbo.Admins", "AdminRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            DropColumn("dbo.Admins", "AdminYetkiID");
            DropColumn("dbo.Admins", "AdminDurum");
            RenameIndex(table: "dbo.Admins", name: "IX_Yetkis_RoleID", newName: "IX_Yetki_RoleID");
            RenameColumn(table: "dbo.Admins", name: "Yetkis_RoleID", newName: "Yetki_RoleID");
        }
    }
}
