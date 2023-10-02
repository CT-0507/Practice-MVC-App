using System.Collections.Generic;
using AppMvcNet.Models;

namespace AppMvcNet.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[] {
                new ProductModel() {Id = 1, Name = "Iphone X", Price = 1000},
                new ProductModel() {Id = 2, Name = "Samsung A", Price = 1500},
                new ProductModel() {Id = 3, Name = "Nokia XZ", Price = 2000},
                new ProductModel() {Id = 4, Name = "Sony XZ", Price = 5000},
            });
        }
    }
}