using ATP2_Term_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATP2_Term_Project.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        
        public List<Product> GetProducts(int id)
        {
            List<Product> products = this.context.Products.Where(x => x.CategoryId == id).ToList();
            for (int i = 0; i < products.Count; i++)
            {
                products[i].HyperLinks.Add(new HyperLink() { HRef = "http://localhost:11917/api/products/" + products[i].Id, HttpMethod = "GET", Relation = "Self" });
                products[i].HyperLinks.Add(new HyperLink() { HRef = "http://localhost:11917/api/products", HttpMethod = "POST", Relation = "Create a new Product resource" });
                products[i].HyperLinks.Add(new HyperLink() { HRef = "http://localhost:11917/api/products/" + products[i].Id, HttpMethod = "PUT", Relation = "Edit a existing Product resource" });
                products[i].HyperLinks.Add(new HyperLink() { HRef = "http://localhost:11917/api/products/" + products[i].Id, HttpMethod = "DELETE", Relation = "Delete a existing Product resource" });
            }
            return products;
        }

        public List<Product> GetProductsWithCategory()
        {
            return this.context.Products.Include("Category").ToList();
        }
    }
}