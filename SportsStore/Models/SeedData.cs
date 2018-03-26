using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsureOrdersPopulated(IServiceProvider services)
        {
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
            int orderCount = context.Orders.Where(p => (p.Shipped == true)).Count();
            IQueryable<Product> products = context.Products.OrderBy(p => p.Price);
            int productCount = products.Count();
            List<ProductProbability> allCategoryProducts = productProbabilityTable(context, null, true);

            if (orderCount < 100)
            {
                Random rand = new Random();

                for (int idx = 0; idx < 1000; idx++)
                {
                    List<ProductProbability> inCategoryProducts = null;
                    List<ProductProbability> nonCategoryProducts = null;
                    List<CartLine> orderLines = new List<CartLine>();

                    Order newOrder = new Order
                    {
                        Shipped = true,
                        Name = "Tom Scheiber",
                        Line1 = "5031 Wesely Dr.",
                        City = "Tampa",
                        State = "FL",
                        Zip = "33647",
                        Country = "USA",
                        GiftWrap = false
                    };

                    double probability = 1;
                    for (int ordCount = 0; ordCount < 5; ordCount++)
                    {
                        if (rand.NextDouble() < probability)
                        {
                            Product nextProduct = getNextProduct(allCategoryProducts,
                                                                 inCategoryProducts,
                                                                 nonCategoryProducts,
                                                                 rand);
                            orderLines.Add(new CartLine
                            {
                                Product = nextProduct,
                                Quantity = rand.Next(1, 3)
                            });
                            if (null == inCategoryProducts)
                            {
                                inCategoryProducts = productProbabilityTable(context, nextProduct.Category, true);
                                nonCategoryProducts = productProbabilityTable(context, nextProduct.Category, false);
                            }
                        }
                        else
                        {
                            break;
                        }
                        probability = probability / 2;
                    }
                    newOrder.Lines = orderLines;
                    context.Orders.AddRange(newOrder);
                }
                context.SaveChanges();

            }

        }

        /*
         * used to store products with their cumulative probability
         * */
        public struct ProductProbability
        {
            public Product Product;
            public double CumulativeProbability;
        }

        /*
         * private static List<ProductProbability> productProbabilityTable
         * 
         * Creates a list of ProductProbability structs to be used to assess
         *   likelhood of a particular product showing up in the next order slot
         */
        private static List<ProductProbability> productProbabilityTable(ApplicationDbContext context
                                                                        , string forCategory
                                                                        , bool includeCategory)
        {
            // get the product list
            IQueryable<Product> products = null;
            if (null == forCategory)
            {
                products = context.Products.OrderBy(p => p.Price);
            }
            else if (includeCategory)
            {
                products = context.Products.Where(p => (p.Category == forCategory)).OrderBy(p => p.Price);
            }
            else
            {
                products = context.Products.Where(p => p.Category != forCategory).OrderBy(p => p.Price);
            }

            // assign cumulative probabilities to the product list
            List<ProductProbability> probabilityList = new List<ProductProbability>(products.Count());
            double opportunities = Math.Pow(2.0, products.Count() + 1) - 2;
            double cumulativeProbability = 0;
            int currentIndex = 0;
            foreach (Product product in products)
            {
                cumulativeProbability = cumulativeProbability
                    + (Math.Pow(2, products.Count() - currentIndex) / opportunities);
                probabilityList.Add(new ProductProbability
                {
                    Product = product,
                    CumulativeProbability = cumulativeProbability
                });
                currentIndex++;
            }
            return probabilityList;
        }

        /*
         * private Product getNextProduct(List<ProductProbability> allCategory
         *                              , List<ProductProbability> inCategory
         *                              , List<ProductProbability> nonCategory
         *                              , Random rand)
         *
         * Determines which is the next product to add to the order.
         * 
         * if 'inCategory is null, adds from total list
         * otherwise, 90% come from inCategory, 10% from non-category
         * 
         * Product is chosen from list based on cumulative % likelihood
         *   calculate when the list is created.
         */
        private static Product getNextProduct(List<ProductProbability> allCategory
                                       , List<ProductProbability> inCategory
                                       , List<ProductProbability> nonCategory
                                       , Random rand)
        {
            Product nextProduct = null;
            if (null == inCategory) /* if first product, choose from entire list */
            {
                nextProduct = chooseProduct(allCategory, false, rand);
            }
            else if (rand.NextDouble() <= 0.9) /* 90% is in same category */
            {
                nextProduct = chooseProduct(inCategory, true, rand);
            }
            else /* last 10% are from the non-category product */
            {
                nextProduct = chooseProduct(nonCategory, true, rand);
            }
            return nextProduct;
        }

        /*
         * chooseProduct(List<ProductProbability> productProbabilities, Random rand)
         * 
         * Choose from the list of products based on a randome number generated
         */
        private static Product chooseProduct(
            List<ProductProbability> productProbabilities
            , bool removeWhenChosen
            , Random rand)
        {
            double probability = rand.NextDouble();
            Product chosenProduct = null;
            foreach (ProductProbability candidateProbability in productProbabilities)
            {
                if (candidateProbability.CumulativeProbability >= probability)
                {
                    chosenProduct = candidateProbability.Product;
                    if (removeWhenChosen) { productProbabilities.Remove(candidateProbability); }
                    break;
                }
            }
            return chosenProduct;
        }

        /*
         * public static void EnsurePopulated(IServiceProvider services)
         * 
         * If not data, populates the Product table
         */
        public static void EnsurePopulated(IServiceProvider services)
        {
            ApplicationDbContext context =
            services.GetRequiredService<ApplicationDbContext>();
            //context.Database.Migrate();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    // water sports
                    new Product
                    {
                        Name = "Kayak", Description = "A boat for one person",
                        Category = "Watersports", Price = 275
                    },
                    new Product
                    {
                        Name = "Lifejacket",
                        Description = "Protective and fashionable",
                        Category = "Watersports", Price = 48.95m
                    },
                    new Product
                    {
                        Name = "Swimsuit, Mens",
                        Description = "Speedo!",
                        Category = "Watersports", Price = 32.32m
                    },
                    new Product
                    {
                        Name = "Swimsuit, Women's",
                        Description = "Tyr!",
                        Category = "Watersports", Price = 56.40m
                    },
                    new Product
                    {
                        Name = "Paddle",
                        Description = "Every Kayack needs one",
                        Category = "Watersports", Price = 500
                    },
                    new Product
                    {
                        Name = "Water Wings",
                        Description = "You know you are afraid of water",
                        Category = "Watersports", Price = 9.50m
                    },

                    // soccer
                    new Product
                    {
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and weight",
                        Category = "Soccer", Price = 19.50m
                    },
                    new Product
                    {
                        Name = "Corner Flags",
                        Description = "Give your playing field a professional touch",
                        Category = "Soccer", Price = 34.95m
                    },
                    new Product
                    {
                        Name = "Stadium",
                        Description = "Flat-packed 35,000-seat stadium",
                        Category = "Soccer", Price = 79500
                    },
                    new Product
                    {
                        Name = "Stadium Seat",
                        Description = "Gonna nickle and dime you",
                        Category = "Soccer", Price = 275
                    },
                    new Product
                    {
                        Name = "Turf Paint",
                        Description = "5 teams will use this stadium",
                        Category = "Soccer", Price = 88
                    },
                    new Product
                    {
                        Name = "Fake Bandages",
                        Description = "Faking is a critical soccer skill",
                        Category = "Soccer", Price = 4
                    },

                    // chess
                    new Product
                    {
                        Name = "Thinking Cap",
                        Description = "Improve brain efficiency by 75%",
                        Category = "Chess", Price = 16
                    },
                    new Product
                    {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent a disadvantage",
                        Category = "Chess", Price = 29.95m
                    },
                    new Product
                    {
                        Name = "Human Chess Board",
                        Description = "A fun game for the family",
                        Category = "Chess", Price = 75
                    },
                    new Product
                    {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded King",
                        Category = "Chess", Price = 1200
                },
                    new Product
                    {
                        Name = "Timer",
                        Description = "Tick-tock",
                        Category = "Chess", Price = 40
                },
                    new Product
                    {
                        Name = "Paper Towels",
                        Description = "Keep hands dry",
                        Category = "Chess", Price = 2
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
