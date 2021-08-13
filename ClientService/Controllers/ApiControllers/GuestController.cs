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
    //Route: api/controller/action/id
    public class GuestController : ApiController
    {
        private readonly IGuestLogic _logic;
        public GuestController()
        { 
            _logic = new GuestLogic();
        }

        [HttpGet]
        public async Task<List<GuestDTO>> GetGuestsAsync()
        {
            return await _logic.GetGuests();
        }

        [HttpGet]
        public async Task<GuestDTO> GetGuestAsync(long Id)
        {
            try
            {
                return await _logic.GetGuest(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<List<GuestDTO>> GetSpecificGuests()
        {
            return await _logic.GetSpecificGuests();
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateGuest(GuestDTO guestDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            await _logic.CreateGuest(guestDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IHttpActionResult> EditGuestAsync(GuestDTO guestDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            await _logic.EditGuest(guestDto);
            return Ok();
        }

        [HttpDelete]
        public async Task DeleteGuestAsync(long Id)
        {
            try
            {
                await _logic.DeleteGuest(Id);
            }
            catch (Exception)
            { 
                throw;
            }
        }
    }
}
