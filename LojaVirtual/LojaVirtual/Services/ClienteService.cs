using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Database.Interfaces;
using LojaVirtual.Models;

namespace LojaVirtual.Database.Services
{
    public class ClienteService : IClienteService
    {
        private LojaVirtualContext _repository;
        public ClienteService(LojaVirtualContext repository)
        {
            _repository = repository;
        }

        public void atualizar(int id, Cliente clienteAtt)
        {
            Cliente cliente = obterCliente(id);
            if (cliente != null)
            {
                cliente.Nome = clienteAtt.Nome;
                cliente.CPF = clienteAtt.CPF;
                cliente.Nascimento = clienteAtt.Nascimento;
                cliente.Sexo = clienteAtt.Sexo;
                cliente.Telefone = clienteAtt.Telefone;
                cliente.Email = clienteAtt.Email;
                cliente.Senha = clienteAtt.Senha;
                _repository.Clientes.Update(cliente);
                _repository.SaveChanges();
            }
        }

        public void cadastrar(Cliente cliente)
        {
            _repository.Clientes.Add(cliente);
            _repository.SaveChanges();
        }

        public void excluir(int id)
        {
            var cliente = obterCliente(id);
            if (cliente != null)
            {
                _repository.Clientes.Remove(cliente);
                _repository.SaveChanges();
            }

        }

        public List<Cliente> getAllCliente()
        {
            return _repository.Clientes.ToList();
        }

        public Cliente login(string email, string senha)
        {
            var cliente = _repository.Clientes.Where(m => m.Email == email && m.Senha == senha).First();
            return cliente;
        }

        public Cliente obterCliente(int id)
        {
            return _repository.Clientes.Find(id);
        }
    }
}