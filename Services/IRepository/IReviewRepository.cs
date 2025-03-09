using System;
using FreelancerJerry.Models;

namespace FreelancerJerry.Services;

public interface IReviewRepository
{
    IEnumerable<Review> GetAll();
    Review GetById(int ReviewId);
    void Insert(Review review);
    void Update(Review review);
    void Delete(int ReviewId);
    void Save();
}
