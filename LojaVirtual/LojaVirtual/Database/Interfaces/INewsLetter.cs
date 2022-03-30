using System.Threading.Tasks;
using LojaVirtual.Models;

namespace LojaVirtual.Database.Interfaces
{
    public interface INewsLetter
    {
        void cadastrar(NewsletterEmail news);
    }
}