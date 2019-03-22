﻿using System.Collections;
using RestaurantPaymentSystem.Models;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RestaurantPaymentSystem.DB
{
    public class EFRestaurantPaymentSystemDB : DbContext, IRestaurantPaymentSystemDB
    {
        public DbSet<Table> Tables { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }

        //private StreamReader _reader;
        //private StreamWriter _writer;
        private string _previousLog = string.Empty;
        //private const string databaseLogFile = @"D:\DatabaseLog.txt";

        protected override void OnModelCreating(DbModelBuilder modelBuilder) =>
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        public EFRestaurantPaymentSystemDB() : base("RestaurantPaymentSystemDB")
        {
            //https://stackoverflow.com/questions/5949607/console-output-from-web-applications-in-visual-studio
            //https://docs.microsoft.com/en-us/ef/ef6/fundamentals/logging-and-interception
            //if (File.Exists(databaseLogFile))
            //{
            //    _reader = new StreamReader(databaseLogFile);
            //    _previousLog = _reader.ReadToEnd();
            //    _reader.Close();
            //}
            //_writer = new StreamWriter(databaseLogFile);
            //if (_previousLog != string.Empty)
            //{
            //    _writer.Write(_previousLog);
            //}
            //this.Database.Log = _writer.WriteLine;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            //_writer.Close();
        }

        public void SaveNewTable(Table table)
        {
            Tables.Add(table);
            SaveChanges();
        }

        public void DeleteTable(Table table)
        {
            Tables.Remove(table);
            SaveChanges();
        }

        public Table GetTable(int id)
        {
            return Tables.Find(id);
        }

        public IQueryable<Table> GetTables()
        {
            return Tables.AsQueryable();
        }

        public IQueryable<Category> GetCategories()
        {
            return Categories.AsQueryable();
        }

        public void SaveNewCategory(Category category)
        {
            Categories.Add(category);
            SaveChanges();
        }

        //??? TODO write more tests
        public void SaveExistingCategory(Category existingCategory, Category category)
        {
            CategoryMappers.MapNewModelToExistingModel(category, existingCategory);
            SaveChanges();
        }

        public Category GetCategory(int id)
        {
            return Categories.Find(id);
        }

        public void DeleteCategory(Category category)
        {
            Categories.Remove(category);
            SaveChanges();
        }

        public void SaveNewSubcategory(Subcategory model)
        {
            Subcategories.Add(model);
            SaveChanges();
        }

        public void SaveExistingSubcategory(Subcategory existingSubcategory, Subcategory subcategory)
        {
            SubcategoryMappers.MapNewModelToExistingModel(subcategory, existingSubcategory);
            SaveChanges();
        }

        public void DeleteSubcategory(Subcategory subcategory)
        {
            Subcategories.Remove(subcategory);
            SaveChanges();
        }
    }
}