﻿using System.Collections.Generic;
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
            new Table {Id = 100},
            new Table {Id = 101},
            new Table {Id = 102}
        };

        #endregion

        #region item constants

        public static readonly Item[] ItemsInDatabase =
        {
            new Item {Id = 1, ItemName = "Item0", SubcategoryId = 1},
            new Item {Id = 2, ItemName = "Item1", SubcategoryId = 1},
            new Item {Id = 3, ItemName = "Item2", SubcategoryId = 1}
        };

        public static readonly Item[] ItemsNotInDatabase =
        {
            new Item {Id = 100, ItemName = "Item3", SubcategoryId = 1},
            new Item {Id = 101, ItemName = "Item4", SubcategoryId = 1},
            new Item {Id = 102, ItemName = "Item5", SubcategoryId = 1}
        };

        #endregion

        #region subcategory constants

        public static readonly Subcategory[] SubcategoriesInDatabase =
        {
            new Subcategory {Id = 1, SubcategoryName = "Subcategory0", CategoryId = 1, Items = new List<Item> {ItemsInDatabase[0], ItemsInDatabase[1], ItemsInDatabase[2]}},
            new Subcategory {Id = 2, SubcategoryName = "Subcategory1", CategoryId = 1, Items = new List<Item>()},
            new Subcategory {Id = 3, SubcategoryName = "Subcategory2", CategoryId = 1, Items = new List<Item>()}
        };

        public static readonly Subcategory[] SubcategoriesNotInDatabase =
        {
            new Subcategory {Id = 100, SubcategoryName = "Subcategory3", Items = new List<Item>(), CategoryId = 1},
            new Subcategory {Id = 101, SubcategoryName = "Subcategory4", Items = new List<Item>()},
            new Subcategory {Id = 102, SubcategoryName = "Subcategory5", Items = new List<Item>()}
        };

        #endregion

        #region category constants

        public static readonly Category[] CategoriesInDatabase =
        {
            new Category {Id = 1, CategoryName = "Category0", Subcategories = new List<Subcategory> {SubcategoriesInDatabase[0], SubcategoriesInDatabase[1], SubcategoriesInDatabase[2]}},
            new Category {Id = 2, CategoryName = "Category1", Subcategories = new List<Subcategory>()},
            new Category {Id = 3, CategoryName = "Category2", Subcategories = new List<Subcategory>()}
        };

        public static readonly Category[] CategoriesNotInDatabase =
        {
            new Category {Id = 100, CategoryName = "Category3", Subcategories = new List<Subcategory>()},
            new Category {Id = 101, CategoryName = "Category4", Subcategories = new List<Subcategory>()},
            new Category {Id = 102, CategoryName = "Category5", Subcategories = new List<Subcategory>()}
        };

        #endregion
    }
}
