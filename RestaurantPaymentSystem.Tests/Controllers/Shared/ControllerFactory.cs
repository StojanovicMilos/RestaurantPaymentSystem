using RestaurantPaymentSystem.Controllers;
using RestaurantPaymentSystem.Controllers.Menu;
using RestaurantPaymentSystem.Tests.DB;

namespace RestaurantPaymentSystem.Tests.Controllers.Shared
{
    public static class ControllerFactory
    {
        public static TableController GetTableController() => new TableController(new InMemoryRestaurantPaymentSystemDb());

        public static CategoryController GetCategoryController() => new CategoryController(new InMemoryRestaurantPaymentSystemDb());

        public static SubcategoryController GetSubcategoryController() => new SubcategoryController(new InMemoryRestaurantPaymentSystemDb());

        public static ItemController GetItemController() => new ItemController(new InMemoryRestaurantPaymentSystemDb());
    }
}
