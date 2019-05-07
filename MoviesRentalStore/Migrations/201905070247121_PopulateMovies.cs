namespace MoviesRentalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql($"INSERT INTO Movies(Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable)" +
                $" VALUES('Cold Pursuit', 1, '07-05-2019', '02-27-2019', 10, 8)");
            Sql($"INSERT INTO Movies(Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable)" +
                $" VALUES('The Upside - Second Chance', 2, '07-05-2019', '04-18-2019', 12, 10)");
            Sql($"INSERT INTO Movies(Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable)" +
                $" VALUES('Avengers: Endgame', 6, '07-05-2019', '04-24-2019', 8, 7)");
            Sql($"INSERT INTO Movies(Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable)" +
                $" VALUES('Miss Bala', 7, '04-07-2019', '02-01-2019', 14, 11)");
            Sql($"INSERT INTO Movies(Name, GenreId, DateAdded, ReleaseDate, NumberInStock, NumberAvailable)" +
                $" VALUES('Hunter Killer', 5, '03-15-2019', '12-12-2018', 9, 5)");
        }
        
        public override void Down()
        {
        }
    }
}
