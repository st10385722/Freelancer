using System;
using FreelancerJerry.Models;
using Microsoft.EntityFrameworkCore;

namespace FreelancerJerry.Services.Repository;

public class PaymentRepository : IPaymentRepository
{
    private readonly FreelancerjerrydbContext _context;

    // public PaymentRepository(){
    //     _context = new FreelancerjerrydbContext();
    // }
    public PaymentRepository(FreelancerjerrydbContext context){
        _context = context;
    }

    public IEnumerable<Payment> GetAll(){
        return _context.Payments.ToList();
    }

    public Payment GetById(int PaymentId){
        return _context.Payments.Find(PaymentId);
    }

    public void Insert(Payment Payment){
        _context.Payments.Add(Payment);
    }

    public void Update(Payment Payment){
        _context.Entry(Payment).State = EntityState.Modified;
    }

    public void Delete(int PaymentId){
        Payment Payment = _context.Payments.Find(PaymentId);

        if(Payment != null){
            _context.Payments.Remove(Payment);
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
