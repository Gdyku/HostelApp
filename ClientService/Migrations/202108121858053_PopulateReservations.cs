namespace ClientService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateReservations : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Reservations (ReservationCode, Price, DateOfCreate, CheckInDate, CheckOutDate, Currency) VALUES( 3213, 321, '2021-02-21', '2021-04-02', '2021-04-03', 'PLN')");
            Sql("INSERT INTO Reservations (ReservationCode, Price, DateOfCreate, CheckInDate, CheckOutDate, Currency) VALUES( 3214, 500, '2021-07-07', '2021-07-08', '2021-07-12', 'PLN')");
            Sql("INSERT INTO Reservations (ReservationCode, Price, DateOfCreate, CheckInDate, CheckOutDate, Currency) VALUES( 3215, 70, '2020-11-16', '2020-12-01', '2020-12-02', 'EUR')");
            Sql("INSERT INTO Reservations (ReservationCode, Price, DateOfCreate, CheckInDate, CheckOutDate, Currency) VALUES( 3216, 440, '2021-01-15', '2021-02-20', '2021-02-24', 'USD')");
            Sql("INSERT INTO Reservations (ReservationCode, Price, DateOfCreate, CheckInDate, CheckOutDate, Currency) VALUES( 3217, 3000, '2021-02-02', '2021-03-01', '2021-03-05', 'SEK')");
        }
        
        public override void Down()
        {
        }
    }
}
