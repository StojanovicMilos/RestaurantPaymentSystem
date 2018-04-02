using RestaurantPaymentSystem.Controllers;
using RestaurantPaymentSystem.Tests.DB;

namespace RestaurantPaymentSystem.Tests.Controllers
{
    public static class ControllerFactory
    {
        public static TableController GetTableController()
        {
            return new TableController(new InMemoryRestaurantPaymentSystemDB());
        }
    }
}
