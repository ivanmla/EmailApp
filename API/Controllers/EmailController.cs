using API.Data;
using API.Models;
using API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepository _emailRepository;

        public EmailController(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<IEnumerable<EmailMessage>>> GetAll()
        {
            var result = await _emailRepository.GetAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("send")]
        public async Task<ActionResult<bool>> Save(EmailMessageDto emailMessageDto)
        {    
            var email = new EmailMessage
            {
                From = emailMessageDto.From,
                To = emailMessageDto.To,
                Cc = MapEmailAddresses(emailMessageDto.To),
                Importance = emailMessageDto.Importance,
                Subject = emailMessageDto.Subject,
                Content = emailMessageDto.Content
            };

            var result = await _emailRepository.SaveAsync(email);            
            
            return Ok(result);
        }

        private List<EmailAddress> MapEmailAddresses(string emailAdressDto)
        {
            var adrese = new List<EmailAddress>();//validate Email adress!
            // Odvojiti po ;
            var fakeAdresa = new EmailAddress
            {
                To = "fake@fake.hr"
            };

            adrese.Add(fakeAdresa);

            return adrese;
        }
    }
}