using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticDashboard.DataContext;
using CosmeticDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CosmeticDashboard.Controllers
{
    [Produces("application/json")]
    [Route("api/Location")]
    [ApiController]
    public class LocationValuesController : Controller
    {
        private readonly AspnetDbContext _db;

        public LocationValuesController(AspnetDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Factory> Factories { get; set; }

        [HttpGet("{locationCode}")]
        public async Task<IActionResult> GetLocation(string locationCode)
        {
            
            return Json(new { x = await _db.Factories.Where(x => x.LocationCode == locationCode).ToListAsync() });
        }

        
    }
}
