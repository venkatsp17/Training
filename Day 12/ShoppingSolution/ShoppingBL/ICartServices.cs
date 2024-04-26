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
        Cart AddItemToCart(CartItem item, int CartId);

        int CreateCart(Cart cart);

        Cart RemoveItemFromCart(int ProductId, int CartId);

        double CheckForCharges(List<CartItem> cartItems);

        Cart CheckForDiscount(Cart cart);

        Cart UpdateCartItemQuantity(int ProductId, int CartId, int Quantity);
    }
}
