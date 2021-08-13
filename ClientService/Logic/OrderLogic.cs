using ClientService.DtoModels;
using ClientService.Interface;
using ClientService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ClientService.Logic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly DataContext _context;
        public OrderLogic()
        {
            _context = new DataContext();
        }
        public async Task CreateOrder(OrderDataDTO order)
        {
            var guest = AutoMapper.Mapper.Map<Guest>(order.Guest);
            var reservation = AutoMapper.Mapper.Map<Reservation>(order.Reservation);

            _context.Guests.Add(guest);
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }
    }
}