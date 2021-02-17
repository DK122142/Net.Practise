using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq1
{
    public static class Operations
    {
        public static Customer FirstRegistered(List<Customer> customers)
        {
            return customers.OrderBy(customer => customer.RegistrationDate).First();
        }

        public static double AverageBalance(List<Customer> customers)
        {
            return customers.Average(customer => customer.Balance);
        }

        public static IEnumerable<Customer> FilterByDate(List<Customer> customers, DateTime from, DateTime to)
        {
            return customers.Where(customer =>
                customer.RegistrationDate >= from && customer.RegistrationDate <= to
            );
        }

        public static IEnumerable<Customer> FilterById(List<Customer> customers, int idFrom, int idTo)
        {
            return customers.Where(customer => customer.Id >= idFrom && customer.Id <= idTo);
        }

        public static IEnumerable<Customer> FilterByName(List<Customer> customers, string input)
        {
            return customers.Where(customer => customer.Name.ToLower().Contains(input.ToLower()));
        }

        public static IEnumerable<IGrouping<int, Customer>> SimilarMonthCustomers(List<Customer> customers)
        {
            return customers.OrderBy(c => c.RegistrationDate.Month).ThenBy(c => c.Name)
                .GroupBy(c => c.RegistrationDate.Month);
        }

        public static IEnumerable<Customer> ByField(List<Customer> customers, string field, bool isDescending = false)
        {
            if (isDescending)
            {
                return customers.OrderByDescending(customer => customer.GetType().GetProperty(field).GetValue(customer));
            }
            return customers.OrderBy(customer => customer.GetType().GetProperty(field).GetValue(customer));
            
        }
        
        public static string AllNames(List<Customer> customers)
        {
            return string.Join(",", customers.Select(customer => customer.Name));
        }


    }
}
