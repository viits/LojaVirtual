using LojaVirtual.Libraries.Sessao;
using LojaVirtual.Models;
using Newtonsoft.Json;
namespace LojaVirtual.Libraries.Login
{
    public class LoginCliente
    {
        private string Key = "Login.Cliente";
        private Sessao.Sessao _sessao;
        public LoginCliente(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void SalvarCliente(Cliente cliente)
        {
            //Armazenando sessao
            string clienteString = JsonConvert.SerializeObject(cliente);
            _sessao.Cadastrar(Key, clienteString);
        }

        public Cliente ObterCliente()
        {
            if (_sessao.Existe(Key))
            {
                string clienteString = _sessao.Consultar(Key);
                return JsonConvert.DeserializeObject<Cliente>(clienteString);
            }
            return null;

        }
        public void Logout()
        {
            _sessao.RemoverTodos();
        }

    }
}