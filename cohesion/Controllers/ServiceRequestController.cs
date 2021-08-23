using cohesion.Enums;
using cohesion.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cohesion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestController : ControllerBase
    {
        public List<ServiceRequest> serviceRequests = new List<ServiceRequest>();

        [HttpGet]
        public IEnumerable<ServiceRequest> Get()
        {
            this.HttpContext.Response.StatusCode = serviceRequests.Any() ? 200 : 204;
            return serviceRequests;
        }

        [HttpGet("{id}")]
        public ServiceRequest Get(Guid id)
        {
            var serviceRequest = serviceRequests.FirstOrDefault(s => s.Id.Equals(id));
            this.HttpContext.Response.StatusCode = serviceRequest != null ? 200 : 404;
            return serviceRequest;
        }

        [HttpPost]
        public void Post(ServiceRequest serviceRequest)
        {
            if (!ValidServiceRequest(serviceRequest))
            {
                this.HttpContext.Response.StatusCode = 400;
            }
            else
            {
                this.HttpContext.Response.StatusCode = 201;
                serviceRequests.Add(serviceRequest);
            }
        }

        [HttpPut("{id}")]
        public void Put(Guid id, ServiceRequest serviceRequest)
        {
            if (id != serviceRequest.Id || !ValidServiceRequest(serviceRequest))
            {
                this.HttpContext.Response.StatusCode = 400;
                return;
            }

            var sRequest = serviceRequests.FirstOrDefault(s => s.Id == id);
            
            if (serviceRequest == null)
            {
                this.HttpContext.Response.StatusCode = 404;
            }
            else
            {
                //I don't love how this is removing/readding this element
                this.HttpContext.Response.StatusCode = 200;
                serviceRequests.Remove(sRequest);
                serviceRequests.Add(serviceRequest);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var serviceRequest = serviceRequests.FirstOrDefault(s => s.Id == id);
            if (serviceRequest == null)
            {
                this.HttpContext.Response.StatusCode = 404;
            }
            else
            {
                this.HttpContext.Response.StatusCode = 201;
                serviceRequests.Remove(serviceRequest);
            }
        }

        private bool ValidServiceRequest(ServiceRequest serviceRequest)
        {
            return true;
        }
    }
}
