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
using Azure;
using E_Commerce.core.DomainLayer.Entities;
using E_Commerce.infrastructure.RepositoryLayer;

namespace ServiceLayer
{
    public class BuyerService : IBuyerService
    {
        private readonly IConfiguration _configuration;
        private readonly AdminDbContext _adminDbContext;
        public BuyerService(IConfiguration configuration, AdminDbContext adminDbContext)
        {
            _configuration = configuration;
            _adminDbContext = adminDbContext;
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
            using var client = new HttpClient();
            using HttpResponseMessage httpResponse = await client.PostAsync(url, new FormUrlEncodedContent(dict));
            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK ||
                httpResponse.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AuthenticationRes>(result);
            }
            return new AuthenticationRes();

        }
        #region(Brand Post)
        public async Task<BrandDTORes> AddBrand(BrandDTOReq brandDTOReq, string accessToken)
        {
            var buyerConfig = _configuration.GetSection("BuyerConfig");
            string url = buyerConfig.GetSection("BrandUrl").Value;
            var payload = JsonConvert.SerializeObject(brandDTOReq);
            using StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");

            //using HttpResponseMessage httpResponse = await client.PostAsync(url, content);
            //httpResponse.Wait();
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            using HttpResponseMessage httpResponse = await client.PostAsync(url, content);

            if (httpResponse.StatusCode == HttpStatusCode.OK ||
                httpResponse.StatusCode == HttpStatusCode.Accepted)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BrandDTORes>(result);
            }
            return new BrandDTORes();




        }
        #endregion

        //public async Task<BrandDTORes> AddBrand(BrandDTOReq brandDTOReq, string result)
        //{
        //    var buyerConfig = _configuration.GetSection("BuyerConfig");
        //    string url = buyerConfig.GetSection("BrandUrl").Value;
        //    var payload = JsonConvert.SerializeObject(brandDTOReq);
        //    using StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
        //    using (var client = new HttpClient())
        //    {
        //        //using HttpResponseMessage httpResponse = await client.PostAsync(url, content);
        //        //httpResponse.Wait();
        //        var httpRequest = (HttpWebRequest)WebRequest.Create(url);

        //        httpRequest.Method = "POST";
        //        httpRequest.Accept = "application/json";
        //        httpRequest.Headers["Authorization"] = "Bearer " + result.ToString();
        //        httpRequest.ContentType = "application/json";
        //        var data = payload;

        //        using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
        //        {
        //            streamWriter.Write(data);
        //        }

        //        var httpResponsedata = (HttpWebResponse)httpRequest.GetResponse();
        //        var response = string.Empty;

        //        using (var streamReader = new StreamReader(httpResponsedata.GetResponseStream()))
        //        {
        //            response = streamReader.ReadToEnd();

        //        }
        //        BrandDTORes dataSales = JsonConvert.DeserializeObject<BrandDTORes>(response);

        //        var issuccess = _adminDbContext.Brand.Update(new BrandModel { BrandId = int.Parse(brandDTOReq.BrandDotNetId__c), SalesForceId = dataSales.id });
        //        return null;
        //        //if ()
        //        //{

        //        //    return true;
        //        //}

        //    }
        //}


    }
}



