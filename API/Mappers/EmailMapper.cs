using System.Collections.Generic;
using API.Models;
using API.Models.Dto;

namespace API.Mappers
{
    public static class EmailMapper
    {
        public static List<EmailMessageDto> MapToDto(IEnumerable<EmailMessage> emails)
        {
            var dtos = new List<EmailMessageDto>();

            foreach (var item in emails)
            {
                var dto = new EmailMessageDto
                {
                    From = item.From,
                    To = item.To,
                    Cc = MapAddressesToDto(item.Cc),
                    Importance = item.Importance,
                    Subject = item.Subject,
                    Content = item.Content
                };

                dtos.Add(dto);
            }

            return dtos;
        }

        public static EmailMessage MapFromDto(EmailMessageDto emailMessageDto)
        {
            var email = new EmailMessage
            {
                From = emailMessageDto.From,
                To = emailMessageDto.To,
                Cc = MapAddressesFromDto(emailMessageDto.Cc),
                Importance = emailMessageDto.Importance,
                Subject = emailMessageDto.Subject,
                Content = emailMessageDto.Content
            };

            return email;
        }


        private static string MapAddressesToDto(ICollection<EmailAddress> adresses)
        {
            var result = "";
            foreach (var item in adresses)
            {
                result += item.To + "; ";
            }

            return result;
        }

        private static List<EmailAddress> MapAddressesFromDto(string emailAdressDto)
        {
            var adrese = new List<EmailAddress>();

            var dtoList = GetAddressList(emailAdressDto);

            foreach (var item in dtoList)
            {
                var email = new EmailAddress
                {
                    To = item
                };
                
                adrese.Add(email);
            }

            return adrese;
        }

        public static List<string> GetAddressList(string emailAdressDto)
        {
            var addressList = new List<string>();

            char delimiter = ';';
            string[] emails = emailAdressDto.Split(delimiter);

            foreach (var item in emails)
            {
                var trimaniItem = item.TrimEnd().TrimStart();                
                addressList.Add(trimaniItem);
            }

            return addressList;
        }
    }
}
