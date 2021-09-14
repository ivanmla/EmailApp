using API.Data;
using API.Helpers;
using API.Mappers;
using API.Models;
using API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepository _emailRepository;
        private readonly Validator _validator;

        public EmailController(IEmailRepository emailRepository, Validator validator)
        {
            _emailRepository = emailRepository;
            _validator = validator;
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
            var validationResult = _validator.ValidateEmail(emailMessageDto);

            if (validationResult != null && validationResult.Errors.Any())
            {
                return BadRequest(validationResult);
            }

            var email = EmailMapper.MapFromDto(emailMessageDto);

            var result = await _emailRepository.SaveAsync(email);
            return Ok(result);
        }
    }
}