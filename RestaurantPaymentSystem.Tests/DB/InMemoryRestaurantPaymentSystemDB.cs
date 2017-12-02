using System.Collections.Generic;
using RestaurantPaymentSystem.DB;
using RestaurantPaymentSystem.Models;
using System;
using System.Linq;

namespace RestaurantPaymentSystem.Tests.DB
{
    class InMemoryRestaurantPaymentSystemDB : IRestaurantPaymentSystemDB
    {
        private List<TableViewModel> _tables;

        public InMemoryRestaurantPaymentSystemDB()
        {
            _tables = new List<TableViewModel>();
            foreach(TableViewModel table in Constants.tables)
            {
                _tables.Add(table);
            }
        }

        public Exception ExceptionToThrow { get; set; }

        public void CreateNewTable(TableViewModel tableViewModel)
        {
            if (ExceptionToThrow != null)
                throw ExceptionToThrow;
            _tables.Add(tableViewModel);
        }

        public void DeleteTable(int id)
        {
            _tables.Remove(GetTableByID(id));
        }

        public TableViewModel GetTableByID(int id)
        {
            return _tables.FirstOrDefault(t => t.ID == id);
        }

        public IEnumerable<TableViewModel> GetTables()
        {
            return _tables;
        }
    }
}
