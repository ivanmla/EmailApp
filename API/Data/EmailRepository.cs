using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DataContext _context;

        public EmailRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Email>> GetEmailsAsync()
        {
            var result = await _context.Emails
                //.Include(e => e.Tos)
                .ToListAsync();

            return result;
        }
    }
}
