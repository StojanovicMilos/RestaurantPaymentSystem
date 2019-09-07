namespace RestaurantPaymentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameItemNameAndAddSubcategoryIdToItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "Subcategory_Id", "dbo.Subcategory");
            DropIndex("dbo.Item", new[] { "Subcategory_Id" });
            RenameColumn(table: "dbo.Item", name: "Subcategory_Id", newName: "SubcategoryId");
            AddColumn("dbo.Item", "ItemName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Item", "SubcategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Item", "SubcategoryId");
            AddForeignKey("dbo.Item", "SubcategoryId", "dbo.Subcategory", "Id", cascadeDelete: true);
            DropColumn("dbo.Item", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "Name", c => c.String(maxLength: 100));
            DropForeignKey("dbo.Item", "SubcategoryId", "dbo.Subcategory");
            DropIndex("dbo.Item", new[] { "SubcategoryId" });
            AlterColumn("dbo.Item", "SubcategoryId", c => c.Int());
            DropColumn("dbo.Item", "ItemName");
            RenameColumn(table: "dbo.Item", name: "SubcategoryId", newName: "Subcategory_Id");
            CreateIndex("dbo.Item", "Subcategory_Id");
            AddForeignKey("dbo.Item", "Subcategory_Id", "dbo.Subcategory", "Id");
        }
    }
}
