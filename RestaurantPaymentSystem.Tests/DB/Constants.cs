using RestaurantPaymentSystem.Models;

namespace RestaurantPaymentSystem.Tests.DB
{
    public static class Constants
    {
        #region table constants
        public static readonly Table[] TablesInDatabase =
        {
            new Table {Id = 1},
            new Table {Id = 2},
            new Table {Id = 3}
        };

        public static readonly Table[] TablesNotInDatabase =
        {
            new Table { Id = 100 },
            new Table { Id = 101 },
            new Table { Id = 102 }
        };
        #endregion

        #region category constants
        public static readonly Category[] CategoriesInDatabase =
        {
            new Category {Id = 1, CategoryName = "Category0"},
            new Category {Id = 2, CategoryName = "Category1"},
            new Category {Id = 3, CategoryName = "Category2"}
        };

        public static readonly Category[] CategoriesNotInDatabase =
        {
            new Category { Id = 100, CategoryName = "Category3"},
            new Category { Id = 101, CategoryName = "Category4"},
            new Category { Id = 102, CategoryName = "Category5"}
        };

        #endregion

        #region subcategory constants

        public static readonly Subcategory[] SubcategoriesInDatabase =
        {
            new Subcategory {Id = 1, SubcategoryName = "Subcategory0"},
            new Subcategory {Id = 2, SubcategoryName = "Subcategory1"},
            new Subcategory {Id = 3, SubcategoryName = "Subcategory2"}
        };

        public static readonly Subcategory[] SubcategoriesNotInDatabase =
        {
            new Subcategory {Id = 100, SubcategoryName = "Subcategory3"},
            new Subcategory {Id = 101, SubcategoryName = "Subcategory4"},
            new Subcategory {Id = 102, SubcategoryName = "Subcategory5"}
        };

        #endregion

    }
}
