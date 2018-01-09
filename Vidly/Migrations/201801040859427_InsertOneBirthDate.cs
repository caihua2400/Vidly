namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertOneBirthDate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate='2007-05-08' where Id=1");
        }
        
        public override void Down()
        {
        }
    }
}
