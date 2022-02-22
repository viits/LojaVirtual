using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LojaVirtual.Libraries.Email;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult ContatoAcao()
        {

            try
            {

                Contato contato = new Contato();

                contato.Nome = HttpContext.Request.Form["nome"];
                contato.Email = HttpContext.Request.Form["email"];
                contato.Texto = HttpContext.Request.Form["texto"];
                var listaMensagens = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);
                bool isValid = Validator.TryValidateObject(contato, contexto, listaMensagens, true);
                if (isValid)
                {
                    ContatoEmail.enviarContatoPorEmail(contato);
                    ViewData["MSG_S"] = "Enviado com sucesso!";
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var text in listaMensagens)
                    {
                        sb.Append(text.ErrorMessage + "<br />");
                    }
                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["CONTATO"] = contato;
                }

            }
            catch (Exception e)
            {
                ViewData["MSG_E"] = "Ocorreu um erro, tente novamente mais tarde!";
            }
            return View("Contato");

            // return new ContentResult() { Content = string.Format("Dados Recebidos com Sucesso! Nome: {0} <br/> Email: {1} <br/> Texto: {2}", contato.Nome, contato.Email, contato.Texto), ContentType = "text/html" };
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult CadastroCliente()
        {
            return View();
        }
        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}