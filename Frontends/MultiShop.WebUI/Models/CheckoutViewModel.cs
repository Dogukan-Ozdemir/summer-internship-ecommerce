using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Models
{
    public class CheckoutViewModel
    {
        // Address
        // Address
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Detail { get; set; }
        public string Detail2 { get; set; }
        public string Description { get; set; }
        public string ZipCode { get; set; }

        // Card (kaydedilmeyecek) sonradan eklenirse kullan şuanlık süs 
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string CVV { get; set; }

        // Basket
        public BasketTotalDto Basket { get; set; }
    }
}
