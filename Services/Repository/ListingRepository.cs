using System;
using FreelancerJerry.Models;
using FreelancerJerry.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FreelancerJerry.Services.Repository;

public class ListingRepository : IListingRepository
{
    private readonly FreelancerjerrydbContext _context;

    public ListingRepository(FreelancerjerrydbContext context){
        _context = context;
    }

    public IEnumerable<Listing> GetAll(){
        return _context.Listings.ToList();
    }

    public Listing GetById(int listingId){
        return _context.Listings.Find(listingId);
    }

    public void Insert(Listing listing){
        _context.Listings.Add(listing);
    }

    public void Update(Listing listing){
        _context.Entry(listing).State = EntityState.Modified;
    }
    public void Delete(int listingId){
        Listing listing = _context.Listings.Find(listingId);

        if(listing != null){
            _context.Listings.Remove(listing);
        }
    }

    public void Save(){
        _context.SaveChangesAsync();
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
