using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace AplicatieProiect.Models
{
    [Authorize(Roles = "Admin")]
    public class Client

    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage ="Adaugati doar litere nu si alte caractere, iar numele vostru sa inceapa cu majuscula")]

        public string? NumeComplet { get; set; }
        [RegularExpression(@"^[0-9]{13}$", ErrorMessage = "CNP-ul trebuie sa contina doar cifre si sa aiba lungimea de 13 caractere")]
        public double CNP { get; set; }
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau'0722.123.123' sau '0722 123 123'")]
        public string? Telefon { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Adresa de email trebuie sa contina simbolul '@'.")]
        public string? Email { get; set; }

    }
}
