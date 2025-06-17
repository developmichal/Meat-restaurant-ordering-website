using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ProductDto
    {
        public short ProductCode { get; set; }

        public string ProductName { get; set; } = null!;

        public short CategoryCode { get; set; }

        public string ProductDescription { get; set; } = null!;

        public short Price { get; set; }

        public string Picture { get; set; } = null!;

        public short QuantityInStock { get; set; }

        public string LastUpdateDate { get; set; }
     
        public short Quantity { get; set; }
    }
}
