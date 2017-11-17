namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThrillerGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (Name) VALUES ('Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}
