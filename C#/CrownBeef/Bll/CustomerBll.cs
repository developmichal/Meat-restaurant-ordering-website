using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using IBll;
using IDal;


namespace Bll
{
    public class CustomerBll : IBll.IBllCustomer
    {
        IDal.IDalCustomer dalC;

        public CustomerBll(IDal.IDalCustomer c)
        {
            this.dalC = c;
        }

        public async Task<Dto.CustomerDto> AddCustomerAsync(CustomerDto customerDto)
        {
            return await dalC.AddCustomerAsync(customerDto);
        }

        public async Task<List<Dto.CustomerDto>> SelectAllAsync()
        {
            return await dalC.SelectAllAsync();
        }

        public async Task<CustomerDto> SelectById(string email)
        {
            var allUsers = await dalC.SelectAllAsync();

            var user = allUsers.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (user == null)
            {
                return null;
            }

            return await dalC.SelectById(email);
        }
    }
}


