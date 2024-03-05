using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public int nbrHeure { get; set; }
        public int personneId { get; set; }

        [ForeignKey("personneId")]
        public Personne personne { get; set; }
        public int salleId { get; set; }

        [ForeignKey("salleId")]

        public Salle salle { get; set; }
    }
}
