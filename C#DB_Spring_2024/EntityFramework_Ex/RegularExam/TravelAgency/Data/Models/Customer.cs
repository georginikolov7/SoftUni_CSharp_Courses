using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Data.Models
{
    using static Data.DataConstraints;
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(CustomerNameMaxLength)]
        public string FullName { get; set; } = null!;
        [Required]
        [MaxLength(CustomerEmailMaxLength)]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(CustomerPhoneLength)]
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
    }
}
