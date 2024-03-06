using BLL;
using Microsoft.AspNetCore.Mvc;

namespace ReservationSalle.Controllers
{
    public class ClientController : Controller
    {

        private readonly SalleService _salleService;

        public ClientController(SalleService salleService)
        {
            _salleService = salleService;
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


    }
}
