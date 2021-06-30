namespace MVCAuthAndAuthoWithDotNetFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedUserCSToUSerDBModelCS : DbMigration
    {
        public override void Up()
        {
            DropTable("public.Users");

            CreateTable(
                "public.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("public.Users");

            CreateTable(
                "public.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
