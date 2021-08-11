using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientService.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using ClientService.DtoModels;

namespace ClientService.Controllers
{
    public class ViewsController : Controller
    {
        private readonly DataContext _context;
        public ViewsController()
        {
            _context = new DataContext();
        }

        // GET: Views
        public async Task<ActionResult> ReservationsList()
        {
            var reservations = await _context.Reservations.ToListAsync();
            var reservationsDto = AutoMapper.Mapper.Map<List<ReservationDTO>>(reservations);

            return View(reservationsDto);
        }
    }
}