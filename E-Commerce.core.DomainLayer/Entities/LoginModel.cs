using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_Commerce.core.DomainLayer.Entities
{
    public class LoginModel
    {
        [Key]
        //[Required]
        [EmailAddress(ErrorMessage = "*EmailId should be in the format adc@gmail.com")]
        public string EmailId { get; set; }

        public string Password { get; set; }
        //public int id { get; set; }


        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public int Status { get; set; }
        public LoginModel()
        {
            CreatedDate = DateTime.UtcNow;
            ModifiedDate = DateTime.UtcNow;
        }

    }
}