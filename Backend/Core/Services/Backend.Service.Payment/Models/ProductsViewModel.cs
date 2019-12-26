using System.Collections.Generic;

namespace Backend.Service.Payment.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}