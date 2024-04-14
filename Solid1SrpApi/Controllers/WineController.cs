using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solid1SrpApi.Models.ViewModels;
using Solid1SrpApi.Services;
using System;

namespace Solid1SrpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string Message = "GET request to WineController";
            Console.WriteLine(Message);
            return Ok(Message);
        }

        [HttpPost]
        public IActionResult Create(WineViewModel wineViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var wineService = new WineService();
            return Ok(wineService.Create(wineViewModel));
        }
    }
}
