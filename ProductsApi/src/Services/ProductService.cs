using System.Collections.Generic;
using System.Linq;
using ProductsApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ProductsApi.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("ProductstoreDb"));
            var database = client.GetDatabase("ProductstoreDb");
            _products = database.GetCollection<Product>("Products");
        }

        public List<Product> Get()
        {
            return _products.Find(product => true).ToList();
        }

        public Product Get(string id)
        {
            return _products.Find<Product>(product => product.Id == id).FirstOrDefault();
        }

        public Product Create(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void Update(string id, Product productIn)
        {
            _products.ReplaceOne(product => product.Id == id, productIn);
        }

        public void Remove(Product productIn)
        {
            _products.DeleteOne(product => product.Id == productIn.Id);
        }

        public void Remove(string name)
        {
            _products.DeleteMany(product => product.Name == name);
        }
    }
}