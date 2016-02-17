using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestProductApp.Models;

namespace TestProductApp.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[] 
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };

        
        
        

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [ActionName("test")]
        public IHttpActionResult AddProduct(Product newProduct)
        {
            List<Product> productList = new List<Product>();
            productList.Add(new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 });
            productList.Add(new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M });
            productList.Add(new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M });
            if(ModelState.IsValid && newProduct!=null){
                productList.Add(newProduct);
                return Ok(productList);
            }
            else
            {
                return Ok();
            }
            
        }


    }
}
