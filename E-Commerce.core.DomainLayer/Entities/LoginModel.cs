using System.ComponentModel.DataAnnotations;

namespace E_Commerce.core.DomainLayer.Entities
{
    public class LoginModel
    {
        [Key]
        [EmailAddress(ErrorMessage = "*EmailId should be in the format adc@gmail.com")]
        public string EmailId { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string Password { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedDate { get; set; } = DateTime.UtcNow;
        public int Status { get; set; }
        
    }
}