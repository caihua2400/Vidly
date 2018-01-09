namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Theory in everything',CAST('2016-07-01' AS DATETIME),CAST('2017-01-01' AS DATETIME),10,4)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('Out of Wind',CAST('2011-07-01' AS DATETIME),CAST('2012-01-01' AS DATETIME),20,3)");
            Sql("INSERT INTO Movies(Name,DateAdded,ReleaseDate,NumberInStock,GenreId) VALUES('The Lover',CAST('2014-07-07' AS DATETIME),CAST('2015-11-01' AS DATETIME),15,1)");
        }
        
        public override void Down()
        {
        }
    }
}
