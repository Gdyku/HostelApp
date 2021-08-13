using ClientService.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Interface
{
    public interface IGuestLogic
    {
        Task<List<GuestDTO>> GetGuests();
        Task<GuestDTO> GetGuest(long Id);
        Task CreateGuest(GuestDTO guest);
        Task EditGuest(GuestDTO guest);
        Task DeleteGuest(long Id);
        Task<List<GuestDTO>> GetSpecificGuests();
    }
}
