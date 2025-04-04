using Firebase.Auth;
using FreelancerJerry.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreelancerJerry.Controllers
{    
    public class AuthController : Controller{
        private FirebaseAuthProvider auth; 
        public AuthController(){
            auth = new FirebaseAuthProvider(new FirebaseConfig(Environment.GetEnvironmentVariable("freelanceruserauthapikey")));
        }

        [HttpGet]
        public IActionResult Register(){   
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel model){
        try{
            await auth.CreateUserWithEmailAndPasswordAsync(model.Email, model.Password);

            var fbAuthLink = await auth.SignInWithEmailAndPasswordAsync(model.Email, model.Password);
            string currentUserId = fbAuthLink.User.LocalId;

            if (currentUserId != null)
            {
                HttpContext.Session.SetString("currentUser", currentUserId);
                return RedirectToAction("Index", "Home");
            }
            }
            catch (FirebaseAuthException ex){
            var firebaseEx = JsonConvert.DeserializeObject<FirebaseErrorModel>(ex.ResponseData);
            ModelState.AddModelError(String.Empty, firebaseEx.error.message);
            return View(model);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel model){

            try {
                var fbAuthLink = await auth.SignInWithEmailAndPasswordAsync(model.Email, model.Password);
                string currentUserId = fbAuthLink.User.LocalId;

                if(currentUserId != null){
                    HttpContext.Session.SetString("currentUser", currentUserId);
                    return RedirectToAction("Index", "Home");
                }
            } catch (FirebaseAuthException ex){
                var firebaseEx = JsonConvert.DeserializeObject<FirebaseErrorModel>(ex.ResponseData);
                ModelState.AddModelError(String.Empty, firebaseEx.error.message);
                return View(model);
            }
            return View();
        }

        [HttpGet]
        public IActionResult LogOut(){
            HttpContext.Session.Remove("currentUser");
            return RedirectToAction("Login");
        }
    }
}
