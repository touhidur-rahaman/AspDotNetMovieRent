namespace WebApplicationVidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBirthdateOfCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
