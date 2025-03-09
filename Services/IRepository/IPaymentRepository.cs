using System;
using FreelancerJerry.Models;

namespace FreelancerJerry.Services;

public interface IPaymentRepository
{
    IEnumerable<Payment> GetAll();
    Payment GetById(int PaymentId);
    void Insert(Payment payment);
    void Update(Payment payment);
    void Delete(int PaymentId);
    void Save();
}
