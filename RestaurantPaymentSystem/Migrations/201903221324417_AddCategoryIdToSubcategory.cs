namespace RestaurantPaymentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryIdToSubcategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subcategory", "Category_Id", "dbo.Category");
            DropIndex("dbo.Subcategory", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Subcategory", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.Subcategory", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subcategory", "CategoryId");
            AddForeignKey("dbo.Subcategory", "CategoryId", "dbo.Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subcategory", "CategoryId", "dbo.Category");
            DropIndex("dbo.Subcategory", new[] { "CategoryId" });
            AlterColumn("dbo.Subcategory", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Subcategory", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Subcategory", "Category_Id");
            AddForeignKey("dbo.Subcategory", "Category_Id", "dbo.Category", "Id");
        }
    }
}
