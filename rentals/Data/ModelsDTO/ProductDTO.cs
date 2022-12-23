using System.ComponentModel.DataAnnotations;

namespace rentals.Data.ModelsDTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please enter name...")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter description...")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter price...")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please enter location...")]
        public string Location { get; set; }
        public string? PostalCode { get; set; }
        public string? Url { get; set; }
    }
}
