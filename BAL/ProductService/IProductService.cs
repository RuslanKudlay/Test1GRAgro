using BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ProductService
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetProductById(string id);
        Product AddProduct(Product product);
        Product EditProduct(Product product);
        bool DeleteProduct(string id);


    }
}
