using ShoppingBL.Exceptions;
using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingBL
{
    public class CartBL : ICartServices
    {
        readonly AbstractRepository<int, Cart> _abstractRepository;

        public CartBL(AbstractRepository<int, Cart> abstractRepository)
        {
            _abstractRepository = abstractRepository;
        }
        public bool CheckForCharges(int cartId)
        {
            var result = _abstractRepository.GetByKey(cartId);
            double total = 0;
            if(result != null) {
                if(result.CartItems.Count > 0)
                {
                    result.CartItems.ForEach(item => { total += item.Price; });
                    return total < 100;
                }
                throw new EmptyCartException();
            }
            throw new CartNotFoundException();
        }

        public Cart CheckForDiscount(int cartId)
        {
            var result = _abstractRepository.GetByKey(cartId);
            double total = 0;
            if (result != null)
            {
                if (result.CartItems.Count > 0)
                {
                    result.CartItems.ForEach(item => { total += item.Price; });
                    if(result.CartItems.Count == 3 && total >= 1500)
                    {
                        result.CartItems.ForEach(item => { item.Discount = 5; });
                        return _abstractRepository.Update(result);
                    }
                    throw new NotValidForDiscount();
                }
                throw new EmptyCartException();
            }
            throw new CartNotFoundException();
        }

        public bool CheckQuantityGreaterthan5(int cartId)
        {
            var result = _abstractRepository.GetByKey(cartId);
            bool isQuantityGreaterThan5 = false;
            if (result != null)
            {
                if (result.CartItems.Count > 0)
                {
                    foreach (var item in result.CartItems)
                    {
                        if (item.Quantity > 5)
                        {
                            isQuantityGreaterThan5 = true;
                            break; // Exit the loop early if any item has a quantity greater than 5
                        }
                    }

                    return isQuantityGreaterThan5;

                }
                throw new EmptyCartException();
            }
            throw new CartNotFoundException();
        }
    }
}
