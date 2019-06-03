namespace MoviesRentalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIDCardNumberToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IDCardNumber", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IDCardNumber");
        }
    }
}
