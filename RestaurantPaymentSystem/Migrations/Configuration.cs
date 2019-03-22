using System;

namespace RestaurantPaymentSystem.Migrations
{
    using DB;
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFRestaurantPaymentSystemDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        //TODO ??? FIX
        protected override void Seed(EFRestaurantPaymentSystemDB context)
        {
            //TakeDownTables(context);
            SeedTables(context);
            //TakeDownMenu(context);
            SeedMenu(context);
        }

        private void TakeDownTables(EFRestaurantPaymentSystemDB context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            foreach (var table in context.Tables)
            {
                //TODO remove orders
            }
            context.Tables.RemoveRange(context.Tables);
            context.SaveChanges();
        }

        private void SeedTables(EFRestaurantPaymentSystemDB context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            //while (context.Tables.Count() < 3)
            //{
                context.Tables.Add(new Table());
                context.Tables.Add(new Table());
                context.Tables.Add(new Table());
            //}
        }

        private void TakeDownMenu(EFRestaurantPaymentSystemDB context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            //  This method will be called after migrating to the latest version.

            context.Subcategories.RemoveRange(context.Subcategories);

            foreach (var category in context.Categories)
            {
                if (category.Subcategories != null)
                {
                    foreach (var subcategory in category.Subcategories)
                    {
                        subcategory.Items.RemoveAll(i => true);
                    }

                    category.Subcategories.RemoveAll(s => true);
                }
            }

            context.Categories.RemoveRange(context.Categories);
        }

        private static void SeedMenu(EFRestaurantPaymentSystemDB context)
        {
            context.Categories.AddOrUpdate(
                new Category
                {
                    CategoryName = "Food",
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory
                        {
                            SubcategoryName = "Soups",
                            Items = new List<Item>
                            {
                                new Item {Name = "Chicken soup", Price = 200},
                                new Item {Name = "Turkey soup", Price = 250}
                            }
                        },
                        new Subcategory
                        {
                            SubcategoryName = "Appetizers",
                            Items = new List<Item>
                            {
                                new Item {Name = "Bruschetta", Price = 100},
                                new Item {Name = "Meat appetizer", Price = 200}
                            }
                        }
                    }
                },
                new Category
                {
                    CategoryName = "Drinks",
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory
                        {
                            SubcategoryName = "non-alcoholic drinks",
                            Items = new List<Item>
                            {
                                new Item {Name = "Coca-Cola", Price = 150},
                                new Item {Name = "Sprite", Price = 150}
                            }
                        },
                        new Subcategory
                        {
                            SubcategoryName = "alcoholic drinks",
                            Items = new List<Item>
                            {
                                new Item {Name = "Beer", Price = 150},
                                new Item {Name = "Wine", Price = 300}
                            }
                        }
                    }
                }
            );

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.E.g.

            //context.People.AddOrUpdate(
            //  p => p.FullName,
            //  new Person { FullName = "Andrew Peters" },
            //  new Person { FullName = "Brice Lambson" },
            //  new Person { FullName = "Rowan Miller" }
            //);

        }
    }
}
