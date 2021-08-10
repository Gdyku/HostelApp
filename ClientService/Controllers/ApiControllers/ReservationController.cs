using System.Web.Http;
using System.Threading.Tasks;
using ClientService.Logic;
using System;
using System.Collections.Generic;
using ClientService.DtoModels;
using ClientService.Models;
using System.Data.Entity;
using AutoMapper;
using System.Net;
using System.Linq;

namespace ClientService.Controllers.ApiControllers
{
    public class ReservationController : ApiController
    {
        private readonly DataContext _context;
        public ReservationController()
        {
            _context = new DataContext();
        }

        [HttpGet]
        public async Task<List<Reservation>> GetReservationsAsync()
        {
            return await _context.Reservations.ToListAsync();

        }

        [HttpGet]
        public async Task<Reservation> GetReservationAsync(long Id)
        {
            try
            {
                var reservation = await _context.Reservations.FirstOrDefaultAsync(g => g.ID == Id);

                if (reservation == null)
                    throw new Exception("This guest cannot be find");

                return reservation;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public Reservation CreateReservationAsync(Reservation reservation)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            return reservation;
        }

        [HttpPut]
        public void EditReservationAsync(Reservation editedReservation)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var reservation = _context.Reservations.FirstOrDefault(r => r.ID == editedReservation.ID);

            if (reservation == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            reservation.ReservationCode = editedReservation.ReservationCode;
            reservation.Price = editedReservation.Price;
            reservation.DateOfCreate = editedReservation.DateOfCreate;
            reservation.CheckInDate = editedReservation.CheckInDate;
            reservation.CheckOutDate = editedReservation.CheckOutDate;
            reservation.Currency = editedReservation.Currency;
            reservation.Provision = editedReservation.Provision ?? reservation.Provision;
            reservation.Source = editedReservation.Source ?? reservation.Source;

            _context.SaveChanges();
        }

        [HttpDelete]
        public async Task DeleteReservationAsync(long Id)
        {
            try
            {
                var reservation = await _context.Reservations.FirstOrDefaultAsync(g => g.ID == Id);

                if (reservation == null)
                    throw new Exception("This guest cannot be find");

                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
