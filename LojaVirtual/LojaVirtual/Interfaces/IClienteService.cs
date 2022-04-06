using System.Collections.Generic;
using LojaVirtual.Models;

namespace LojaVirtual.Database.Interfaces
{
    public interface IClienteService : IService
    {
        Cliente login(string email, string senha);
        void cadastrar(Cliente cliente);
        void atualizar(int id, Cliente cliente);
        void excluir(int id);
        Cliente obterCliente(int id);
        List<Cliente> getAllCliente();
    }
}