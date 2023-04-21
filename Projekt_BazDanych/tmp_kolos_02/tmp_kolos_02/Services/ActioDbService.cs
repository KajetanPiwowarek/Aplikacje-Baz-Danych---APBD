using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using tmp_kolos_02.DTO;
using tmp_kolos_02.Entities;

namespace tmp_kolos_02.Services
{
    public class ActioDbService : IActionDbService
    {
        private readonly FireContext _context;
        public ActioDbService(FireContext context)
        {
            _context = context;
        }

        public async Task<MethodResultDTO> AddFireTruckToActionAsync(int IdAction, int IdFireTruck)
        {
            var truckExists = _context.FireTrucks.Any(x => x.IdFireTruck == IdFireTruck);
            if (!truckExists)
            {
                return new MethodResultDTO
                {
                    HttpStatusCode = HttpStatusCode.NotFound,
                    Message = "Truck does not exist in the db"
                };
            }

            var actionExists = _context.Actions.Any(x => x.IdAction == IdAction);
            if (!actionExists)
            {
                return new MethodResultDTO
                {
                    HttpStatusCode = HttpStatusCode.NotFound,
                    Message = "Action does not exist in the db"
                };
            }

            var count = _context.Actions
                .Where(x => x.IdAction == IdAction)
                .Include(x => x.FireTruckActions)
                .Count();
            if (count >= 3)
            {
                return new MethodResultDTO
                {
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    Message = "Action has already assigmed 3 Trucks"
                };
            }

            var needSpecialEquipment = _context.Actions
                .Where(x => x.IdAction == IdAction)
                .Select(x => x.NeedSpecialEquipment)
                .FirstOrDefault();

            if (needSpecialEquipment)
            {
                var truckHasEquipment = _context.FireTrucks
                    .Where(x => x.IdFireTruck == IdFireTruck)
                    .Select(x => x.SpecialEquipment)
                    .FirstOrDefault();
                if (!truckHasEquipment)
                {
                    return new MethodResultDTO
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                        Message = "Truck does not have special equipment"
                    };
                }
            }

            var actionHasEnded = _context.Actions
                .Where(x => x.IdAction == IdAction)
                .Select(x => x.EndTime)
                .FirstOrDefault();
            if (actionHasEnded < DateTime.Now)
            {
                return new MethodResultDTO
                {
                    HttpStatusCode = HttpStatusCode.BadRequest,
                    Message = "Action has ended"
                };
            }

            var res = await _context.FireTruckActions.AddAsync(new FireTruckAction
            {
                IdAction = IdAction,
                IdFireTruck = IdFireTruck,
                AssigmentDate = DateTime.Now
            });

            await _context.SaveChangesAsync();

            return new MethodResultDTO
            {
                HttpStatusCode = HttpStatusCode.OK,
                Message = "Truck added to Action"
            };
        }

        public async Task<MethodResultDTO> DeleteTruckById(int IdFireTruck)
        {
            FireTruck fireTruck = _context
                .FireTrucks
                .Where(x => x.IdFireTruck == IdFireTruck)
                .FirstOrDefault();

            if (fireTruck == null)
            {
                return new MethodResultDTO
                {
                    HttpStatusCode = HttpStatusCode.NotFound,
                    Message = "Truck does not exist in the db"
                };
            }

            _context.Remove(fireTruck);

            await _context.SaveChangesAsync();

            return new MethodResultDTO
            {
                HttpStatusCode = HttpStatusCode.OK,
                Message = "Truck has been deleted"
            };
        }

        public async Task<ActionDTO> GetFireTrucksInActionAsync(int IdAction)
        {
            var result = _context
                .Actions
                .Where(x => x.IdAction == IdAction)
                .Include(x => x.FireTruckActions).ThenInclude(x => x.IdFireTruckNavigation)
                .Select(x => new ActionDTO
                {
                    IdAction = x.IdAction,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    NeedSpecialEquipment = x.NeedSpecialEquipment,
                    FireTrucks = x.FireTruckActions.Select(y => new FireTruckDTO
                    {
                        IdFireTruck = y.IdFireTruckNavigation.IdFireTruck,
                        OperationNumber = y.IdFireTruckNavigation.OperationNumber,
                        SpecialEquipment = y.IdFireTruckNavigation.SpecialEquipment,
                        AssigmentDate = y.AssigmentDate
                    })
                    .OrderByDescending(y => y.AssigmentDate)
                    .ToList()
                })
                .FirstOrDefaultAsync();

            return await result;      
        }


    }
}
