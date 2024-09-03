namespace Entities.Models
{
    public class CreditCard
    {
        public string Id { get; set; } = string.Empty;
        public string IdUser { get; set; } = string.Empty;
        public string Account { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public int Cvc { get; set; }
    }
}
