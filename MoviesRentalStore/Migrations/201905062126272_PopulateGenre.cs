namespace MoviesRentalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (2, 'Comedy')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (3, 'Family')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (4, 'Romance')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (5, 'Thriller')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (6, 'Fantastic')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (7, 'Drama')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (8, 'Western')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (9, 'War')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (10, 'Adventure')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (11, 'Documentary')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (12, 'Cartoon')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (13, 'TV Series')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (14, 'Biography')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (15, 'Martial Arts')");
        }
        
        public override void Down()
        {
        }
    }
}
