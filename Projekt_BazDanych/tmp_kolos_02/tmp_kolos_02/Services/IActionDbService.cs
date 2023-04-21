using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmp_kolos_02.DTO;
using tmp_kolos_02.Entities;

namespace tmp_kolos_02.Services
{
    public interface IActionDbService
    {
        Task<ActionDTO> GetFireTrucksInActionAsync(int IdAction);
        Task<MethodResultDTO> AddFireTruckToActionAsync(int IdAction, int IdFireTruck);

        Task<MethodResultDTO> DeleteTruckById(int IdFireTruck);
    }
}
