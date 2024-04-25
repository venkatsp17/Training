using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBL
{
    public class ProductBL : IProductServices
    {
        AbstractRepository<int, Product> _productRepository;
        public ProductBL(AbstractRepository<int, Product> productRepository) { 
            _productRepository = productRepository;
        }
        public int CreateNewProduct(Product product)
        {
            var result = _productRepository.Add(product);
            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDataFoundException();
        }

        public Product DeleteProduct(int productId)
        {
            var result = _productRepository.GetByKey(productId);
            if (result != null)
            {
                return _productRepository.Delete(productId);
            }
            throw new NoProductWithGivenIdException();
        }

        public Product UpdateProductPrice(double newPrice, int productId)
        {
            var result = _productRepository.GetByKey(productId);
            if (result != null)
            {
                result.Price = newPrice;
                return _productRepository.Update(result);
            }
            throw new NoProductWithGivenIdException();
        }

        public Product UpdateProductQuantity(int quantity, int productId)
        {
            var result = _productRepository.GetByKey(productId);
            if (result != null)
            {
                result.QuantityInHand = quantity;
                return _productRepository.Update(result);
            }
            throw new NoProductWithGivenIdException();
        }

    }
}
