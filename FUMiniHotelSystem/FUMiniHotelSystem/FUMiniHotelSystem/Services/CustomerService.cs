using BusinessOjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository iCustomerRepository;

        public CustomerService()
        {
            iCustomerRepository = new CustomerRepository();
        }

        public void AddCustomer(Customer customer)
        {
            iCustomerRepository.SaveCustomer(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            iCustomerRepository.DeleteCustomer(customer);
        }

        public List<Customer> GetCustomerList()
        {
            return iCustomerRepository.GetCustomers().ToList();
        }

        public Customer? GetCustomerById(string id)
        {
            return iCustomerRepository.GetCustomerById(id);
        }

        public void UpdateCustomer(Customer customer)
        {
            iCustomerRepository.UpdateCustomer(customer);
        }

        public Customer? GetCustomerByEmail(string email)
        {
            return iCustomerRepository.GetCustomerByEmail(email);
        }
    }
}
