using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Percobaan_Agit2.Data;
using System.Data.Entity;

namespace Percobaan_Agit2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevenueController : ControllerBase
    {
        private readonly DBcontext _context;

        public RevenueController(DBcontext context)
        {
            _context = context;
        }

        [HttpGet("itemgroup")]
        public async Task<IActionResult> GetItemGroupData()
        {
            var data = await _context.ItemGroupRevenue
                .GroupBy(x => x.ItemType)
                .Select(g => new
                {
                    Category = g.Key,
                    Amount = g.Sum(x => (x.UnitPrice ?? 0) * (x.UnitsSold ?? 0)) 
                })
                .ToListAsync();

            return Ok(data);
        }

        [HttpGet("country")]
        public async Task<IActionResult> GetCountryData()
        {
            var data = await _context.CountryRevenue
                .GroupBy(x => x.Country)
                .Select(g => new
                {
                    Category = g.Key,
                    Amount = g.Sum(x => (x.UnitPrice ?? 0) * (x.UnitsSold ?? 0)) 
                })
                .ToListAsync();

            return Ok(data);
        }
    }
}
