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
        public int CreateNewProduct(Product product);

        public Product UpdateProductPrice(double newPrice, int ProductId);

        public Product UpdateProductQuantity(int quantity, int ProductId);

        public Product DeleteProduct(int ProductId);
    }
}
