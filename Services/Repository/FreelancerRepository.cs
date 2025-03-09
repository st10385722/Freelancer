using System;
using FreelancerJerry.Models;
using Microsoft.EntityFrameworkCore;

namespace FreelancerJerry.Services.Repository;

public class FreelancerRepository : IFreelancerRepository
{
    private readonly FreelancerjerrydbContext _context;

    // public FreelancerRepository(){
    //     _context = new FreelancerjerrydbContext();
    // }
    public FreelancerRepository(FreelancerjerrydbContext context){
        _context = context;
    }

    public IEnumerable<Freelancer> GetAll(){
        return _context.Freelancers.ToList();
    }

    public Freelancer GetById(int FreelancerId){
        return _context.Freelancers.Find(FreelancerId);
    }

    public void Insert(Freelancer freelancer){
        _context.Freelancers.Add(freelancer);
    }

    public void Update(Freelancer freelancer){
        _context.Entry(freelancer).State = EntityState.Modified;
    }

    public void Delete(int FreelancerId){
        Freelancer freelancer = _context.Freelancers.Find(FreelancerId);

        if(freelancer != null){
            _context.Freelancers.Remove(freelancer);
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
