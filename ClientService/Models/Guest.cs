using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientService.Models
{
    public class Guest
    {
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PostalCode { get; set; }
        public List<Reservation> Reservation { get; set; }
    }
}