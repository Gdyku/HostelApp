using AutoMapper;
using ClientService.DtoModels;
using ClientService.Interface;
using ClientService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ClientService.Logic
{
    public class GuestLogic : IGuestLogic
    {
        private readonly DataContext _context;
        public GuestLogic()
        {
            _context = new DataContext();
        }

        public async Task<List<GuestDTO>> GetGuests()
        {
            var guests = await _context.Guests.ToListAsync();
            var guestsDto = AutoMapper.Mapper.Map<List<GuestDTO>>(guests);

            return guestsDto;
        }

        public async Task<GuestDTO> GetGuest(long Id)
        {
            var guest = await _context.Guests.FirstOrDefaultAsync(g => g.ID == Id);

            if (guest == null)
                throw new Exception("This guest cannot be find");

            var guestDto = AutoMapper.Mapper.Map<GuestDTO>(guest);

            return guestDto;
        }

        public async Task CreateGuest(GuestDTO guestDto)
        {
            var guest = AutoMapper.Mapper.Map<Guest>(guestDto);

            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
        }

        public async Task EditGuest(GuestDTO guestDto)
        {
            var guest = await _context.Guests.FirstOrDefaultAsync(g => g.ID == guestDto.ID);

            if (guest == null)
                throw new Exception("Guest cannot be find");

            guest.Name = guestDto.Name;
            guest.Surname = guestDto.Surname;
            guest.Email = guestDto.Email;
            guest.BirthDate = guestDto.BirthDate ?? guest.BirthDate;
            guest.PostalCode = guestDto.PostalCode ?? guest.PostalCode;
            guest.PhoneNumber = guestDto.PhoneNumber ?? guest.PhoneNumber;
            guest.Address = guestDto.Address ?? guest.Address;
            guest.City = guestDto.City;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteGuest(long Id)
        {
            var guest = await _context.Guests.FirstOrDefaultAsync(g => g.ID == Id);

            if(guest == null)
                throw new Exception("Guest cannot be find");

            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GuestDTO>> GetSpecificGuests()
        {
            var guests = await _context.Guests.Where(g => g.Name == "Piotr" || g.City == "Wrocław" || g.City == null).ToListAsync();

            var guestsDto = AutoMapper.Mapper.Map<List<GuestDTO>>(guests);

            return guestsDto;
        }
    }
}