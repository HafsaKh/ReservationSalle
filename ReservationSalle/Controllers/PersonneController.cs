using BLL;
using DAL.models;
using Microsoft.AspNetCore.Mvc;

namespace ReservationSalle.Controllers
{
    public class PersonneController : Controller
    {

        private readonly PersonneService _personneService;

        public PersonneController(PersonneService personneService)
        {
            this._personneService = personneService;
        }

        public IActionResult Index()
        {
            return View(_personneService.getAll());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Personne personne)
        {
            _personneService.create(personne);

            return RedirectToAction("Index");
            
        }


        [HttpGet]
        public IActionResult DeleteView(int id)
        {
            return View("Delete",_personneService.getById(id));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _personneService.delete(id);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateView(int id)
        {
            return View("Update",_personneService.getById(id));
        }




        [HttpPost]
        public IActionResult Update(Personne personne)
        {
            _personneService.update(personne);
            return RedirectToAction("Index");
        }





    }
}
