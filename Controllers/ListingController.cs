using FreelancerJerry.Models;
using FreelancerJerry.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace listingJerry.Controllers
{
    public class ListingController : Controller
    {
        // GET: ListingController
        private IListingRepository _listingRepository;

        public ListingController(IListingRepository listingRepository)
        {
           _listingRepository = listingRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = _listingRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddListing(){
            return View();
        }

        [HttpPost]
        public ActionResult AddListing(Listing model){
            if(ModelState.IsValid){
                _listingRepository.Insert(model);
                _listingRepository.Save();
                return RedirectToAction("Index", "listing");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Editlisting(int listingId){
            Listing model = _listingRepository.GetById(listingId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Editlisting(Listing model){
            if(ModelState.IsValid){
                _listingRepository.Update(model);
                _listingRepository.Save();
                return RedirectToAction("Index", "listing");
            } else {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Deletelisting(int listingId){
            Listing model = _listingRepository.GetById(listingId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int listingId){
            _listingRepository.Delete(listingId);
            _listingRepository.Save();
            return RedirectToAction("Index", "listing");
        }
    }
}
