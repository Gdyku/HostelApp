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
        public async Task<List<ReservationDTO>> GetReservationsAsync()
        {
            var reservations = await _context.Reservations.ToListAsync();
            var reservationsDto = AutoMapper.Mapper.Map<List<ReservationDTO>>(reservations);

            return reservationsDto;
        }

        [HttpGet]
        public async Task<ReservationDTO> GetReservationAsync(long Id)
        {
            try
            {
                var reservation = await _context.Reservations.FirstOrDefaultAsync(g => g.ID == Id);

                if (reservation == null)
                    throw new Exception("This guest cannot be find");

                var reservationDto = AutoMapper.Mapper.Map<ReservationDTO>(reservation);

                return reservationDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task CreateReservationAsync(ReservationDTO reservationDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var reservation = AutoMapper.Mapper.Map<Reservation>(reservationDto);

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task EditReservationAsync(ReservationDTO reservationDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.ID == reservationDto.ID);

            if (reservation == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            reservation.ReservationCode = reservationDto.ReservationCode;
            reservation.Price = reservationDto.Price;
            reservation.DateOfCreate = reservationDto.DateOfCreate;
            reservation.CheckInDate = reservationDto.CheckInDate;
            reservation.CheckOutDate = reservationDto.CheckOutDate;
            reservation.Currency = reservationDto.Currency;
            reservation.Provision = reservationDto.Provision ?? reservation.Provision;
            reservation.Source = reservationDto.Source ?? reservation.Source;

            await _context.SaveChangesAsync();
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
