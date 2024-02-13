using System.ComponentModel.DataAnnotations;

namespace AplicatieProiect.Models
{
    public class Contact
    {
        public int ID { get; set; }
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau'0722.123.123' sau '0722 123 123'")]
        public string? Telefon { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Adresa de email trebuie sa contina simbolul '@'.")]
        public string? Email { get; set; }
        public string? ReteleSociale { get; set; }
    }
}
