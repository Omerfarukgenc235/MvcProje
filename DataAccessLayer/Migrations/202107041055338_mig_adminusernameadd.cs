namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_adminusernameadd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary(maxLength: 50));
            DropColumn("dbo.Admins", "AdminUserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary());
        }
    }
}
