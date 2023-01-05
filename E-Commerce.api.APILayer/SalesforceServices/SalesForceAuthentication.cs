//using E_Commerce.core.ApplicationLayer.BuyerModuleDTO;
//using E_Commerce.core.ApplicationLayer.Interface.Salesforce;
//using Newtonsoft.Json;

//namespace E_Commerce.api.APILayer.SalesforceServices
//{
//    public class SalesForceAuthentication:ISalesConnection
//    {
//        private readonly IConfiguration _configuration;
//        public SalesForceAuthentication(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public async Task<AuthenticationRes> Authentication(AuthenticationReq authenticationReq)
//        {
//           var value= _configuration.GetSection("BuyerConfig").Get<Dictionary<string,string>>();
//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:6740");
//                var content = new FormUrlEncodedContent(new[]
//                {
//                new KeyValuePair<string, string>("", "login")
//            });
//                var result = await client.PostAsync("/api/Membership/exists", content);
//                string resultContent = await result.Content.ReadAsStringAsync();
//                Console.WriteLine(resultContent);
//            }
//        }
//    }
//}
