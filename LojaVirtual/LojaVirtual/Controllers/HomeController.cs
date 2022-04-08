using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LojaVirtual.Database;
using LojaVirtual.Database.Interfaces;
using LojaVirtual.Libraries.Email;
using LojaVirtual.Libraries.Login;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsLetterService _newsLetterEmail;
        private readonly IClienteService _clienteService;

        private readonly LoginCliente _loginCliente;
        public HomeController(INewsLetterService newsLetter, IClienteService clienteService, LoginCliente loginCliente)
        {
            _newsLetterEmail = newsLetter;
            _clienteService = clienteService;
            _loginCliente = loginCliente;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm] NewsletterEmail newsletter)
        {
            // Add to the database
            if (ModelState.IsValid)
            {
                _newsLetterEmail.cadastrar(newsletter);
                TempData["MSG_S"] = "E-mail cadastrado, agora você vai receber promoções especiais no seu e-mail";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
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
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm] Cliente cliente)
        {

            Cliente clienteDb = _clienteService.login(cliente.Email, cliente.Senha);
            if (clienteDb != null)
            {
                _loginCliente.SalvarCliente(clienteDb);
                return new RedirectResult(Url.Action(nameof(Painel)));
            }
            else
            {
                ViewData["MSG_E"] = "Usuário ou senha inválidas";
                return View();
            }

        }

        [HttpGet]
        public IActionResult Painel()
        {
            Cliente cliente = _loginCliente.ObterCliente();
            if (cliente != null)
            {
                return new ContentResult() { Content = "Acesso Concedido: " + cliente };
            }
            else
            {
                return new ContentResult() { Content = "Acesso Negado : " };
            }
        }

        [HttpGet]
        public IActionResult CadastroCliente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastroCliente([FromForm] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteService.cadastrar(cliente);
                TempData["MSG_S"] = "Cadastro realizado com sucesso!";
                return RedirectToAction(nameof(CadastroCliente));
            }
            return View();

        }
        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}