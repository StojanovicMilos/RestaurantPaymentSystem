using RestaurantPaymentSystem.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantPaymentSystem.DB
{
    public class EFRestaurantPaymentSystemDB : DbContext, IRestaurantPaymentSystemDB
    {
        public DbSet<TableViewModel> Tables { get; set; }

        public EFRestaurantPaymentSystemDB() : base("RestaurantPaymentSystemDB")
        {

        }

        public void CreateNewTable(TableViewModel tableViewModel)
        {
            Tables.Add(tableViewModel);
            SaveChanges();
        }

        public void DeleteTable(int id)
        {
            Tables.Remove(GetTableByID(id));
            SaveChanges();
        }

        public TableViewModel GetTableByID(int id)
        {
            return Tables.FirstOrDefault(t => t.ID == id);
        }

        public IEnumerable<TableViewModel> GetTables()
        {
            return Tables.ToList();
        }
    }
}