namespace Entities.Models
{
    public class User
    {
        public string Id { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string WorkPlace { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<CreditCard> Cards { get; set; } = new List<CreditCard>();
        public string Fio => $"{LastName} {FirstName} {MiddleName}";

    }
}
