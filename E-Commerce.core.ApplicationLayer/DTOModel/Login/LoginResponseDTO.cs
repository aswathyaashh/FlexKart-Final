using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;

namespace E_Commerce.core.ApplicationLayer.DTOModel.Login
{
    public class LoginResponseDTO : ApiResponse<LoginDTO>
    {
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }

    }
}
