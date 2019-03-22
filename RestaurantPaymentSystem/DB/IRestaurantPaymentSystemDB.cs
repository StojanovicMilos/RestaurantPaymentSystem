using RestaurantPaymentSystem.Models;
using System;
using System.Linq;

namespace RestaurantPaymentSystem.DB
{
    public interface IRestaurantPaymentSystemDB : IDisposable
    {
        IQueryable<Table> GetTables();
        Table GetTable(int id);
        void SaveNewTable(Table table);
        void DeleteTable(Table table);

        IQueryable<Category> GetCategories();
        Category GetCategory(int id);
        void SaveNewCategory(Category category);
        void SaveExistingCategory(Category existingCategory, Category category);
        void DeleteCategory(Category category);

        void SaveNewSubcategory(Subcategory model);
        void SaveExistingSubcategory(Subcategory existingSubcategory, Subcategory subcategory);
        void DeleteSubcategory(Subcategory subcategory);
    }
}