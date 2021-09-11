using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data
{
    public interface IEmailRepository
    {
        Task<IEnumerable<Email>> GetEmailsAsync();
    }
}
