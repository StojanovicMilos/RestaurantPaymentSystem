using RestaurantPaymentSystem.Models;

namespace RestaurantPaymentSystem.Tests.DB
{
    class Constants
    {
        public static readonly TableViewModel[] tables =
        {
            new TableViewModel {ID = 1},
            new TableViewModel {ID = 2},
            new TableViewModel {ID = 3}
        };

        public static readonly TableViewModel table4 = new TableViewModel { ID = 4 };
        public static readonly TableViewModel table5 = new TableViewModel { ID = 5 };
        public static readonly TableViewModel table6 = new TableViewModel { ID = 6 };
    }
}
