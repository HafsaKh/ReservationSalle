using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Personne> personnes { get; set; }
        public DbSet<Reservation> reservation { get; set; }
        public DbSet<Salle> salles { get; set; }

    }
}
