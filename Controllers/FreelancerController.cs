using FreelancerJerry.Models;
using FreelancerJerry.Services;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerJerry.Controllers
{
    public class FreelancerController : Controller
    {
        private IFreelancerRepository _freelancerRepository;

        public FreelancerController(IFreelancerRepository freelancerRepository)
        {
           _freelancerRepository = freelancerRepository;
        }

        // GET: FreelancerController
        [HttpGet]
        public ActionResult Index()
        {
            var model = _freelancerRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddFreelancer(){
            return View();
        }

        [HttpPost]
        public ActionResult AddFreelancer(Freelancer model){
            if(ModelState.IsValid){
                _freelancerRepository.Insert(model);
                _freelancerRepository.Save();
                return RedirectToAction("Index", "Freelancer");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditFreelancer(int FreelancerId){
            Freelancer model = _freelancerRepository.GetById(FreelancerId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditFreelancer(Freelancer model){
            if(ModelState.IsValid){
                _freelancerRepository.Update(model);
                _freelancerRepository.Save();
                return RedirectToAction("Index", "Freelancer");
            } else {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteFreelancer(int FreelancerId){
            Freelancer model = _freelancerRepository.GetById(FreelancerId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int FreelancerId){
            _freelancerRepository.Delete(FreelancerId);
            _freelancerRepository.Save();
            return RedirectToAction("Index", "Freelancer");
        }

    }
}
