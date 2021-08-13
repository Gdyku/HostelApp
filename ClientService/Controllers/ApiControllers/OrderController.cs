using ClientService.DtoModels;
using ClientService.Interface;
using ClientService.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ClientService.Controllers.ApiControllers
{
    //Route: api/controller/action
    public class OrderController : ApiController
    {
        private readonly IOrderLogic _logic;
        public OrderController()
        {
            _logic = new OrderLogic();
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateOrder(OrderDataDTO order)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            await _logic.CreateOrder(order);

            return Ok();
        }
    }
}
