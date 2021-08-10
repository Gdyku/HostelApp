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
        public async Task<List<Guest>> GetGuestsAsync()
        {
            return await _context.Guests.ToListAsync();
        }

        [HttpGet]
        public async Task<Guest> GetGuestAsync(long Id)
        {
            try
            {
                var guest = await _context.Guests.FirstOrDefaultAsync(g => g.ID == Id);

                if(guest == null)
                    throw new Exception("This guest cannot be find");

                return guest;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public Guest CreateGuest(Guest guest)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Guests.Add(guest);
            _context.SaveChanges();

            return guest;
        }

        [HttpPut]
        public void EditGuestAsync(Guest editedGuest)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var guest = _context.Guests.FirstOrDefault(g => g.ID == editedGuest.ID);

            if (guest == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            guest.Name = editedGuest.Name;
            guest.Surname = editedGuest.Surname;
            guest.Email = editedGuest.Email;
            guest.BirthDate = editedGuest.BirthDate ?? guest.BirthDate;
            guest.PostalCode = editedGuest.PostalCode ?? guest.PostalCode;
            guest.PhoneNumber = editedGuest.PhoneNumber ?? guest.PhoneNumber;
            guest.Address = editedGuest.Address ?? guest.Address;
            guest.City = editedGuest.City ?? guest.City;

            _context.SaveChanges();
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
