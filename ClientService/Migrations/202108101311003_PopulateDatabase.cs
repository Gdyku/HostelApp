namespace ClientService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Guests (Name, Surname, Email) VALUES('Taco', 'Hemingway', 'Quesadilla@gmail.com')");
            Sql("INSERT INTO Guests (Name, Surname, Email) VALUES('Piotr', 'Rogucki', 'Roguc@gmail.com')");
            Sql("INSERT INTO Guests (Name, Surname, Email, City) VALUES('Monika', 'Brodka', 'BrodataMonika@gmail.com', 'Wrocław')");
            Sql("INSERT INTO Guests (Name, Surname, Email, City) VALUES('Piotr', 'Łuszcz', 'K44@gmail.com', 'Katowice')");
            Sql("INSERT INTO Guests (Name, Surname, Email) VALUES('Agnieszka', 'Chylińska', 'Chyly@gmail.com')");
            Sql("INSERT INTO Guests (Name, Surname, Email) VALUES('Kanye', 'West', 'Kwest@gmail.com')");
        }
        
        public override void Down()
        {
            
        }
    }
}
