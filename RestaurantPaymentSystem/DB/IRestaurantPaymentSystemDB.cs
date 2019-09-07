using RestaurantPaymentSystem.Models;
using System;
using System.Linq;

namespace RestaurantPaymentSystem.DB
{
    public interface IRestaurantPaymentSystemDb : IDisposable
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

        Subcategory GetSubcategory(int id);
        void SaveNewSubcategory(Subcategory model);
        void SaveExistingSubcategory(Subcategory existingSubcategory, Subcategory subcategory);
        void DeleteSubcategory(Subcategory subcategory);

        Item GetItem(int id);
        void SaveNewItem(Item model);
        void SaveExistingItem(Item existingItem, Item item);
        void DeleteItem(Item item);
    }
}