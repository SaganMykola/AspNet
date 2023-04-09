using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab2.Services.Repositories;
using lab2.Models;

namespace lab2.Controllers
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
            public IActionResult Read(
                [FromQuery] GasStation filterBy,
                [FromQuery] string orderBy = "Id",
                [FromQuery] string order = "asc",
                [FromQuery] int page = 1,
                [FromQuery] int perPage = 25)

            {
                return Ok(new
                {
                    Status = 200,
                    Data = new
                    {
                        count = service.Count(filterBy),
                        items = service.Read(filterBy, orderBy, order, page, perPage)
                    }
                });
            }

            [HttpGet("{id}")]
            public IActionResult ReadById(int id)
            {
                return Ok(service.Read(id));
            }

            [HttpPost]
            public IActionResult Create([FromBody] GasStation gas_station)
            {
                var errors = new Dictionary<string, List<string>>();
                if (service.AddressExist(gas_station))
                {
                    errors.Add("Address", new List<string>() { "A station with this adress already exists." });
                }

                if (errors.Count > 0)
                {
                    return BadRequest(new Response()
                    {
                        Status = 400,
                        Errors = errors
                    });
                }

                return Created(nameof(GasStation), new Response()
                {
                    Status = 201,
                    Data = service.Create(gas_station)
                });
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                service.Delete(id);
                return Ok(new Response()
                {
                    Status = 200
                });
            }

            [HttpPut("{id}")]
            public IActionResult Update(int id, [FromBody] GasStation gas_station)
            {
                gas_station.Id = id;

                var errors = new Dictionary<string, List<string>>();
                if (service.AddressExist(gas_station))
                {
                    errors.Add("Address", new List<string>() { "A station with this adress already exists." });
                }

                if (errors.Count > 0)
                {
                    return BadRequest(new Response()
                    {
                        Status = 400,
                        Errors = errors
                    });
                }

                service.Update(gas_station);

                return Ok(new Response()
                {
                    Status = 200
                });
            }
        }
    }
}
