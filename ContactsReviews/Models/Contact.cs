using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace ContactsReviews.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [JsonIgnore]
        public Account? Account { get; set; }
        [JsonIgnore]
        public int? AccountId { get; set; }
    }
}
