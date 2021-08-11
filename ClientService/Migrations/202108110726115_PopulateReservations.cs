namespace ClientService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateReservations : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Reservations (ReservationCode, Price, DateOfCreate, CheckInDate, CheckOutDate, Currency) VALUES( 3213, 420, '2021-04-20T00:00:00', '2021-05-02T00:00:00', '2021-05-05T00:00:00', 'PLN')");
            Sql("INSERT INTO Reservations (ReservationCode, Price, DateOfCreate, CheckInDate, CheckOutDate, Currency) VALUES( 3213, 321, '2021-02-21T00:00:00', '2021-04-02T00:00:00', '2021-04-03T00:00:00', 'PLN')");
            Sql("INSERT INTO Reservations (ReservationCode, Price, DateOfCreate, CheckInDate, CheckOutDate, Currency) VALUES( 3214, 500, '2021-07-07T00:00:00', '2021-07-08T00:00:00', '2021-07-12T00:00:00', 'PLN')");
            Sql("INSERT INTO Reservations (ReservationCode, Price, DateOfCreate, CheckInDate, CheckOutDate, Currency) VALUES( 3215, 70, '2020-11-16T00:00:00', '2020-12-01T00:00:00', '2020-12-02T00:00:00', 'EUR')");
            Sql("INSERT INTO Reservations (ReservationCode, Price, DateOfCreate, CheckInDate, CheckOutDate, Currency) VALUES( 3216, 440, '2021-01-15T00:00:00', '2021-02-20T00:00:00', '2021-02-24T00:00:00', 'USD')");
        }

        public override void Down()
        {
        }
    }
}
