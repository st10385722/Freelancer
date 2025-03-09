using System;
using FreelancerJerry.Models;

namespace FreelancerJerry.Services;

public interface IBookingRepository
{
    IEnumerable<Booking> GetAll();
    Booking GetById(int BookingId);
    void Insert(Booking booking);
    void Update(Booking booking);
    void Delete(int BookingId);
    void Save();
}
