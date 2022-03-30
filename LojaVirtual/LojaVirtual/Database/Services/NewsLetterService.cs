using System.Threading.Tasks;
using LojaVirtual.Database.Interfaces;
using LojaVirtual.Models;

namespace LojaVirtual.Database.Services
{
    public class NewsLetterService : INewsLetter
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
    }
}