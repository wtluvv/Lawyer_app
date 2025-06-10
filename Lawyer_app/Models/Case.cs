using Postgrest.Attributes;
using Postgrest.Models;

namespace Lawyer_app.Models
{
    [Table("cases")]
    public class Case : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("case_number")]
        public string CaseNumber { get; set; }

        [Column("client_id")]
        public int ClientId { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("court_date")]
        public DateTime CourtDate { get; set; }
    }
}