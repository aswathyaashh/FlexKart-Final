using Microsoft.Extensions.Configuration;
using E_Commerce.core.ApplicationLayer.BuyerModuleDTO;
using E_Commerce.core.ApplicationLayer.Interface.Salesforce;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using System;
using Newtonsoft.Json.Linq;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer
{
    public class BuyerService : IBuyerService
    {
        private readonly IConfiguration _configuration;
        public BuyerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<AuthenticationRes> Authentication()
        {
            var buyerConfig = _configuration.GetSection("BuyerConfig");
            
            var dict = new Dictionary<string, string>();
            dict.Add("username", buyerConfig.GetSection("username").Value);
            dict.Add("password", buyerConfig.GetSection("password").Value);
            dict.Add("grant_type", buyerConfig.GetSection("grant_type").Value);
            dict.Add("client_id", buyerConfig.GetSection("client_id").Value);
            dict.Add("client_secret", buyerConfig.GetSection("client_secret").Value);

            //var response = await httpClient.PostAsync(endpoint, new FormUrlEncodedContent(dict));
            string url = buyerConfig.GetSection("AuthenticationUrl").Value;
            //var payload = JsonConvert.SerializeObject(authenticationReq);
            //using StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                using HttpResponseMessage httpResponse = await client.PostAsync(url, new FormUrlEncodedContent(dict));
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK ||
                    httpResponse.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<AuthenticationRes>(result);
                }
                return new AuthenticationRes();
            }

        }
        //public async Task<BrandDTORes> AddBrand(BrandDTOReq brandDTOReq, result)
        //{
        //    var buyerConfig = _configuration.GetSection("BuyerConfig");
        //    string url = buyerConfig.GetSection("BrandUrl").Value;
        //    var payload = JsonConvert.SerializeObject(brandDTOReq);
        //    using StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
        //    using (var client = new HttpClient())
        //    {
        //        using HttpResponseMessage httpResponse = await client.PostAsync(url, content);
        //        var httpRequest = (HttpWebRequest)WebRequest.Create(url);
        //        httpRequest.Method = "POST";

        //        httpRequest.Accept = "application/json";
        //        httpRequest.Headers["Authorization"] = "Bearer " + result.ToString();
        //        httpRequest.ContentType = "application/json";
        //        if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK ||
        //            httpResponse.StatusCode == System.Net.HttpStatusCode.Accepted)
        //        {
        //            var result = await httpResponse.Content.ReadAsStringAsync();
        //            return JsonConvert.DeserializeObject<BrandDTORes>(result);
        //        }
        //        return new BrandDTORes();
        //    }
        }


    }



