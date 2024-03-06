using BLL;
using DAL.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReservationSalle.Controllers
{
    [Authorize(Roles = "User")]

    public class ClientController : Controller
    {

        private readonly SalleService _salleService;
        private readonly ReservationService _reservationService;

        public ClientController(SalleService salleService, ReservationService reservationService)
        {
            _salleService = salleService;
            _reservationService = reservationService;
        }

        [HttpGet]
        public IActionResult Salles()
        {
            return View(_salleService.getAll());
        }

        [HttpGet]
        public IActionResult MesReservations(int id)
        {
            return View(_salleService.getReservations(id));
        }

        [HttpGet]
        public IActionResult Reserver(int id)
        {
            return View(_salleService.getById(id));
        }

        [HttpPost]
        public IActionResult ReserverPost(
                                           [FromForm(Name = "date")] DateTime date,
                                           [FromForm(Name = "nbrHeure")] int nbrHeure,
                                           [FromForm(Name = "salleId")] int salleId,
                                           [FromForm(Name = "personneId")] int personneId
                                            )
        {
            Reservation reservation = new Reservation();
            reservation.date = date;
            reservation.nbrHeure = nbrHeure;
            reservation.salleId = salleId;
            reservation.personneId = personneId;
            _reservationService.create(reservation);
            return RedirectToAction("Salles");
        }
    }
}
