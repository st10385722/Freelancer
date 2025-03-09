using System;
using FreelancerJerry.Models;
using Microsoft.EntityFrameworkCore;

namespace FreelancerJerry.Services.Repository;

public class CustomerRepository : ICustomerRepository
{
private readonly FreelancerjerrydbContext _context;

    // public CustomerRepository(){
    //     _context = new FreelancerjerrydbContext();
    // }
    public CustomerRepository(FreelancerjerrydbContext context){
        _context = context;
    }

    public IEnumerable<Customer> GetAll(){
        return _context.Customers.ToList();
    }

    public Customer GetById(int CustomerId){
        return _context.Customers.Find(CustomerId);
    }

    public Customer GetByEmail(string Email){
        return _context.Customers.FirstOrDefault(c => c.Email.Equals(Email));
    }

    public void Insert(Customer customer){
        _context.Customers.Add(customer);
    }

    public void Update(Customer customer){
        _context.Entry(customer).State = EntityState.Modified;
    }

    public void Delete(int CustomerId){
        Customer customer = _context.Customers.Find(CustomerId);

        if(customer != null){
            _context.Customers.Remove(customer);
        }
    }

    public void Save(){
        _context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing){
        if(!this.disposed){
            if(disposing){
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose(){
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
