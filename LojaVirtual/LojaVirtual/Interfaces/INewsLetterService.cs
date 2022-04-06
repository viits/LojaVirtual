using System.Collections.Generic;
using LojaVirtual.Models;

namespace LojaVirtual.Database.Interfaces
{
    public interface INewsLetterService : IService
    {
        void cadastrar(NewsletterEmail news);
        IEnumerable<NewsletterEmail> obterTodos();
    }
}