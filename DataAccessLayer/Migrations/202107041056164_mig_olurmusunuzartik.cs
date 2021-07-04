namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_olurmusunuzartik : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminUserName", c => c.Binary(maxLength: 50));
            AlterColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary(maxLength: 50));
            DropColumn("dbo.Admins", "AdminUserName");
        }
    }
}
