using BLL;
using DAL.models;
using Microsoft.AspNetCore.Mvc;

namespace ReservationSalle.Controllers
{
    public class SalleController : Controller
    {
        private readonly SalleService _salleService;

        public SalleController(SalleService salleService)
        {
           this._salleService = salleService;
        }

        public IActionResult Index()
        {
            return View(_salleService.getAll());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Salle salle)
        {
            _salleService.create(salle);

            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult DeleteView(int id)
        {
            return View("Delete", _salleService.getById(id));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _salleService.delete(id);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateView(int id)
        {
            return View("Update", _salleService.getById(id));
        }




        [HttpPost]
        public IActionResult Update(Salle salle)
        {
            _salleService.update(salle);
            return RedirectToAction("Index");
        }





    }
}
