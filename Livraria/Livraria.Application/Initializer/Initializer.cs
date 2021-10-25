using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using Livraria.Domain.Services;
using Livraria.Infra.Context;
using Livraria.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application.Initializer
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services, string conection)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conection));

            #region Livro
            services.AddScoped(typeof(IRepository<Livro>), typeof(LivroRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(LivroService));
            #endregion

            services.AddSingleton<ILogger, Logger>();
        }
    }
}
