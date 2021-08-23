using cohesion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cohesion.Contexts
{
    public class ServiceRequestContext : DbContext
    {
        public ServiceRequestContext(DbContextOptions<ServiceRequestContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceRequest> ServiceRequests { get; set; }
    }
}
