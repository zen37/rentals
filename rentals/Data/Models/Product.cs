using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace rentals.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Description { get; set; }
        public double Price { get; set; }
        public string Location { get; set; } = string.Empty;
        public string? PostalCode { get; set; }
        public string? Url { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }

    }
}
