using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        [HttpGet("Visualizar")]
        /*
         Retornar sempre um ActionResult ou IActionResult
         */
        public ActionResult Visualizar()
        {
            /*return new ContentResult() { Content = "Product -> Visualizar", ContentType = "text/html" };
*/          Product p = getProduct();
            return View(p);
        }
        private Product getProduct()
        {
            return new Product()
            {
                Id = 1,
                Nome = "Ps5",
                Descricao = "Jogue em 4K",
                Valor = 5000
            };
        }
    }
}
