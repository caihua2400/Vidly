namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='pay as you go' where DiscountRate=0");
            Sql("UPDATE MembershipTypes SET Name='pay monthly' where DiscountRate=10");
            Sql("UPDATE MembershipTypes SET Name='pay seasonly' where DiscountRate=15");
            Sql("UPDATE MembershipTypes SET Name='pay annually' where DiscountRate=20");
        }
        
        public override void Down()
        {
        }
    }
}
