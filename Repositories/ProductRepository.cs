using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class ProductRepository
    {
        // declare field of type DataContext

       public DataContext dataContext = null;
       public ProductRepository(string fileName, string path)
        {
            //initialize the DataContext field with parameter passed

           dataContext = new DataContext(fileName, path);
        }
       /*
          * this method should accept product data and add it to the product collection
          *
          */
        public bool AddProduct(Product product)
        {
            // code to add product to file, ensuring that product is not null
            if (product.ProductID != 0)
                return dataContext.AddProduct(product);
            return false;
        }

        /*
         * this method should search for the product by the provided product id
         * and if found should remove it from the collection
         *
         * the method should return true for success and false for invalid id
         */
        public bool RemoveProduct(int id)
        {
            // code to remove product by the id provided from file as parameter
            Product product = GetProductById(id);
            if (product != null)
            {
                dataContext.CleanUp();
                return true;
            }
            return false;
       }

       /*
          * this method should search and return product by product name from the file
          *
          * the search value should be passed as parameter
          *
          * the method should return null for non-matching product name
          */
        public Product GetProductByName(string productName)
        {
            List<Product> products = GetAllProducts();
            Product product = new Product();
            if (products.Count > 0)
            {
                foreach (Product p in products)
                {
                    if (p.ProductName == productName)
                    {
                        product.ProductID = p.ProductID;
                        product.ProductName = p.ProductName;
                        product.ProductPrice = p.ProductPrice;
                        product.InStock = p.InStock;
                    }
                }

            }
            return product;
       }

       public Product GetProductById(int id)
        {
            List<Product> products = GetAllProducts();
            Product product = new Product();
            if (products.Count > 0)
            {
                foreach (Product p in products)
                {
                    if (p.ProductID == id)
                    {
                        product.ProductID = p.ProductID;
                        product.ProductName = p.ProductName;
                        product.ProductPrice = p.ProductPrice;
                        product.InStock = p.InStock;
                    }
                }
            }
            return product;
        }


       /*
          * this method should search and return product by product id from the collection
          *
          * the search value should be passed as parameter
          *
          * the method should return null for non-matching product id
          */

       /*
          * this method should return all items from the product collection
          */
        public List<Product> GetAllProducts()
        {
            DataContext context = new DataContext("fileName", "path");
            return dataContext.ReadProducts();
        }
    }
}