using ClientService.DtoModels;
using ClientService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ClientService.Controllers
{
    public class TestController : Controller
    {
        private readonly DataContext _context;
        public TestController()
        {
            _context = new DataContext();
        }
        // GET: Test
        public async Task<ActionResult> TestList()
        {
            var reservations = await _context.Reservations.ToListAsync();
            var reservationsDto = AutoMapper.Mapper.Map<List<ReservationDTO>>(reservations);

            return View(reservationsDto);
        }
    }
}