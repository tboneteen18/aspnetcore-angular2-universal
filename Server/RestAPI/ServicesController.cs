using AspCoreServer.Data;
using AspCoreServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreServer.Controllers
{
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        private readonly SpaDbContext _context;

        public ServicesController(SpaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var services = await _context.Service
                .OrderBy(u => u.ServiceId)
                .ToArrayAsync();

            if (!services.Any())
            {
                return NotFound("Services not Found");
            }
            else
            {
                return Ok(services);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var service = await _context.Service
                .Where(u => u.ServiceId == id)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ServiceId == id);

            if (service == null)
            {
                return NotFound("Service not Found");
            }
            else
            {
                return Ok(service);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Service service)
        {
            if (!string.IsNullOrEmpty(service.Name))
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Post", service);
            }
            else
            {
                return BadRequest("Services name was not given");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Service serviceUpdateValue)
        {
            try
            {
                //serviceUpdateValue.EntryTime = DateTime.Now;

                var serviceToEdit = await _context.Service
                  .AsNoTracking()
                  .SingleOrDefaultAsync(m => m.ServiceId == id);

                if (serviceToEdit == null)
                {
                    return NotFound("Could not update service as it was not Found");
                }
                else
                {
                    _context.Update(serviceUpdateValue);
                    await _context.SaveChangesAsync();
                    return Ok("Updated service - " + serviceUpdateValue.Name);
                }
            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
                return NotFound("Service not Found");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var serviceToRemove = await _context.Service
                .AsNoTracking()
            .SingleOrDefaultAsync(m => m.ServiceId == id);
            if (serviceToRemove == null)
            {
                return NotFound("Could not delete service as it was not Found");
            }
            else
            {
                _context.Service.Remove(serviceToRemove);
                await _context.SaveChangesAsync();
                return Ok("Deleted service - " + serviceToRemove.Name);
            }
        }
    }
}
