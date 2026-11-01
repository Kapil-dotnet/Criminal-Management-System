using System.ComponentModel.DataAnnotations;

namespace CriminalManagementSystem.Models
{
    public class Criminal
    {
        [Key]
        public int CriminalId { get; set; }

        [Required(ErrorMessage = "Criminal Code is required")]
        [StringLength(20)]
        public string CriminalCode { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [StringLength(20)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(15)]
        [Phone(ErrorMessage = "Enter a valid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(250)]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(50)]
        public string State { get; set; }

        [Required(ErrorMessage = "Identification Mark is required")]
        [StringLength(150)]
        public string IdentificationMark { get; set; }

        [StringLength(250)]
        public string? Photo { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [StringLength(20)]
        public string Status { get; set; }

        [Required(ErrorMessage = "Arrest Date is required")]
        [DataType(DataType.Date)]
        public DateTime ArrestDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}