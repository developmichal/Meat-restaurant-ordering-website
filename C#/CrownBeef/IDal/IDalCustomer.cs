using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal
{
    public interface IDalCustomer : IDal.IDal<Dto.CustomerDto>
    {
        Task<Dto.CustomerDto> AddCustomerAsync(CustomerDto customerDto);
        public Task<Dto.CustomerDto> SelectById(string email);

    }
}
