using ShoppingBL.Exceptions;
using ShoppingBL.Exceptions.CartExceptions;
using ShoppingBL.Exceptions.CartItemExceptions;
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

        double CalculateTotal(List<CartItem> items)
        {
            double total = 0;
            items.ForEach(item => { total += item.Price; });
            return total;
        }

        public Cart AddItemToCart(CartItem item, int CartId)
        {
            var result = _abstractRepository.GetByKey(CartId);
            if (result != null)
            {
                foreach (var item1 in result.CartItems)
                {
                    if(item1.ProductId == item.ProductId)
                    {
                        if(item1.Quantity + item.Quantity <= 5)
                        {
                            item1.Quantity += item.Quantity;
                            return _abstractRepository.Update(result);
                        }
                        throw new CartItemQuantityExceededException();
                    }
                }
               result.CartItems.Add(item);
              return  _abstractRepository.Update(result);
            }
            throw new CartNotFoundException();
        }

        public double CheckForCharges(int cartId)
        {
            var result = _abstractRepository.GetByKey(cartId);
            double total = 0;
            if(result != null) {
                if(result.CartItems.Count > 0)
                {
                   total = CalculateTotal(result.CartItems);
                    return total < 100? 100: 0;
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
                    total = CalculateTotal(result.CartItems);
                    if (result.CartItems.Count == 3 && total >= 1500)
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

        public Cart RemoveItemFromCart(int ProductId, int CartId)
        {
            var result = _abstractRepository.GetByKey(CartId);
            if (result != null)
            {
                if(result.CartItems.Count > 0)
                {
                    var cartitem = result.CartItems.ToList().Find((item) => item.ProductId == ProductId);
                    if (cartitem != null)
                    {
                        result.CartItems.Remove(cartitem);
                        return _abstractRepository.Update(result);
                    }
                    throw new CartItemNotFoundException();
                }
                throw new EmptyCartException();
            }
            throw new CartNotFoundException();
        }

        public Cart UpdateCartItemQuantity(int ProductId, int CartId, int Quantity)
        {
            var result = _abstractRepository.GetByKey(CartId);
            if (result != null)
            {
                foreach (var item1 in result.CartItems)
                {
                    if (item1.ProductId == ProductId)
                    {
                        if (Quantity <=5)
                        {
                            item1.Quantity = Quantity;
                            return _abstractRepository.Update(result);
                        }
                        throw new CartItemQuantityExceededException();
                    }
                }
                throw new CartItemNotFoundException();
            }
            throw new CartNotFoundException();
        }
    }
}
