using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    public class CustomerConverters
    {
        public static Dto.CustomerDto ToCustomerDto(Dal.models.Customer customer)
        {
            Dto.CustomerDto newCustomer = new Dto.CustomerDto();
            newCustomer.CustomerCode = customer.CustomerCode;
            newCustomer.CustomerName = customer.CustomerName;
            newCustomer.Phone = customer.Phone;
            newCustomer.Email = customer.Email;
            newCustomer.DateOfBirth = customer.DateOfBirth.ToString("yyyy-MM-dd");

            return newCustomer;
        }

        public static List<Dto.CustomerDto> ToListCustomerDto(List<Dal.models.Customer> listCustomerDto)
        {
            List<Dto.CustomerDto> newlistCustomer = new List<Dto.CustomerDto>();
            foreach (Dal.models.Customer customer in listCustomerDto)
            {
                newlistCustomer.Add(ToCustomerDto(customer));
            }
            return newlistCustomer;
            ;
        }

        public static Dal.models.Customer ToCustomer(Dto.CustomerDto customer)
        {
            Dal.models.Customer newCustomer = new Dal.models.Customer();
            newCustomer.CustomerName = customer.CustomerName;
            newCustomer.Phone = customer.Phone;
            newCustomer.Email = customer.Email;
            newCustomer.DateOfBirth = DateOnly.ParseExact(customer.DateOfBirth, "yyyy-MM-dd");
            return newCustomer;
        }
    }
}
