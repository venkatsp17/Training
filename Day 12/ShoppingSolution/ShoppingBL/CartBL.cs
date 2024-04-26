using ShoppingBL.Exceptions;
using ShoppingBL.Exceptions.CartExceptions;
using ShoppingBL.Exceptions.CartItemExceptions;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Diagnostics.CodeAnalysis;

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
        [ExcludeFromCodeCoverage]
        public int CreateCart(Cart cart)
        {
            var result = _abstractRepository.Add(cart);
            if(result !=null)
            {
                return result.Id;
            }
            throw new DuplicateDataFoundException();
        }

        public Cart AddItemToCart(CartItem item, int CartId)
        {
            var result = _abstractRepository.GetByKey(CartId);
            if (result==null)
            {
                Cart cart = new Cart();
                List<CartItem> items = new List<CartItem>();
                items.Add(item);
                cart.CartItems = items;
                int id = CreateCart(cart);
                return _abstractRepository.GetByKey(id);
            }
            if (result != null)
            {
                foreach (var item1 in result.CartItems)
                {
                    if(item1.ProductId == item.ProductId)
                    {
                        if(item1.Quantity + item.Quantity <= 5)
                        {
                            item1.Quantity += item.Quantity;
                            item1.Price = item1.Quantity * item.Product.Price;
                            result.Total = CalculateTotal(result.CartItems) + CheckForCharges(result.CartItems);
                            Cart updatedCart = CheckForDiscount(result);
                            return updatedCart;
                        }
                        throw new CartItemQuantityExceededException();
                    }
                }
               result.CartItems.Add(item);
              return  _abstractRepository.Update(result);
            }
            throw new CartNotFoundException();
        }

        public double CheckForCharges(List<CartItem> cartItems)
        {
            double total = 0;
            if(cartItems.Count > 0)
               {
                  total = CalculateTotal(cartItems);
                  return total<100?100:0;

               }
               throw new EmptyCartException();
        }

        public Cart CheckForDiscount(Cart cart)
        {
            
            double total = 0;
            if (cart != null)
            {
               
                if (cart.CartItems.Count > 0)
                {
                    total = CalculateTotal(cart.CartItems);
                    if (cart.CartItems.Count == 3 && total >= 1500)
                    {

                        cart.CartItems.ForEach(item => { item.Discount = 5; });
                        cart.Total += (cart.Total) * 0.5;
                        //return _abstractRepository.Update(cart);
                    }
                    return _abstractRepository.Update(cart);
                    //throw new NotValidForDiscount();
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
                        result.Total = CalculateTotal(result.CartItems) + CheckForCharges(result.CartItems);
                        CheckForDiscount(result);
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
                            item1.Price = Quantity*item1.Product.Price;
                            result.Total = CalculateTotal(result.CartItems) + CheckForCharges(result.CartItems);
                            CheckForDiscount(result);
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
