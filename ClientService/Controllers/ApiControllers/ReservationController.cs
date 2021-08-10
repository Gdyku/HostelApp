using System.Web.Http;
using System.Threading.Tasks;
using ClientService.Logic;
using System;
using System.Collections.Generic;
using ClientService.DtoModels;
using ClientService.Models;
using System.Data.Entity;
using AutoMapper;

namespace ClientService.Controllers.ApiControllers
{
    public class ReservationController : ApiController
    {
        private readonly ReservationLogic _logic;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ReservationController(IMapper mapper)
        {
            _context = new DataContext();
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<ReservationDTO>> GetReservationsAsync()
        {
            var reservations = await _context.Reservations.ToListAsync();
            var mappedReservations = _mapper.Map<List<Reservation>, List<ReservationDTO>>(reservations);

            return mappedReservations;
        }

        [HttpGet]
        public async Task<ReservationDTO> GetReservationAsync(long Id)
        {
            try
            {
                return await _logic.GetReservation(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task CreateReservationAsync(ReservationDTO reservation)
        {
            await _logic.CreateReservation(reservation);
        }

        [HttpPut]
        public async Task EditReservationAsync(ReservationDTO reservation)
        {
            try
            {
                await _logic.EditReservation(reservation);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public async Task DeleteReservationAsync(long Id)
        {
            try
            {
                await _logic.RemoveReservation(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
