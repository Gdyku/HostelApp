using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ClientService.Models;
using System.Threading.Tasks;
using ClientService.DtoModels;
using System.Data.Entity;

namespace ClientService.Logic
{
    public class ReservationLogic
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public ReservationLogic(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        } 

        public async Task<List<ReservationDTO>> GetReservations()
        {
            var reservations = await _context.Reservations.ToListAsync();
            var mappedReservations = _mapper.Map<List<Reservation>, List<ReservationDTO>>(reservations);

            return mappedReservations;
        }

        public async Task<ReservationDTO> GetReservation(long Id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.ID == Id);

            if (reservation == null)
                throw new Exception("This guest cannot be find");

            var mappedReservation = _mapper.Map<Reservation, ReservationDTO>(reservation);

            return mappedReservation;
        }

        public async Task CreateReservation(ReservationDTO reservation)
        {
            var mappedReservation = _mapper.Map<ReservationDTO, Reservation>(reservation);

            _context.Reservations.Add(mappedReservation);
            await _context.SaveChangesAsync();
        }

        public async Task EditReservation(ReservationDTO editedReservation)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.ID == editedReservation.ID);

            if (reservation == null)
                throw new Exception("This guest cannot be find");

            reservation.ReservationCode = editedReservation.ReservationCode;
            reservation.Price = editedReservation.Price;
            reservation.DateOfCreate = editedReservation.DateOfCreate;
            reservation.CheckInDate = editedReservation.CheckInDate;
            reservation.CheckOutDate = editedReservation.CheckOutDate;
            reservation.Currency = editedReservation.Currency;
            reservation.Provision = editedReservation.Provision ?? reservation.Provision;
            reservation.Source = editedReservation.Source ?? reservation.Source;
        }

        public async Task RemoveReservation(long Id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.ID == Id);

            if (reservation == null)
                throw new Exception("This guest cannot be find");

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }
    }
}