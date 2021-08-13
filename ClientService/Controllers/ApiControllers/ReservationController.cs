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
using ClientService.Interface;

namespace ClientService.Controllers.ApiControllers
{
    public class ReservationController : ApiController
    {
        private readonly IReservationLogic _logic;
        public ReservationController()
        {
            _logic = new ReservationLogic();
        }

        [HttpGet]
        public async Task<List<ReservationDTO>> GetReservationsAsync()
        {
            return await _logic.GetReservations();
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
        public async Task<IHttpActionResult> CreateReservationAsync(ReservationDTO reservationDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            await _logic.CreateReservation(reservationDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IHttpActionResult> EditReservationAsync(ReservationDTO reservationDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            await _logic.EditReservation(reservationDto);
            return Ok();
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
