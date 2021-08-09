using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientService.Models
{
    public class Reservation
    {
        public Guid ID { get; set; }
        public int ReservationCode { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfCreate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        [Required]
        public string Currency { get; set; }
        public int? Provision { get; set; }
        public int? Source { get; set; }
        public List<Guest> Guest { get; set; }
    }
}