using BusinessOjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);

        Customer? GetCustomerByEmail(string email);

        List<Customer> GetCustomerList();

        Customer? GetCustomerById(string id);
    }
}
