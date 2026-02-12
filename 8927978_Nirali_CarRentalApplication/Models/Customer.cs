using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _8927978_Nirali_CarRentalApplication.Models
{
    public class Customer
    {
        [Key]
        [Column("customer_id")]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(100)]

        [Column("first_name")]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("last_name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Column("email")]
        public string Email { get; set; }

        
    }
}
