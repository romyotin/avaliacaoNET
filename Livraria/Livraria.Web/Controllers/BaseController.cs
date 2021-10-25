using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            
        }

        public void RegistrarLog(string metodo, string action, string descricao, object objeto = null)
        {
            if(objeto == null)
            {
                Log.ForContext(metodo, action).Information(descricao);
            }
            else
            {
                Log.ForContext(metodo, action).Information(descricao + objeto.ToString());
            }
            
        }
    }
}
