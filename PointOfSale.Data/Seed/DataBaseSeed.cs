using Microsoft.EntityFrameworkCore;
using PointOfSale.Data.Entities.Models;
using PointOfSale.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Data.Seed
{
    public static class DataBaseSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Inventory>()
                .HasData(new List<Inventory>
                {
                    new Inventory
                    {
                        Id = 1,
                        OfferType = OfferType.Item,
                        Name = "cake",
                        Quantity = 20
                    },
                    new Inventory
                    {
                        Id = 2,
                        OfferType = OfferType.Item,
                        Name = "TV",
                        Quantity = 12
                    },
                    new Inventory
                    {
                        Id = 3,
                        OfferType = OfferType.Item,
                        Name = "laptop",
                        Quantity = 10
                    },
                    new Inventory
                    {
                        Id = 4,
                        OfferType = OfferType.Item,
                        Name = "shampoo",
                        Quantity = 50
                    }
                });

            builder.Entity<Employee>()
                .HasData(new List<Employee>
                {
                    new Employee
                    {
                        Id = 1,
                        FirstName = "Mate",
                        LastName = "Matić",
                        EmployeeID = "28903610827",
                        WeeklyWorkingHours = 50
                    },
                    new Employee
                    {
                        Id = 2,
                        FirstName = "Ivan",
                        LastName = "Ivanić",
                        EmployeeID = "10927489362",
                        WeeklyWorkingHours = 25
                    },
                    new Employee
                    {
                        Id = 3,
                        FirstName = "Duje",
                        LastName = "Dujić",
                        EmployeeID = "90367890251",
                        WeeklyWorkingHours = 45
                    }
                });

            builder.Entity<Customer>()
                .HasData(new List<Customer>
                {
                    new Customer
                    {
                        Id = 1,
                        FirstName = "Ante",
                        LastName = "Antić",
                        CustomerID = "62783190283"
                    },
                    new Customer
                    {
                        Id = 2,
                        FirstName = "Josip",
                        LastName = "Josipić",
                        CustomerID = "092836784921"
                    },
                    new Customer
                    {
                        Id = 3,
                        FirstName = "Marko",
                        LastName = "Markić",
                        CustomerID = "98368109372"
                    },
                });

            builder.Entity<Category>()
                .HasData(new List<Category>
                {
                    new Category
                    {
                        Id = 1,
                        NameOfCategory = "food"
                    },
                    new Category
                    {
                        Id = 2,
                        NameOfCategory = "hygiene"
                    },
                    new Category
                    {
                        Id = 3,
                        NameOfCategory = "electronics"
                    }
                });

            builder.Entity<Offer>()
               .HasData(new List<Offer>
               {
                   new Offer
                   {
                       Id = 1,
                       OfferType = OfferType.Item
                   },
                   new Offer
                   {
                       Id = 2,
                       OfferType = OfferType.Item
                   },
                   new Offer
                   {
                       Id = 3,
                       OfferType = OfferType.Item
                   },
                   new Offer
                   {
                       Id = 4,
                       OfferType = OfferType.Service
                   },
                   new Offer
                   {
                       Id = 5,
                       OfferType = OfferType.Service
                   },
                   new Offer
                   {
                       Id = 6,
                       OfferType = OfferType.Service
                   },
                   new Offer
                   {
                       Id = 7,
                       OfferType = OfferType.Rent
                   },
                   new Offer
                   {
                       Id = 8,
                       OfferType = OfferType.Rent
                   },
                   new Offer
                   {
                       Id = 9,
                       OfferType = OfferType.Rent
                   }
               });

           builder.Entity<OfferCategory>()
               .HasData(new List<OfferCategory>
               {
                   new OfferCategory
                   {
                       Id = 1,
                       CategoryId = 1,
                       OfferId = 1
                   },
                   new OfferCategory
                   {
                       Id = 2,
                       CategoryId = 1,
                       OfferId = 4
                   },
                   new OfferCategory
                   {
                       Id = 3,
                       CategoryId = 1,
                       OfferId = 7
                   },
                    new OfferCategory
                   {
                       Id = 4,
                       CategoryId = 2,
                       OfferId = 2
                   },
                   new OfferCategory
                   {
                       Id = 5,
                       CategoryId = 2,
                       OfferId = 5
                   },
                   new OfferCategory
                   {
                       Id = 6,
                       CategoryId = 2,
                       OfferId = 8
                   },
                    new OfferCategory
                   {
                        Id = 7,
                       CategoryId = 3,
                       OfferId = 3
                   },
                   new OfferCategory
                   {
                       Id = 8,
                       CategoryId = 3,
                       OfferId = 6
                   },
                   new OfferCategory
                   {
                       Id = 9,
                       CategoryId = 3,
                       OfferId = 9
                   }
               });

            builder.Entity<Item>()
               .HasData(new List<Item>
               {
                   new Item
                   { 
                       Id = 1,
                       OfferId = 1,
                       Name = "cake",
                       Price = 25m,
                       Quantity = 1
                   },
                   new Item
                   {
                       Id = 2,
                       OfferId = 2,
                       Name = "TV",
                       Price = 25m,
                       Quantity = 1
                   },
                   new Item
                   {
                       Id = 3,
                       OfferId = 3,
                       Name = "shampoo",
                       Price = 25m,
                       Quantity = 1
                   }
               });

            builder.Entity<Service>()
               .HasData(new List<Service>
               {
                   new Service
                   {
                       Id = 1,
                       OfferId = 4,
                       Name = "Dinner by professional chef",
                       PricePerHour = 500m,
                       ScheduledOn = new DateTime(2021, 1, 10, 20, 30, 0)
                   },
                   new Service
                   {
                       Id = 2,
                       OfferId = 5,
                       Name = "Cleaning toilets",
                       PricePerHour = 120m,
                       ScheduledOn = new DateTime(2021, 1, 1, 13, 20, 0)
                   },
                   new Service
                   {
                       Id = 3,
                       OfferId = 6,
                       Name = "Fixing laptop",
                       PricePerHour = 355m,
                       ScheduledOn = new DateTime(2021, 1, 30, 15, 0, 0)
                   }
               });

            builder.Entity<Rent>()
               .HasData(new List<Rent>
               {
                   new Rent
                   {
                       Id = 1,
                       OfferId = 7,
                       Name = "Rent professional kitchen",
                       PricePerHour = 80m,
                       StartOfRent = new DateTime(2021, 1, 3, 11, 30, 0),
                       EndOfRent = new DateTime(2021, 1, 3, 14, 0, 0)
                   },
                   new Rent
                   {
                       Id = 2,
                       OfferId = 8,
                       Name = "Rent washing machine",
                       PricePerHour = 30m,
                       StartOfRent = new DateTime(2021, 1, 28, 21, 30, 0),
                       EndOfRent = new DateTime(2021, 1, 28, 23, 45, 0)
                   },
                   new Rent
                   {
                       Id = 3,
                       OfferId = 9,
                       Name = "Rent computer",
                       PricePerHour = 25m,
                       StartOfRent = new DateTime(2021, 2, 10, 13, 30, 0),
                       EndOfRent = new DateTime(2021, 2, 10, 16, 0, 0)
                   }
               });

            builder.Entity<Bill>()
               .HasData(new List<Bill>
               {
                   new Bill
                   {
                      Id = 1,
                      BillType = TypeOfBill.Traditional,
                      TotalPrice = 25,
                      isCancelled = false,
                      PurchasedOn = DateTime.Now
                   },
                   new Bill
                   {
                       Id = 2,
                       BillType = TypeOfBill.Traditional,
                       TotalPrice = 1500,
                       isCancelled = false,
                       PurchasedOn = new DateTime(2021, 1, 7, 12, 45, 0)
                   },
                   new Bill
                   {
                       Id = 3,
                       BillType = TypeOfBill.Traditional,
                       TotalPrice = 5,
                       isCancelled = false,
                       PurchasedOn = new DateTime(2021, 1, 3, 9, 35, 0)
                   },
                   new Bill
                   {
                       Id = 4,
                       BillType = TypeOfBill.Service,
                       TotalPrice = 1000,
                       isCancelled = false,
                       PurchasedOn = new DateTime(2021, 1, 9, 15, 0, 0)
                   },
                   new Bill
                   {
                       Id = 5,
                       BillType = TypeOfBill.Service,
                       TotalPrice = 180,
                       isCancelled = false,
                       PurchasedOn = new DateTime(2020, 12, 28, 17, 30, 0)
                   },
                   new Bill
                   {
                       Id = 6,
                       BillType = TypeOfBill.Service,
                       TotalPrice = 710,
                       isCancelled = false,
                       PurchasedOn = DateTime.Now,
                   },
                   new Bill
                   {
                       Id = 7,
                       BillType = TypeOfBill.Subscription,
                       TotalPrice = 200,
                       isCancelled = false,
                       PurchasedOn = new DateTime(2021, 1, 2, 17, 45, 0)
                   },
                   new Bill
                   {
                       Id = 8,
                       BillType = TypeOfBill.Subscription,
                       TotalPrice = 67.5m,
                       isCancelled = false,
                       PurchasedOn = new DateTime(2021, 1, 5, 13, 25, 0)
                   },
                   new Bill
                   {
                       Id = 9,
                       BillType = TypeOfBill.Subscription,
                       TotalPrice = 62.5m,
                       isCancelled = false,
                       PurchasedOn = new DateTime(2021, 1, 18, 12, 45, 0)
                   }
               });

            builder.Entity<TraditionalBill>()
               .HasData(new List<TraditionalBill>
               {
                   new TraditionalBill
                   {
                       Id = 1,
                       OfferId = 1,
                       BillId = 1
                   },
                   new TraditionalBill
                   {
                       Id = 2,
                       OfferId = 2,
                       BillId = 2
                   },
                   new TraditionalBill
                   {
                       Id = 3,
                       OfferId = 3,
                       BillId = 3
                   }
               });

            builder.Entity<ServiceBill>()
               .HasData(new List<ServiceBill>
               {
                   new ServiceBill
                   {
                       Id = 1,
                       OfferId = 4,
                       BillId = 4,
                       EmployeeId = 1
                   },
                   new ServiceBill
                   {
                       Id = 2,
                       OfferId = 5,
                       BillId = 5,
                       EmployeeId = 2
                   },
                   new ServiceBill
                   {
                       Id = 3,
                       OfferId = 6,
                       BillId = 6,
                       EmployeeId = 1
                   }
               });

            builder.Entity<SubscriptionBill>()
               .HasData(new List<SubscriptionBill>
               {
                   new SubscriptionBill
                   {
                       Id = 1,
                       OfferId = 7,
                       BillId = 7,
                       CustomerId = 1
                   },
                   new SubscriptionBill
                   {
                       Id = 2,
                       OfferId = 8,
                       BillId = 8,
                       CustomerId = 2
                   },
                   new SubscriptionBill
                   {
                       Id = 3,
                       OfferId = 9,
                       BillId = 9,
                       CustomerId = 1
                   }
               });
        }
    }
}
