using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrenRezervasyon.Infrastructure;
using TrenRezervasyon.Infrastructure.Data;

namespace TrenRezervasyon.Infrastructure
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<TrenRezervasyonAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
        }
    }
}
