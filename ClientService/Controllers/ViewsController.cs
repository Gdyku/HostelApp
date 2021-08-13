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
        public ViewsController()
        {
        }

        public ActionResult ReservationsList()
        {
            return View();
        }

        public ActionResult GuestsList()
        {
            return View();
        }
    }
}