using BAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IApplicationDbContext _dbContext;
        public ProductService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product AddProduct(Product product)
        {
            var resProd = new DAL.Entityes.Product
            {
                Name = product.Name,
                Color = product.Color,
                Form = product.Form,
                Weight = product.Weight,
                Price = product.Price
            };
            _dbContext.Products.Add(resProd);
            _dbContext.SaveChanges();
            return product;
        }

        public bool DeleteProduct(string id)
        {
            var prod = _dbContext.Products.FirstOrDefault(_ => _.Id == id);

            if(prod != null)
            {
                _dbContext.Products.Remove(prod);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public Product EditProduct(Product product)
        {
            var resProd = _dbContext.Products.FirstOrDefault(_ => _.Id == product.Id);
            if(resProd != null)
            {
                resProd.Id = product.Id;
                resProd.Name = product.Name;
                resProd.Color = product.Color;
                resProd.Form = product.Form;
                resProd.Weight = product.Weight;
                resProd.Price = product.Price;

                _dbContext.Products.Update(resProd);
                _dbContext.SaveChanges();
                return product;
            }
            else
            {
                return null;
            }
            
        }

        public List<Product> GetAll()
        {
            var product = _dbContext.Products.ToList();
            var prodResult = new List<Product>();
            foreach(var p in product)
            {
                var mappedProd = new Product { Name = p.Name, Color = p.Color, Form = p.Form, Weight = p.Weight, Price = p.Price };
                prodResult.Add(mappedProd);
            }
            return prodResult;
        }

        public Product GetProductById(string id)
        {
            var resProd = _dbContext.Products.FirstOrDefault(_ => _.Id == id);
            if(resProd != null)
            {
                var foundProd = new Product
                {
                    Id = resProd.Id,
                    Name = resProd.Name,
                    Color = resProd.Color,
                    Form = resProd.Form,
                    Weight = resProd.Weight,
                    Price = resProd.Price
                };
                return foundProd;
            }
            else
            {
                return null;
            }
        }
    }
}
