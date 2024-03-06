using DAL;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class SalleService
    {
        private readonly MyDbContext _db;

        public SalleService(MyDbContext db)
        {
            _db = db;
        }


        public void create (Salle salle)
        {
            _db.salles.Add(salle);
            _db.SaveChanges();

        }

        public void update(Salle salle)
        {
            Salle salle2 = _db.salles.Find(salle.id);
            if (salle2 != null)
            {
                salle2.nom = salle.nom;
                salle2.capacite = salle.capacite;   
                salle2.largeur = salle.largeur;
                _db.SaveChanges();

            }

        }


        public void delete(int id)
        {
            _db.salles.Remove(_db.salles.Find(id));
            _db.SaveChanges();
        }


        public List <Salle> getAll()
        {
            return _db.salles.ToList();
        }

        public Salle getById(int id)
        {
            return _db.salles.Find(id);
        }


        public List<Reservation> getReservations(int id)
        {   
            List<Reservation> list = _db.reservation.ToList();

            List <Reservation> result = new List<Reservation>();

            foreach (Reservation reservation in list)
            {
                if(reservation.personneId == id)
                {
                    result.Add(reservation);
                }
            }

            return result;
        }



    }
}