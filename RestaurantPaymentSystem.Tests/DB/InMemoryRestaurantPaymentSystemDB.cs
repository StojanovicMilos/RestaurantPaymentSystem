using System.Collections.Generic;
using RestaurantPaymentSystem.DB;
using RestaurantPaymentSystem.Models;
using System;
using System.Linq;

namespace RestaurantPaymentSystem.Tests.DB
{
    class InMemoryRestaurantPaymentSystemDb : IRestaurantPaymentSystemDb
    {
        private readonly List<Table> _tables;
        private readonly List<Category> _categories;
        private readonly List<Subcategory> _subcategories;
        private readonly List<Item> _items;

        public InMemoryRestaurantPaymentSystemDb()
        {
            _tables = new List<Table>();
            _tables.AddRange(Constants.TablesInDatabase);

            _categories = new List<Category>();
            _categories.AddRange(Constants.CategoriesInDatabase);

            _subcategories = new List<Subcategory>();
            _subcategories.AddRange(Constants.SubcategoriesInDatabase);

            _items = new List<Item>();
            _items.AddRange(Constants.ItemsInDatabase);
        }

        public Exception ExceptionToThrow { get; set; }

        public void SaveNewCategory(Category category) => _categories.Add(category);

        public void SaveExistingCategory(Category existingCategory, Category category) => CategoryMappers.MapNewModelToExistingModel(category, existingCategory);

        public void SaveNewTable(Table table)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;
            _tables.Add(table);
        }

        public void DeleteCategory(Category category) => _categories.Remove(category);

        public Subcategory GetSubcategory(int id) => _subcategories.Find(s => s.Id == id);

        public void SaveNewSubcategory(Subcategory subcategory)
        {
            var category = GetCategory(subcategory.CategoryId);
            category.Subcategories.Add(subcategory);
            _subcategories.Add(subcategory);
        }

        public void SaveExistingSubcategory(Subcategory existingSubcategory, Subcategory subcategory) => SubcategoryMappers.MapNewModelToExistingModel(subcategory, existingSubcategory);

        public void DeleteSubcategory(Subcategory subcategory)
        {
            var category = GetCategory(subcategory.CategoryId);
            category.Subcategories.Remove(subcategory);
            _subcategories.Remove(subcategory);
        }

        public void DeleteTable(Table table) => _tables.Remove(table);

        public void Dispose()
        {

        }

        public IQueryable<Category> GetCategories() => _categories.AsQueryable();

        public Category GetCategory(int id) => _categories.Find(c => c.Id == id);

        public Table GetTable(int id) => _tables.Find(t => t.Id == id);

        IQueryable<Table> IRestaurantPaymentSystemDb.GetTables() => _tables.AsQueryable();

        public Item GetItem(int id) => _items.Find(i => i.Id == id);

        public void SaveNewItem(Item item)
        {
            var subcategory = GetSubcategory(item.SubcategoryId);
            subcategory.Items.Add(item);
            _items.Add(item);
        }

        public void SaveExistingItem(Item existingItem, Item item) => ItemMappers.MapNewModelToExistingModel(existingItem, item);

        public void DeleteItem(Item item)
        {
            var subcategory = GetSubcategory(item.SubcategoryId);
            subcategory.Items.Remove(item);
            _items.Remove(item);
        }
    }
}
