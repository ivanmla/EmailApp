using API.Models;
using API.Models.Dto;
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

        public async Task<IEnumerable<EmailMessage>> GetAsync()
        {
            var result = await _context.EmailMessages
                .Include(e => e.Cc)
                .ToListAsync();

            return result;
        }

        public async Task<bool> SaveAsync(EmailMessage email)
        {
            var insert = _context.EmailMessages.Add(email);
            var success = await _context.SaveChangesAsync();

            return success > 0 ? true : false;
        }
    }
}
