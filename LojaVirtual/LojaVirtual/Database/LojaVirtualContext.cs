using LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Database
{
    public class LojaVirtualContext : DbContext
    {
        /*EF Core -> ORM*/
        /*ORM-> Biblioteca maperar objetos para o banco de dados relacionais */
        public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options):base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }

    }
}
