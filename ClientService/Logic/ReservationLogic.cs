using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ClientService.Models;
using System.Threading.Tasks;
using ClientService.DtoModels;
using System.Data.Entity;
using ClientService.Interface;

namespace ClientService.Logic
{
    public class ReservationLogic : IReservationLogic
    {
        private readonly DataContext _context;
        public ReservationLogic()
        {
            _context = new DataContext();
        } 

        public async Task<List<ReservationDTO>> GetReservations()
        {
            var reservations = await _context.Reservations.ToListAsync();
            var reservationsDto = AutoMapper.Mapper.Map<List<ReservationDTO>>(reservations);

            return reservationsDto;
        }

        public async Task<ReservationDTO> GetReservation(long Id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.ID == Id);

            if (reservation == null)
                throw new Exception("This guest cannot be find");

            var reservationDto = AutoMapper.Mapper.Map<ReservationDTO>(reservation);

            return reservationDto;
        }

        public async Task CreateReservation(ReservationDTO reservationDto)
        {
            var reservation = AutoMapper.Mapper.Map<Reservation>(reservationDto);

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task EditReservation(ReservationDTO reservationDto)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.ID == reservationDto.ID);

            if (reservation == null)
                throw new Exception("This guest cannot be find");

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