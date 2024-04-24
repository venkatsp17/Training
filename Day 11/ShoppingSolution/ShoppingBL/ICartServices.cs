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
        bool CheckForCharges(int cartId);

        Cart CheckForDiscount(int cartId);

        bool CheckQuantityGreaterthan5(int cartId);
    }
}
