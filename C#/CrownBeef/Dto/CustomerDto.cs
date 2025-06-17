using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CustomerDto
    {
        public short CustomerCode { get; set; }

        public string CustomerName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string DateOfBirth { get; set; }

    }
}
