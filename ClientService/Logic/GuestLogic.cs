using AutoMapper;
using ClientService.DtoModels;
using ClientService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ClientService.Logic
{
    public class GuestLogic
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public GuestLogic(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GuestDTO>> GetGuests()
        {
            var guests = await _context.Guests.ToListAsync();
            var mappedGuests = _mapper.Map<List<Guest>, List<GuestDTO>>(guests);

            return mappedGuests;
        }

        public async Task<GuestDTO> GetGuest(long Id)
        {
            var guest = await _context.Guests.FirstOrDefaultAsync(g => g.ID == Id);

            if (guest == null)
                throw new Exception("This guest cannot be find");

            var mappedGuest = _mapper.Map<Guest, GuestDTO>(guest);

            return mappedGuest;
        }

        public async Task CreateGuest(GuestDTO guest)
        {
            var mappedGuest = _mapper.Map<GuestDTO, Guest>(guest);

            _context.Guests.Add(mappedGuest);
            await _context.SaveChangesAsync();
        }

        public async Task EditGuest(GuestDTO editedGuest)
        {
            var guest = await _context.Guests.FirstOrDefaultAsync(g => g.ID == editedGuest.ID);

            if (guest == null)
                throw new Exception("Guest cannot be find");

            guest.Name = editedGuest.Name;
            guest.Surname = editedGuest.Surname;
            guest.Email = editedGuest.Email;
            guest.BirthDate = editedGuest.BirthDate ?? guest.BirthDate;
            guest.PostalCode = editedGuest.PostalCode ?? guest.PostalCode;
            guest.PhoneNumber = editedGuest.PhoneNumber ?? guest.PhoneNumber;
            guest.Address = editedGuest.Address ?? guest.Address;
            guest.City = editedGuest.City;

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

            var mappedGuests = _mapper.Map<List<Guest>, List<GuestDTO>>(guests);

            return mappedGuests;
        }
    }
}