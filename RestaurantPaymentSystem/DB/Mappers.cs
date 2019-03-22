using RestaurantPaymentSystem.Models;

namespace RestaurantPaymentSystem.DB
{
    public static class CategoryMappers
    {
        public static void MapNewModelToExistingModel(Category category, Category existingCategory)
        {
            existingCategory.CategoryName = category.CategoryName;
        }
    }

    public static class SubcategoryMappers
    {
        public static void MapNewModelToExistingModel(Subcategory subcategory, Subcategory existingSubcategory)
        {
            existingSubcategory.SubcategoryName = subcategory.SubcategoryName;
        }
    }
}