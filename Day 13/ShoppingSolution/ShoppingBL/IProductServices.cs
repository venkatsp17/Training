using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBL
{
    public interface IProductServices
    {
        public Task<int> CreateNewProduct(Product product);

        public Task<Product> UpdateProductPrice(double newPrice, int ProductId);

        public Task<Product> UpdateProductQuantity(int quantity, int ProductId);

        public Task<Product> DeleteProduct(int ProductId);
    }
}
