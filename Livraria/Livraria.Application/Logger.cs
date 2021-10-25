using Livraria.Domain.Interfaces;
using Livraria.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Application
{
    public class Logger : ILogger
    {
        string path;
        public Logger(IConfiguration configuration)
        {
            path = configuration.GetSection("Log").Value;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, Microsoft.Extensions.Logging.EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }

        public void RegistrarLog(string texto)
        {
            Files.Registrar(texto, path);
        }
    }
}
