using System;
using FreelancerJerry.Models;
using Microsoft.EntityFrameworkCore;

namespace FreelancerJerry.Services.Repository;

public class BookingRepository : IBookingRepository
{
    private readonly FreelancerjerrydbContext _context;

    // public BookingRepository(){
    //     _context = new FreelancerjerrydbContext();
    // }
    public BookingRepository(FreelancerjerrydbContext context){
        _context = context;
    }

    public IEnumerable<Booking> GetAll(){
        return _context.Bookings.ToList();
    }

    public Booking GetById(int BookingId){
        return _context.Bookings.Find(BookingId);
    }

    public void Insert(Booking booking){
        _context.Bookings.Add(booking);
    }

    public void Update(Booking booking){
        _context.Entry(booking).State = EntityState.Modified;
    }

    public void Delete(int BookingId){
        Booking booking = _context.Bookings.Find(BookingId);

        if(booking != null){
            _context.Bookings.Remove(booking);
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
