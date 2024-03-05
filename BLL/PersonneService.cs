using DAL;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PersonneService
    {
        private readonly MyDbContext _db;

        public PersonneService(MyDbContext db)
        {
            _db = db;
        }




        public void create(Personne personne)
        {
            _db.personnes.Add(personne);
            _db.SaveChanges();

        }

        public void update(Personne personne)
        {
            Personne personne2 = _db.personnes.Find(personne.id);
            if (personne2 != null)
            {
                personne2.username = personne.username;
                personne2.password = personne.password;
                personne2.email = personne.email;
                _db.SaveChanges();

            }

        }


        public void delete(int id)
        {
            _db.personnes.Remove(_db.personnes.Find(id));
            _db.SaveChanges();
        }


        public List<Personne> getAll()
        {
            return _db.personnes.ToList();
        }


        public Personne getById(int id)
        {
            return _db.personnes.Find(id);
        }




    }
}
