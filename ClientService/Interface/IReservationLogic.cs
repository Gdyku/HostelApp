using ClientService.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ClientService.Interface
{
    public interface IReservationLogic
    {
        Task<List<ReservationDTO>> GetReservations();
        Task<ReservationDTO> GetReservation(long Id);
        Task CreateReservation(ReservationDTO reservation);
        Task EditReservation(ReservationDTO reservation);
        Task RemoveReservation(long Id);
    }
}