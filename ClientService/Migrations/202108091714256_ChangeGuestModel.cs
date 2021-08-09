namespace ClientService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGuestModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guests", "PhoneNumber", c => c.String());
            AddColumn("dbo.Guests", "Address", c => c.String());
            AddColumn("dbo.Guests", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Guests", "City");
            DropColumn("dbo.Guests", "Address");
            DropColumn("dbo.Guests", "PhoneNumber");
        }
    }
}
