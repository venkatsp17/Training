namespace PizzaShopAPI.Models.DTO
{
    public class UserLoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
