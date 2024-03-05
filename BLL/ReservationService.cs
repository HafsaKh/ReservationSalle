using DAL;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReservationService
    {
        private readonly MyDbContext _db;

        public ReservationService(MyDbContext db)
        {
            _db = db;
        }


        public void create(Reservation reservation)
        {
            _db.reservation.Add(reservation);
            _db.SaveChanges();

        }

        public void update(Reservation reservation)
        {
            Reservation reservation2 = _db.reservation.Find(reservation.id);
            if (reservation2 != null)
            {
                reservation2.date = reservation.date;
                reservation2.nbrHeure = reservation.nbrHeure;
                reservation2.personneId = reservation.personneId;
                reservation2.salleId = reservation.salleId;

                _db.SaveChanges();

            }

        }


        public void delete(int id)
        {
            _db.reservation.Remove(_db.reservation.Find(id));
            _db.SaveChanges();
        }


        public List<Reservation> getAll()
        {
            return _db.reservation.ToList();
        }

        public Reservation getById(int id)
        {
            return _db.reservation.Find(id);
        }
    }
}
