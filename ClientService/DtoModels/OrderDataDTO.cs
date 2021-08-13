using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientService.DtoModels
{
    public class OrderDataDTO
    {
        [Required]
        public GuestDTO Guest { get; set; }
        [Required]
        public ReservationDTO Reservation { get; set; }
    }
}