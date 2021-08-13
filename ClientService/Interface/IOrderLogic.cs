using ClientService.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Interface
{
    public interface IOrderLogic
    {
        Task CreateOrder(OrderDataDTO order);
    }
}
