using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Infrastructure.Entities
{
    public  class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
    }
}
