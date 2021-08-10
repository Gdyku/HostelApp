namespace ClientService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BirthDate = c.DateTime(),
                        PostalCode = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ReservationCode = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateOfCreate = c.DateTime(nullable: false),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                        Currency = c.String(nullable: false),
                        Provision = c.Int(),
                        Source = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReservationGuests",
                c => new
                    {
                        Reservation_ID = c.Long(nullable: false),
                        Guest_ID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reservation_ID, t.Guest_ID })
                .ForeignKey("dbo.Reservations", t => t.Reservation_ID, cascadeDelete: true)
                .ForeignKey("dbo.Guests", t => t.Guest_ID, cascadeDelete: true)
                .Index(t => t.Reservation_ID)
                .Index(t => t.Guest_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationGuests", "Guest_ID", "dbo.Guests");
            DropForeignKey("dbo.ReservationGuests", "Reservation_ID", "dbo.Reservations");
            DropIndex("dbo.ReservationGuests", new[] { "Guest_ID" });
            DropIndex("dbo.ReservationGuests", new[] { "Reservation_ID" });
            DropTable("dbo.ReservationGuests");
            DropTable("dbo.Reservations");
            DropTable("dbo.Guests");
        }
    }
}
