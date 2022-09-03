using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Text;

namespace Repositories
{
    // this class provides functionalities to read and write product collection data with file

   public class DataContext
    {
        // declare field for filename with path
        // declare field for list of products

       //public string filename = @"C:\Users\SDLakshmi\source\repos\pg1\Product.xml";
        public string path = @"C:\Users\SDLakshmi\source\repos\pg1\Product.xml";

        List<Product> product = new List<Product>();
        // the constructor should accept filename and path strings
        public DataContext(string fileName, string path)
        {
            // the constructor code should open file if it exists else create new
           // the code should read data from file if it contains any data
           // the data read should populate the list of products field
           // if no data is present an empty list should be created

           if (!File.Exists(path))
            {
                File.Create(fileName);
            }
           
        }
       // this method should return the list of products read from file
        public List<Product> ReadProducts()
        {
            List<Product> products = new List<Product>();
            StreamReader streamReader = new StreamReader(path);
            string doc = streamReader.ReadToEnd();
            string[] str = doc.Split(' ');
            foreach (string s in str)
            {
                string[] str2 = s.Split(' ');
                Product product = new Product();
                product.ProductID = Convert.ToInt32(str2[0]);
                product.ProductName = str2[1];
                product.ProductPrice = Convert.ToDouble(str2[2]);
                product.InStock = true;
           }
            return products;
       }
       // this method should add the product data passed as parameter to the list of products
        public bool AddProduct(Product products)
        {
            StreamWriter streamWriter = new StreamWriter(path);
            string product = products.ProductID + " " + products.ProductName + " " + products.ProductPrice + " " + products.InStock;
            streamWriter.Write(product);
            return true;
        }
       // this method should write the data from list of products to file and make data persistent
        public void SaveChanges(string fileName, List<Product> product)
        {
            // implement serialization
           XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>));
            Stream stream = new FileStream(fileName, FileMode.Open);
            xmlSerializer.Serialize(stream, product);
           stream.Close();
       }

       // this method should delete the file if exists
        public void CleanUp()
        {
            File.Delete(@"C: \Users\SDLakshmi\source\repos\pg1\Product.xml");
        }
    }
}