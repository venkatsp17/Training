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
        //Function to Calculate Total
        double CalculateTotal(List<CartItem> items)
        {
            double total = 0;
            items.ForEach(item => { total += item.Price; });
            return total;
        }
        [ExcludeFromCodeCoverage]
        //Function to Create Cart
        public async Task<int> CreateCart(Cart cart)
        {
            var result = _abstractRepository.Add(cart);
            if(result !=null)
            {
                return result.Id;
            }
            throw new DuplicateDataFoundException();
        }
        //Function to Add CartItem to Cart
        public async Task<Cart> AddItemToCart(CartItem item, int CartId)
        {
            var result = _abstractRepository.GetByKey(CartId);
            if (result==null)
            {
                Cart cart = new Cart();
                List<CartItem> items = new List<CartItem>
                {
                    item
                };
                cart.CartItems = items;
                int id = await CreateCart(cart);
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
                            result.Total = CalculateTotal(result.CartItems) + await CheckForCharges(result.CartItems);
                            Cart updatedCart = await CheckForDiscount(result);
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
        //Function to Check For Charges Applicable
        public async Task<double> CheckForCharges(List<CartItem> cartItems)
        {
            double total = 0;
            if(cartItems.Count > 0)
               {
                  total = CalculateTotal(cartItems);
                  return total < 100 ? 100 : 0;

               }
               throw new EmptyCartException();
        }
        //Function to Check for Discount Applicable 
        public async Task<Cart> CheckForDiscount(Cart cart)
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
        //Function to Remove Item from Cart
        public async Task<Cart> RemoveItemFromCart(int ProductId, int CartId)
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
                        result.Total = CalculateTotal(result.CartItems) + await CheckForCharges(result.CartItems);
                        await CheckForDiscount(result);
                        return _abstractRepository.Update(result);
                    }
                    throw new CartItemNotFoundException();
                }
                throw new EmptyCartException();
            }
            throw new CartNotFoundException();
        }
        //Function to Update Cart Item Quantity
        public async Task<Cart> UpdateCartItemQuantity(int ProductId, int CartId, int Quantity)
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
                            result.Total = CalculateTotal(result.CartItems) + await CheckForCharges(result.CartItems);
                            await CheckForDiscount(result);
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
