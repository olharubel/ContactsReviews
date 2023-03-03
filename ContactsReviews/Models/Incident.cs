using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContactsReviews.Models
{
    public class Incident
    {
        [Key]
        public int Name { get; set; }
        public Guid IncidentId { get; set; }
        public string Description { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Account>? Accounts { get; set; }

    }
}
