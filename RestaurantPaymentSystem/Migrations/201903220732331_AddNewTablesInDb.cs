namespace RestaurantPaymentSystem.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTablesInDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subcategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubcategoryName = c.String(maxLength: 100),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Price = c.Int(nullable: false),
                        Subcategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subcategory", t => t.Subcategory_Id)
                .Index(t => t.Subcategory_Id);
            
            CreateTable(
                "dbo.Table",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subcategory", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Item", "Subcategory_Id", "dbo.Subcategory");
            DropIndex("dbo.Item", new[] { "Subcategory_Id" });
            DropIndex("dbo.Subcategory", new[] { "Category_Id" });
            DropTable("dbo.Table");
            DropTable("dbo.Item");
            DropTable("dbo.Subcategory");
            DropTable("dbo.Category");
        }
    }
}
