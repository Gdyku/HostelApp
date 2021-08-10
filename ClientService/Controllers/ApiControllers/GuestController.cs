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
    public class GuestController : ApiController
    {
        private readonly DataContext _context;
        public GuestController()
        { 
            _context = new DataContext();
        }

        [HttpGet]
        public async Task<List<GuestDTO>> GetGuestsAsync()
        {
            var guests = await _context.Guests.ToListAsync();
            var guestsDto = AutoMapper.Mapper.Map<List<GuestDTO>>(guests);

            return guestsDto;
        }

        [HttpGet]
        public async Task<GuestDTO> GetGuestAsync(long Id)
        {
            try
            {
                var guest = await _context.Guests.FirstOrDefaultAsync(g => g.ID == Id);

                if(guest == null)
                    throw new Exception("This guest cannot be find");

                var guestDto = AutoMapper.Mapper.Map<GuestDTO>(guest);

                return guestDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task CreateGuest(GuestDTO guestDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var guest = AutoMapper.Mapper.Map<Guest>(guestDto);

            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task EditGuestAsync(GuestDTO guestDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var guest = await _context.Guests.FirstOrDefaultAsync(g => g.ID == guestDto.ID);

            if (guest == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            guest.Name = guestDto.Name;
            guest.Surname = guestDto.Surname;
            guest.Email = guestDto.Email;
            guest.BirthDate = guestDto.BirthDate ?? guest.BirthDate;
            guest.PostalCode = guestDto.PostalCode ?? guest.PostalCode;
            guest.PhoneNumber = guestDto.PhoneNumber ?? guest.PhoneNumber;
            guest.Address = guestDto.Address ?? guest.Address;
            guest.City = guestDto.City ?? guest.City;

            await _context.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task DeleteGuestAsync(long Id)
        {
            try
            {
                var guest = await _context.Guests.FirstOrDefaultAsync(g => g.ID == Id);

                if (guest == null)
                    throw new Exception("This guest cannot be find");

                _context.Guests.Remove(guest);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            { 
                throw;
            }
        }
    }
}
