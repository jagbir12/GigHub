namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namechangeofGenrefieldingig : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Gigs", name: "MyProperty_Id", newName: "Genre_Id");
            RenameIndex(table: "dbo.Gigs", name: "IX_MyProperty_Id", newName: "IX_Genre_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Gigs", name: "IX_Genre_Id", newName: "IX_MyProperty_Id");
            RenameColumn(table: "dbo.Gigs", name: "Genre_Id", newName: "MyProperty_Id");
        }
    }
}
