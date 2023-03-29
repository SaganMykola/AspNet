using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Module.Controllers
{
    public class ModuleController : Controller
    {
        [HttpGet("task1")]
        public ActionResult Cosine(int r)
        {
            if (r > 20)
            {
                return BadRequest("r повинно бути більше 20");
            }
            int R = 20;
            double S = Math.PI*(R^2 - r^2);

            return Ok(S);
        }

        [HttpGet("task2")]
        public double CalculateCosSum(int n)
        {
            if (n < 1)
            {
                throw new ArgumentException("n не натуральне число");
            }

            int count = 0;

            while (n != 0)
            {
                count++;
                n /= 10;
            }

            return (count);
        }
    }
}
