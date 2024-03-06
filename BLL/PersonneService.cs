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

        public int getByUsername(String username)
        {
            Personne personne = new Personne();
            List<Personne> list = _db.personnes.ToList();
            foreach (Personne person in list)
            {
                if (person.username.Equals(username))
                {
                    personne = person;
                    break;
                }
            }
            return personne.id;
        }

        public Personne sign(Personne personne)
        {
            List<Personne> list = _db.personnes.ToList();

            foreach (Personne p in list)
            {
                if (p.username.Equals(personne.username) || p.email.Equals(personne.email))
                {
                    return null;
                }
            }

            _db.personnes.Add(personne);
            _db.SaveChanges();

            return personne;


        }


        public Personne login(Personne personne)
        {
            List<Personne> list = _db.personnes.ToList();
            Personne result = null;
            if (personne.username.Equals("admin") && personne.password.Equals("adminadmin"))
            {
                return new Personne { username = "anaRaniAdmin" };
            }
            foreach (Personne p in list)
            {
                if (p.username.Equals(personne.username) && p.password.Equals(personne.password))
                {
                    result = personne;
                    break;
                }

            }
            return result;
        }


    }
}
