using Entities;
using NUnit.Framework;
using Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;



namespace test
{
    [TestFixture]
    public class ProductRepositoryTest
    {
        readonly DataContext context;
        readonly ProductRepository repository;
        public  ProductRepositoryTest()
        {
            string folder = "test";
            int rootPosition = Environment.CurrentDirectory.IndexOf("bin");
            string rootFolder = Environment.CurrentDirectory.Substring(0, rootPosition - folder.Length - 1);
            context = new DataContext("products.dat", rootFolder);



           repository = new ProductRepository(folder,rootFolder);
        }



       [Test, Order(0)]
        public void Should_AddProduct_Return_1001()
        {
            var product = new Product
            {
                ProductID = 1001,
                ProductName = "Titan white square dial watch for men",
                ProductPrice = 2500,
                InStock = true
            };
            repository.AddProduct(product);



           Assert.That(repository.GetAllProducts(), Has.Count.EqualTo(1), message: "Count of total products must be 1");



       }



       [Test, Order(1)]
        public void Should_AddProduct_Return_1002()
        {
            var product = new Product{
                    ProductID = 1001,
                    ProductName = "Titan black dial watch for women",
                    ProductPrice = 2200,
                    InStock = true
                };



           repository.AddProduct(product);



           Assert.That(repository.GetAllProducts(), Has.Count.EqualTo(2), message: "Count of total products must be 2");
            
        }



       [Test, Order(2)]
        public void Should_GetProduct_ById_Return_Product()
        {
            var result = repository.GetProductById(1001);



           Assert.That(result, Is.Not.Null,message:"Product Cannot be Null");
            Assert.That(result.ProductName, Is.EqualTo("Titan white square dial watch for men"), message: "Product Name must be \'Titan white square dial watch for men\'");



       }
        [Test, Order(3)]
        public void Should_GetProduct_ByName_Return_Product()
        {
            var result = repository.GetProductByName("Titan black dial watch for women");



           Assert.That(result, Is.Not.Null, message: "Product Cannot be Null");
            Assert.That(result.ProductPrice, Is.EqualTo(2200), message: "Price must be 2200");
        }



       [Test, Order(4)]
        public void Should_GetProducts_Return_List()
        {
            var result = repository.GetAllProducts();



           Assert.That(result, Is.TypeOf<List<Product>>(), message: "List<Product> should be returned");
            Assert.That(result.Count, Is.EqualTo(2), message: "Count of products must be 2");
        }



       [Test, Order(5)]
        public void Should_RemoveProduct_Return_True()
        {
            var result = repository.RemoveProduct(1001);



           Assert.That(result, Is.True, message: "RemoveProduct() should return true for valid product id");
            Assert.That(repository.GetAllProducts(), Has.Count.EqualTo(1), message: "Count of products should be 1");
            
        }



       [Test, Order(6)]
        public void Should_GetProduct_ById_Return_Null()
        {
            var result = repository.GetProductById(1000);



           Assert.That(result, Is.Null, message: "Null value should be returned for invalid product id");
        }



       [Test, Order(7)]
        public void Should_GetProduct_ByName_Return_Null()
        {
            var result = repository.GetProductByName("Titan black dial watch for men");



           Assert.That(result, Is.Null, message: "Null value should be returned for invalid product name");
        }



       [Test, Order(8)]
        public void Should_RemoveProduct_Return_False()
        {
            var result = repository.RemoveProduct(1000);



           Assert.That(result, Is.False, message: "RemoveProduct() should return false for invalid product id");
        }



       [Test, Order(9)]
        public void Should_AddProduct_NotAdd_Null()
        {
            repository.AddProduct(null);
            var productList = repository.GetAllProducts();
            Assert.That(productList, Has.Count.EqualTo(1), message: "Cannot add null to product list");
        }



       [OneTimeTearDown]
        public void DisposeFile()
        {
            context.CleanUp();
        }



   }
}