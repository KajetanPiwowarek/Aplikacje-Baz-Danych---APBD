using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmp_kolos_02.DTO;
using tmp_kolos_02.Services;

namespace tmp_kolos_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly IActionDbService _actionDbService;
        public ActionController(IActionDbService actionDbService)
        {
            _actionDbService = actionDbService;
        }

        [HttpGet("{IdAction}")]
        public async Task<IActionResult> GetFireTrucksInAction(int IdAction)
        {
            var trucksList = await _actionDbService.GetFireTrucksInActionAsync(IdAction);

            return Ok(trucksList);
        }

        [HttpPost("{IdFireTruck},{IdAction}")]
        public async Task<IActionResult> AddFireTruckToAction(int IdFireTruck, int IdAction)
        {
            var result = await _actionDbService.AddFireTruckToActionAsync(IdFireTruck, IdAction);

            return StatusCode((int)result.HttpStatusCode, result.Message);
        }

        [HttpDelete("{IdFireTruck}")]
        public async Task<IActionResult> DeleteTruckById(int IdFireTruck)
        {
            var result = await _actionDbService.DeleteTruckById(IdFireTruck);

            return StatusCode((int)result.HttpStatusCode, result.Message);
        }
    }
}
