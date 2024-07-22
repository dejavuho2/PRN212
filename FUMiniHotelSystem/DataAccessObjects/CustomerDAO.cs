using BusinessOjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class CustomerDAO
    {

        public static List<Customer> GetCustomers()
        {
            var listCustomer = new List<Customer>();
            try
            {
                using var db = new FuminiHotelManagementContext();
                listCustomer = db.Customers.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listCustomer;
        }

        public static void SaveCustomer(Customer customer)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void UpdateCustomer(Customer customer)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                db.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteCustomer(Customer customer)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                var c1 =
                    db.Customers.SingleOrDefault(c => c.CustomerId == customer.CustomerId);
                if (c1 != null) {
                    db.Customers.Remove(c1);

                    db.SaveChanges();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static Customer? GetCustomerById(string customerId)
        {
            using var db = new FuminiHotelManagementContext();
            return db.Customers.FirstOrDefault(c => c.CustomerId.ToString() == customerId);
        }

        public static Customer? GetCustomerByEmail(string email)
        {
            using var db = new FuminiHotelManagementContext();
            return db.Customers.FirstOrDefault(c => c.EmailAddress == email);
        }
    }
}
