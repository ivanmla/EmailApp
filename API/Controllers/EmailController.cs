using API.Data;
using API.Mappers;
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
        public async Task<ActionResult<List<EmailMessageDto>>> GetAll()
        {
            var result = await _emailRepository.GetAsync();

            var mappedResult = EmailMapper.MapToDto(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("send")]
        public async Task<ActionResult<bool>> Save(EmailMessageDto emailMessageDto)
        {
            var email = EmailMapper.MapFromDto(emailMessageDto);

            var result = await _emailRepository.SaveAsync(email);
            return Ok(result);
        }
    }
}