using System.ComponentModel.DataAnnotations;

namespace AplicatieProiect.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Adaugati doar litere nu si alte caractere, iar numele sa inceapa cu majuscula")]
        public string? Nume { get; set; }
        public string? Capacitate { get; set; }
        public string? Locatie { get; set; }
    }
}
