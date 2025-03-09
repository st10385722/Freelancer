using FreelancerJerry.Models;
using FreelancerJerry.Services;
using FreelancerJerry.Services.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerJerry.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;
        private IPasswordHasher _passwordHasher;

        public CustomerController(ICustomerRepository customerRepository, IPasswordHasher passwordHasher){
            _customerRepository = customerRepository;
            _passwordHasher = passwordHasher;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            var model = _customerRepository.GetAll();
            return View(model);
        }
        public ActionResult Register(){
            return View();
        }
        [HttpPost]
        public IActionResult Register(Customer model){
            ModelState.Remove("Password_Hash");
            if(ModelState.IsValid){
                if(model.Password != model.ConfirmPassword){
                    ViewData["PasswordError"] = "Password does not match";
                    return View(model);
                }
                model.Password_Hash = _passwordHasher.HashPassword(model.Password);
                _customerRepository.Insert(model);
                _customerRepository.Save();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Login(){
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password){
            var customer = _customerRepository.GetByEmail(email);
            var correctPassword = _passwordHasher.VerifyHashedPassword(customer.Password_Hash, password);
            if(correctPassword == PasswordVerificationResult.Success){
                return RedirectToAction("Index", "Home");
            }
            else {
                ViewData["LoginError"] = "Failed to login! Username or Password incorrect!";
                return View();
            }
        }
    }
}
