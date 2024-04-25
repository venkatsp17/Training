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

        Cart RemoveItemFromCart(int ProductId, int CartId);

        double CheckForCharges(int cartId);

        Cart CheckForDiscount(int cartId);

        Cart UpdateCartItemQuantity(int ProductId, int CartId, int Quantity);
    }
}
