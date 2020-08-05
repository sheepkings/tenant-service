using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.API.Models;

namespace Presentation.API.Controllers
{
    [ApiController]
    [Route("tenant")]
    public class TenantController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TenantController> _logger;

        public TenantController(ILogger<TenantController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TenantViewModel>> Get()
        {
            try
            {
                var rng = new Random();
                
                var result = Enumerable.Range(1, 10).Select(index => new TenantViewModel
                {
                    Id = Guid.NewGuid(),
                    Name = Summaries[rng.Next(Summaries.Length)],
                    Active = rng.Next(-20, 55) % 2 == 0
                })
                .ToArray();

                return new OkObjectResult(result);    
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GET - Error on execution");
                return new BadRequestObjectResult(ModelState);
            }
        }
    }
}