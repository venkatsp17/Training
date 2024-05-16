namespace PizzaShopAPI.Models.DTO
{
    public class CustomerUserDTO : Customer
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
