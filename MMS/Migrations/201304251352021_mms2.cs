namespace MMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mms2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "SecurityQuestion", c => c.String());
            AddColumn("dbo.UserProfile", "SecurityAnswer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfile", "SecurityAnswer");
            DropColumn("dbo.UserProfile", "SecurityQuestion");
        }
    }
}
