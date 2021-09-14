using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using API.Enums;
using API.Mappers;
using API.Models.Dto;

namespace API.Helpers
{
    public class Validator
    {
        public ValidationResult ValidateEmail(EmailMessageDto emailMessageDto)
        {
            var messages = new List<string>();

            if (string.IsNullOrWhiteSpace(emailMessageDto.From))
            {
                messages.Add("'From' je obavezan podatak.");
            }
            else
            {
                if (!IsEmailAddressValid(emailMessageDto.From))
                {
                    messages.Add("'From': Neispravna e-mail adresa.");
                }
            }

            if (string.IsNullOrWhiteSpace(emailMessageDto.To))
            {
                messages.Add("'To' je obavezan podatak.");
            }
            else
            {
                if (!IsEmailAddressValid(emailMessageDto.To))
                {
                    messages.Add("'To': Neispravna e-mail adresa.");
                }
            }

            if (!string.IsNullOrWhiteSpace(emailMessageDto.Cc))
            {
                var listaAdresa = EmailMapper.GetAddressList(emailMessageDto.Cc);
                foreach (var item in listaAdresa)
                {
                    if(!IsEmailAddressValid(item))
                    {
                        messages.Add("'Cc': Neispravna e-mail adresa.");
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(emailMessageDto.Subject))
            {
                messages.Add("'Subject' je obavezan podatak.");
            }

            if (string.IsNullOrWhiteSpace(emailMessageDto.Importance))
            {
                messages.Add("'Importance' je obavezan podatak.");
            }
            else
            {
                string[] importances = { "low", "medium", "high" };
                if (!importances.Contains(emailMessageDto.Importance.ToLower()))
                {
                    messages.Add("'Importance' nije ispravna vrijednost.");
                }
            }

            if (string.IsNullOrWhiteSpace(emailMessageDto.Content))
            {
                messages.Add("'Content' je obavezan podatak.");
            }

            return new ValidationResult(messages);
        }

        private bool IsEmailAddressValid(string adresa)
        {
            return Regex.IsMatch(adresa, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
        }
    }
}