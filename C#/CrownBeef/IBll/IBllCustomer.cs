using Dto;
using IBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    public interface IBllCustomer : IBllServices<Dto.CustomerDto>
    {
        Task<Dto.CustomerDto> AddCustomerAsync(CustomerDto customerDto);
        Task<Dto.CustomerDto> SelectById(string email);

    }
}
