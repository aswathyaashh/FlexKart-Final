

namespace E_Commerce.core.ApplicationLayer.BuyerModuleDTO
{
    public class AuthenticationReq
    {
        public string username { get; set; }
        public string password { get; set; }
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }

    }
}
