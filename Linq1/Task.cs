using System;
using System.Collections.Generic;

namespace Linq1
{
    public static class Task
    {
        private static List<Customer> customers = new List<Customer>
            {
                new Customer(1, "Tawana Shope", new DateTime(2017, 7, 15), 15.8),
                new Customer(2, "Danny Wemple", new DateTime(2016, 2, 3), 88.54),
                new Customer(3, "Margert Journey", new DateTime(2017, 11, 19), 0.5),
                new Customer(4, "Tyler Gonzalez", new DateTime(2017, 5, 14), 184.65),
                new Customer(5, "Melissa Demaio", new DateTime(2016, 9, 24), 241.33),
                new Customer(6, "Cornelius Clemens", new DateTime(2016, 4, 2), 99.4),
                new Customer(7, "Silvia Stefano", new DateTime(2017, 7, 15), 40),
                new Customer(8, "Margrett Yocum", new DateTime(2017, 12, 7), 62.2),
                new Customer(9, "Clifford Schauer", new DateTime(2017, 6, 29), 89.47),
                new Customer(10, "Norris Ringdahl", new DateTime(2017, 1, 30), 13.22),
                new Customer(11, "Delora Brownfield", new DateTime(2011, 10, 11), 0),
                new Customer(12, "Sparkle Vanzile", new DateTime(2017, 7, 15), 12.76),
                new Customer(13, "Lucina Engh", new DateTime(2017, 3, 8), 19.7),
                new Customer(14, "Myrna Suther", new DateTime(2017, 8, 31), 13.9),
                new Customer(15, "Fidel Querry", new DateTime(2016, 5, 17), 77.88),
                new Customer(16, "Adelle Elfrink", new DateTime(2017, 11, 6), 183.16),
                new Customer(17, "Valentine Liverman", new DateTime(2017, 1, 18), 13.6),
                new Customer(18, "Ivory Castile", new DateTime(2016, 4, 21), 36.8),
                new Customer(19, "Florencio Messenger", new DateTime(2017, 10, 2), 36.8),
                new Customer(20, "Anna Ledesma", new DateTime(2017, 12, 29), 0.8)
            };
            
            public static void A()
            {
                Console.WriteLine("A.");
                Console.WriteLine(Operations.FirstRegistered(customers).Id);
                Console.WriteLine();
            }

            public static void B()
            {
                Console.WriteLine("B.");
                Console.WriteLine(Operations.AverageBalance(customers));
                Console.WriteLine();
            }

            public static void C()
            {
                Console.WriteLine("C.");
                var dateFiltered =
                    Operations.FilterByDate(customers, new DateTime(2016, 12, 29), new DateTime(2017, 3, 8));
                foreach (var customer in dateFiltered)
                {
                    Console.WriteLine(customer.Id);
                }
                Console.WriteLine();
            }

            public static void D()
            {
                Console.WriteLine("D.");
                var idFiltered = Operations.FilterById(customers, 4, 12);
                foreach (var customer in idFiltered)
                {
                    Console.WriteLine(customer.Id);
                }

                Console.WriteLine();
            }

            public static void E()
            {
                Console.WriteLine("E.");
                var byNames = Operations.FilterByName(customers, "al");
                foreach (var customer in byNames)
                {
                    Console.WriteLine(customer.Id);
                }

                Console.WriteLine();
            }

            public static void F()
            {
                Console.WriteLine("F.");
                var groups = Operations.SimilarMonthCustomers(customers);
                foreach (var group in groups)
                {
                    Console.WriteLine();
                    foreach (var customer in group)
                    {
                        Console.WriteLine($"{customer.RegistrationDate} {customer.Name}");
                    }
                }

                Console.WriteLine();
            }

            public static void G()
            {
                Console.WriteLine("G.");
                var byField = Operations.ByField(customers, "Name");
                foreach (var customer in byField)
                {
                    Console.WriteLine(customer.Name);
                }
            }

            public static void H()
            {
                Console.WriteLine("H.");
                Console.WriteLine(Operations.AllNames(customers));
                Console.WriteLine();
            }
    }
}
