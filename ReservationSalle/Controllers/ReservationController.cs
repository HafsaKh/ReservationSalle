using BLL;
using DAL.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReservationSalle.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReservationController : Controller
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            this._reservationService = reservationService;
        }

        public IActionResult Index()
        {
            return View(_reservationService.getAll());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Reservation reservation)
        {
            _reservationService.create(reservation);

            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult DeleteView(int id)
        {
            return View("Delete", _reservationService.getById(id));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _reservationService.delete(id);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateView(int id)
        {
            return View("Update", _reservationService.getById(id));
        }




        [HttpPost]
        public IActionResult Update(Reservation reservation)
        {
            _reservationService.update(reservation);
            return RedirectToAction("Index");
        }





    }
}
