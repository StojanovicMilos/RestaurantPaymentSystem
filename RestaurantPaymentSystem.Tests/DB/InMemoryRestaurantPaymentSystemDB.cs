using System.Collections.Generic;
using RestaurantPaymentSystem.DB;
using RestaurantPaymentSystem.Models;
using System;
using System.Linq;

namespace RestaurantPaymentSystem.Tests.DB
{
    class InMemoryRestaurantPaymentSystemDB : IRestaurantPaymentSystemDB
    {
        private List<Table> _tables;
        private List<Category> _categories;
        private List<Subcategory> _subcategories;

        public InMemoryRestaurantPaymentSystemDB()
        {
            _tables = new List<Table>();
            foreach(Table table in Constants.TablesInDatabase)
            {
                _tables.Add(table);
            }

            _categories = new List<Category>();
            foreach(Category category in Constants.CategoriesInDatabase)
            {
                _categories.Add(category);
            }

            _subcategories = new List<Subcategory>();
            foreach (Subcategory subcategory in Constants.SubcategoriesInDatabase)
            {
                _subcategories.Add(subcategory);
            }
        }

        public Exception ExceptionToThrow { get; set; }

        public void SaveNewCategory(Category category)
        {
            _categories.Add(category);
        }

        public void SaveExistingCategory(Category existingCategory, Category category)
        {
            CategoryMappers.MapNewModelToExistingModel(category, existingCategory);
        }

        public void SaveNewTable(Table table)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;
            _tables.Add(table);
        }

        public void DeleteCategory(Category category)
        {
            _categories.Remove(category);
        }

        public void SaveNewSubcategory(Subcategory subcategory)
        {
            _subcategories.Add(subcategory);
        }

        public void SaveExistingSubcategory(Subcategory existingSubcategory, Subcategory subcategory)
        {
            SubcategoryMappers.MapNewModelToExistingModel(subcategory, existingSubcategory);
        }

        public void DeleteSubcategory(Subcategory subcategory)
        {
            _subcategories.Remove(subcategory);
        }

        public void DeleteTable(Table table)
        {
            _tables.Remove(table);
        }

        public void Dispose()
        {

        }

        public IQueryable<Category> GetCategories()
        {
            return _categories.AsQueryable();
        }

        public Category GetCategory(int id)
        {
            return _categories.Find(c => c.Id == id);
        }

        public Table GetTable(int id)
        {
            return _tables.Find(t => t.Id == id);
        }

        IQueryable<Table> IRestaurantPaymentSystemDB.GetTables()
        {
            return _tables.AsQueryable();
        }
    }
}
