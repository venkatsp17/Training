using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBL
{
    public interface ICartServices
    {
        Task<Cart> AddItemToCart(CartItem item, int CartId);

        Task<int> CreateCart(Cart cart);

        Task<Cart> RemoveItemFromCart(int ProductId, int CartId);

        Task<double> CheckForCharges(List<CartItem> cartItems);

        Task<Cart> CheckForDiscount(Cart cart);

        Task<Cart> UpdateCartItemQuantity(int ProductId, int CartId, int Quantity);
    }
}
