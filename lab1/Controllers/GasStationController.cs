using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab1.Services.Repositories;
using lab1.Models;

namespace lab1.Controllers
{
    public class GasStationController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class GasStationsController : ControllerBase
        {
            private readonly IRepository<GasStation> service;

            public GasStationsController(IRepository<GasStation> service)
            {
                this.service = service;
            }

            [HttpGet]
            public IActionResult Read()
            {
                return Ok(service.Read());
            }

            [HttpGet("{id}")]
            public IActionResult ReadById(int id)
            {
                return Ok(service.Read(id));
            }

            [HttpPost]
            public IActionResult Create([FromBody] GasStation gas_station)
            {
                return Ok(service.Create(gas_station));
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                service.Delete(id);
                return Ok();
            }

            [HttpPut("{id}")]
            public IActionResult Update(int id, [FromBody] GasStation gas_station)
            {
                gas_station.Id = id;
                service.Update(gas_station);
                return Ok();
            }
        }
    }
}
