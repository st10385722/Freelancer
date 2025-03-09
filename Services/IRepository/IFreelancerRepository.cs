using System;
using FreelancerJerry.Models;

namespace FreelancerJerry.Services;

public interface IFreelancerRepository
{
    IEnumerable<Freelancer> GetAll();
    Freelancer GetById(int FreelancerId);
    void Insert(Freelancer freelancer);
    void Update(Freelancer freelancer);
    void Delete(int FreelancerId);
    void Save();
}
