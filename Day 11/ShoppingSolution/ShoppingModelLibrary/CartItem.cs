using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoppingModelLibrary
{
    public class CartItem
    {
        public int CartId { get; set; }//Navigation property
        public int ProductId { get; set; }
        public Product Product { get; set; }//Navigation property
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public DateTime PriceExpiryDate { get; set; }

        public override string ToString()
        {
            return
            "\nCartItem Id              : " + ProductId +
            "\nProduct Id               : " + ProductId +
            "\nProductName              : " + Product.Name +
            "\nQuantity                 : " + Quantity +
            "\nPrice                    : $"+ Price +
            "\nPrice Expiry Date        : " + PriceExpiryDate;
        }

        public CartItem()
        {

        }

        public CartItem(int cartId, int productId, Product product, int quantity, double price, double discount, DateTime priceExpiryDate)
        {
            CartId = cartId;
            ProductId = productId;
            Product = product;
            Quantity = quantity;
            Price = price;
            Discount = discount;
            PriceExpiryDate = priceExpiryDate;
        }
    }
}
