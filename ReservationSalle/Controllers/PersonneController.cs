using BLL;
using DAL.models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ReservationSalle.Controllers
{
    public class PersonneController : Controller
    {

        private readonly PersonneService _personneService;

        public PersonneController(PersonneService personneService)
        {
            this._personneService = personneService;
        }
        [Authorize(Roles = "Admin")]

        public IActionResult Index()
        {
            return View(_personneService.getAll());
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Add(Personne personne)
        {
            _personneService.create(personne);

            return RedirectToAction("Index");
            
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult DeleteView(int id)
        {
            return View("Delete",_personneService.getById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Delete(int id)
        {
            _personneService.delete(id);

            return RedirectToAction("Index");

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult UpdateView(int id)
        {
            return View("Update",_personneService.getById(id));
        }




        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Update(Personne personne)
        {
            _personneService.update(personne);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Sign()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Sign(Personne personne)
        {
            Personne result = _personneService.sign(personne);
            if (result != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, result.id.ToString()),
                    new Claim(ClaimTypes.Name, result.username),
                    new Claim(ClaimTypes.Role, "User"),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();


                return RedirectToAction("Salles", "Client");
            }
            return View();
        }







        [HttpPost]
        public IActionResult Login(Personne personne)
        {
            Personne result = _personneService.login(personne);

            if (result != null)
            {
                if (result.username.Equals("anaRaniAdmin"))
                {

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, result.username),
                        new Claim(ClaimTypes.Role, "Admin")
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    int idPersonne = _personneService.getByUsername(personne.username);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, idPersonne.ToString()),
                        new Claim(ClaimTypes.Name, result.username),
                        new Claim(ClaimTypes.Role, "User"),
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();

                    return RedirectToAction("Salles", "Client");
                }
            }
            else
            {
                return View();
            }
        }




        public IActionResult Access()
        {
            return View();
        }
       

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();

            return RedirectToAction("Login", "Personne");
        }



    }
}
