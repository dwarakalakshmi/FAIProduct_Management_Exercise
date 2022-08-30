using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Repositories
{
    // this class provides functionalities to read and write product collection data with file

    public class DataContext
    { 
        // declare field for filename with path
        // declare field for list of products
        
        public string filename = "C:\Users\SDLakshmi\source\repos\pg1\Product.xml";
        public string path = "C:\Users\SDLakshmi\source\repos\pg1\Product.xml";


        List<Product> product = new List<Product>();


        // the constructor should accept filename and path strings
        public DataContext(string fileName,string path)
        {
            // the constructor code should open file if it exists else create new

            // the code should read data from file if it contains any data

            // the data read should populate the list of products field

            // if no data is present an empty list should be created 

            if(File.Exists(path))
            {
                File.Open(fileName);
                Console.WriteLine("File Opened");
            }
            else
            {
                File.Create(fileName);
                Console.WriteLine("New File Created");
            }
        }

        // this method should return the list of products read from file
        public List<Product> ReadProducts()
        {
            // return data of the product list
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>));
            Stream stream = new FileStream(fileName,FileMode.OpenOrCreate);
            xml.Serialize(stream,product);
            product = (List<Product>)xml.Deserialize(stream);

            stream Close();
            return product;

        }

        // this method should add the product data passed as parameter to the list of products
        public void AddProduct(int ProductId,string ProductName,float ProductPrice,bool InStock)
        {
            product.Add(Product.productId,Product.productName,Product.productPrice,Product.InStock);
            SaveChanges(fileName,product);
        }

        // this method should write the data from list of products to file and make data persistent
        public  void SaveChanges(string fileName,List<Product> product)
        {
            // implement serialization

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Product>));
            Stream stream = new FileStream(fileName,FileMode.Open);
            xml.Serialize(stream,product);

            stream.Close();

        }

        // this method should delete the file if exists
        public void CleanUp()
        {
            if (File.Exits(fileName))
            {
                FileDelete(fileName);
                Console.WriteLine("File deleted successfully");
            }
            else
            {
                Console.WriteLine("File doesn't exist");
            }
        }
    }
}
