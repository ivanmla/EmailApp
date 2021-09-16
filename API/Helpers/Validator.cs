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
                messages.Add("'From' field is required.");
            }
            else
            {
                if (!IsEmailAddressValid(emailMessageDto.From))
                {
                    messages.Add("'From': Email address is invalid.");
                }
                if (emailMessageDto.From.Length > 100)
                {
                    messages.Add("'From': Maximum input characters in this field is 100.");
                }
            }

            if (string.IsNullOrWhiteSpace(emailMessageDto.To))
            {
                messages.Add("'To' field is required.");
            }
            else
            {
                if (!IsEmailAddressValid(emailMessageDto.To))
                {
                    messages.Add("'To': Email address is invalid.");
                }
                if (emailMessageDto.To.Length > 100)
                {
                    messages.Add("'To': Maximum input characters in this field is 100.");
                }
            }

            if (!string.IsNullOrWhiteSpace(emailMessageDto.Cc))
            {
                if (emailMessageDto.Cc.Length > 100)
                {
                    messages.Add("'Cc': Maximum input characters in this field is 100.");
                }

                var listaAdresa = EmailMapper.GetAddressList(emailMessageDto.Cc);
                foreach (var item in listaAdresa)
                {
                    if(!IsEmailAddressValid(item))
                    {
                        messages.Add("'Cc': Email address is invalid.");
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(emailMessageDto.Subject))
            {
                messages.Add("'Subject' field is required.");
            }
            else
            {
                if (emailMessageDto.Subject.Length > 100)
                {
                    messages.Add("'Subject': Maximum input characters in this field is 100.");
                }
            }

            if (string.IsNullOrWhiteSpace(emailMessageDto.Importance))
            {
                messages.Add("'Importance' field is required.");
            }
            else
            {
                string[] importances = { "low", "medium", "high" };
                if (!importances.Contains(emailMessageDto.Importance.ToLower()))
                {
                    messages.Add("'Importance' is not valid value.");
                }
            }

            if (string.IsNullOrWhiteSpace(emailMessageDto.Content))
            {
                messages.Add("'Content' field is required.");
            }
            else
            {
                if (emailMessageDto.Content.Length > 100)
                {
                    messages.Add("'Content': Maximum input characters in this field is 100.");
                }
            }

            return new ValidationResult(messages);
        }

        private bool IsEmailAddressValid(string adresa)
        {
            return Regex.IsMatch(adresa, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
        }
    }
}