using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ClientService.DtoModels
{
    public class GuestDTO
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
        public List<ReservationDTO> Reservation { get; set; }
    }
}