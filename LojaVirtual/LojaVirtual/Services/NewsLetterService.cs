using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Database.Interfaces;
using LojaVirtual.Models;

namespace LojaVirtual.Database.Services
{
    public class NewsLetterService : INewsLetterService
    {
        private LojaVirtualContext _lojaVirtualContextData;

        public NewsLetterService(LojaVirtualContext banco)
        {
            _lojaVirtualContextData = banco;
        }

        public void cadastrar(NewsletterEmail news)
        {
            _lojaVirtualContextData.NewsletterEmails.Add(news);
            _lojaVirtualContextData.SaveChanges();
        }
        public IEnumerable<NewsletterEmail> obterTodos()
        {
            var news = _lojaVirtualContextData.NewsletterEmails.ToList();
            return news;
        }
    }
}