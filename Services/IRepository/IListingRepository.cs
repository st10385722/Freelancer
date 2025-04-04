using System;
using FreelancerJerry.Models;

namespace FreelancerJerry.Services.IRepository;

public interface IListingRepository
{
    IEnumerable<Listing> GetAll();
    Listing GetById(int listingId);
    void Insert(Listing listing);
    void Update(Listing listing);
    void Delete(int listingId);
    void Save();
}
