using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContactsReviews.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Account
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Contact>? Contacts { get; set; }
        [JsonIgnore]
        public Incident? Incident { get; set; }
      
        public Guid? IncidentIdentifier { get; set; }
 

    }
}
