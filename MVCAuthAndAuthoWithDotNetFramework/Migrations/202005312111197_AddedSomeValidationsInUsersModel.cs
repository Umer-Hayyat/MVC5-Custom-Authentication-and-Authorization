namespace MVCAuthAndAuthoWithDotNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSomeValidationsInUsersModel : DbMigration
    {
        public override void Up()
        {
            DropTable("public.Users");

            CreateTable(
                "public.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("public.Users");
        }
    }
}
