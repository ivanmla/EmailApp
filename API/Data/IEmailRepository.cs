using API.Models;
using API.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data
{
    public interface IEmailRepository
    {
        Task<IEnumerable<EmailMessage>> GetAsync();
        Task<bool> SaveAsync(EmailMessage email);
    }
}
