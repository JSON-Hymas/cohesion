using cohesion.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cohesion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaintenanceServiceController : ControllerBase
    {
        public IEnumerable<MaintenanceServiceModel> serviceRequests { get; set; }

        [HttpGet]
        public IEnumerable<MaintenanceServiceModel> Get()
        {
            return serviceRequests;
        }
    }
}
