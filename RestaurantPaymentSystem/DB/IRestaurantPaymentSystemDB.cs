using RestaurantPaymentSystem.Models;
using System.Collections.Generic;

namespace RestaurantPaymentSystem.DB
{
    public interface IRestaurantPaymentSystemDB
    {
        IEnumerable<TableViewModel> GetTables();
        void CreateNewTable(TableViewModel tableViewModel);
        void DeleteTable(int id);
        TableViewModel GetTableByID(int id);
    }
}