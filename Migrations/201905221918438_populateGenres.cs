﻿namespace solo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (GenreId,genreName) Values(1,'Comedy'),(2,'Action'),(3,'Family'),(4,'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
