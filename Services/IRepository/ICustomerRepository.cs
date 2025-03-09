using System;
using FreelancerJerry.Models;

namespace FreelancerJerry.Services;

public interface ICustomerRepository
{
    IEnumerable<Customer> GetAll();
    Customer GetById(int CustomerId);
    Customer GetByEmail(string Email);
    void Insert(Customer customer);
    void Update(Customer customer);
    void Delete(int CustomerId);
    void Save();
}
