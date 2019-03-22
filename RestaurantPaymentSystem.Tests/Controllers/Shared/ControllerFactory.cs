using System;
using RestaurantPaymentSystem.Controllers;
using RestaurantPaymentSystem.Controllers.Menu;
using RestaurantPaymentSystem.DB;
using RestaurantPaymentSystem.Tests.DB;

namespace RestaurantPaymentSystem.Tests.Controllers
{
    public static class ControllerFactory
    {
        public static TableController GetTableController()
        {
            return new TableController(new InMemoryRestaurantPaymentSystemDb());
        }

        public static CategoryController GetCategoryController()
        {
            //TODO UNDO!!! ???
            return new CategoryController(new InMemoryRestaurantPaymentSystemDb());
        }

        public static SubcategoryController GetSubcategoryController()
        {
            return new SubcategoryController(new InMemoryRestaurantPaymentSystemDb());
        }
    }
}
