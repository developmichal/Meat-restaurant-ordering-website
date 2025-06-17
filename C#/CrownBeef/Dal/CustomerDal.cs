using Dal.models;
using Dto;
using Microsoft.EntityFrameworkCore;


namespace Dal
{
    public class CustomerDal : IDal.IDalCustomer
    {
        CrownBeefContext db;
        public CustomerDal(CrownBeefContext db)
        {
            this.db = db;
        }
        public async Task<List<Dto.CustomerDto>> SelectAllAsync()
        {
            var customer = await db.Customers.ToListAsync();
            return Converters.CustomerConverters.ToListCustomerDto(customer);
        }
        public async Task<Dto.CustomerDto> AddCustomerAsync(CustomerDto customerDto)
        {
            var customerEntity = Converters.CustomerConverters.ToCustomer(new CustomerDto
            {
                CustomerName = customerDto.CustomerName,
                Phone = customerDto.Phone,
                Email = customerDto.Email,
                DateOfBirth = customerDto.DateOfBirth
            });

            db.Customers.Add(customerEntity);
            await db.SaveChangesAsync();
            return customerDto;
        }

        public async Task<CustomerDto> SelectById(string email)
        {
            var obj = await db.Customers.FirstOrDefaultAsync(obj => obj.Email == email);
            if (email == null)
                return null;
            else
                return Dal.Converters.CustomerConverters.ToCustomerDto(obj);
        }
    }
}
