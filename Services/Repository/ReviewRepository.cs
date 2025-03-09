using System;
using FreelancerJerry.Models;
using Microsoft.EntityFrameworkCore;

namespace FreelancerJerry.Services.Repository;

public class ReviewRepository : IReviewRepository
{
    private readonly FreelancerjerrydbContext _context;

    // public ReviewRepository(){
    //     _context = new FreelancerjerrydbContext();
    // }
    public ReviewRepository(FreelancerjerrydbContext context){
        _context = context;
    }

    public IEnumerable<Review> GetAll(){
        return _context.Reviews.ToList();
    }

    public Review GetById(int ReviewId){
        return _context.Reviews.Find(ReviewId);
    }

    public void Insert(Review Review){
        _context.Reviews.Add(Review);
    }

    public void Update(Review Review){
        _context.Entry(Review).State = EntityState.Modified;
    }

    public void Delete(int ReviewId){
        Review Review = _context.Reviews.Find(ReviewId);

        if(Review != null){
            _context.Reviews.Remove(Review);
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
