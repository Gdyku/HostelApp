namespace ClientService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotationsForID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReservationGuests", "Guest_ID", "dbo.Guests");
            DropForeignKey("dbo.ReservationGuests", "Reservation_ID", "dbo.Reservations");
            DropPrimaryKey("dbo.Guests");
            DropPrimaryKey("dbo.Reservations");
            AlterColumn("dbo.Guests", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Reservations", "ID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Guests", "ID");
            AddPrimaryKey("dbo.Reservations", "ID");
            AddForeignKey("dbo.ReservationGuests", "Guest_ID", "dbo.Guests", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ReservationGuests", "Reservation_ID", "dbo.Reservations", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationGuests", "Reservation_ID", "dbo.Reservations");
            DropForeignKey("dbo.ReservationGuests", "Guest_ID", "dbo.Guests");
            DropPrimaryKey("dbo.Reservations");
            DropPrimaryKey("dbo.Guests");
            AlterColumn("dbo.Reservations", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Guests", "ID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Reservations", "ID");
            AddPrimaryKey("dbo.Guests", "ID");
            AddForeignKey("dbo.ReservationGuests", "Reservation_ID", "dbo.Reservations", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ReservationGuests", "Guest_ID", "dbo.Guests", "ID", cascadeDelete: true);
        }
    }
}
