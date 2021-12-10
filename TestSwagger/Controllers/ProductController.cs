using BAL.Models;
using BAL.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAllProduct()
        {
            return _productService.GetAll();
        }

        [HttpGet("product/{id}")]
        public ActionResult<Product> GetById(string id)
        {
            var prodResult = _productService.GetProductById(id);
            if (prodResult != null)
            {
                return prodResult;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult<Product> EditProduct(Product product)
        {
            var resProd = _productService.EditProduct(product);
            if(resProd != null)
            {
                return resProd;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public ActionResult DeleteProduct(string id)
        {
            var resProd = _productService.DeleteProduct(id);
            if(resProd)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public ActionResult<Product> Addproduct(Product product)
        {
            return _productService.AddProduct(product);
        }

    }
}
