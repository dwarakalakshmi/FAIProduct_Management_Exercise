using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DataContext;

namespace Repositories
{
    public class ProductRepository
    {
        // declare field of type DataContext

        public DataContext dataContext;

        public ProductRepository()
        {
            //initialize the DataContext field with parameter passed

            dataContext = new DataContext(fileName,path);    
        }

        /*
         * this method should accept product data and add it to the product collection
         * 
         */
        public void AddProduct(int ProductId,string ProductName,float ProductPrice,bool InStock)
        {
            // code to add product to file, ensuring that product is not null

            dataContext.AddProduct(this.ProductId,this.ProductName,this.ProductPrice,this.Instock);
            


        }


        /*
         * this method should search for the product by the provided product id 
         * and if found should remove it from the collection
         * 
         * the method should return true for success and false for invalid id 
         */
        public bool RemoveProduct(int ProductId)
        {
            // code to remove product by the id provided from file as parameter
            Product product = GetProductById(id);
            if(product.Contains(ProductId))
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
        public string GetProductByName(string ProductName)
        {
            List<Product> products = GetAllProducts();
            Product product = new Product(); 
            if (products.Count > 0)
            {
                foreach(Product p in product)
                {
                    if(p.ProductName == ProductName)
                    {
                        product.ProductId = p.ProductId;
                        product.ProductName = p.ProductName;
                        product.ProductPrice = p.ProductPrice;
                        product.InStock = p.InStock;
                    }
                }
                return product;

            }

        }

        public int GetProductById(int id)
        {
            List<Product> products = GetAllProducts();
            Product product = new Product();
            if(products.Count > 0)
            {
                foreach(Product p in products)
                {
                    if(p.ProductId == id)
                    {
                        product.ProductId = p.ProductId;
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
            DataContext context = new DataContext(dataContext.fileName,dataContext.Path);
            return dataContext.ReadProducts();
        }
    }
}
