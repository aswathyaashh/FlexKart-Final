using E_Commerce.core.ApplicationLayer.BuyerModuleDTO;
using E_Commerce.core.ApplicationLayer.DTOModel.Brand;
using E_Commerce.core.DomainLayer.Entities;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.infrastructure.RepositoryLayer.services.Salesforce
{
    public class BrandSalesforce
    {
        public bool Query(BrandDTOReq brand, string token)
        {
            var json = JsonConvert.SerializeObject(brand);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var url = "https://team5-step-dev-ed.develop.my.salesforce.com/services/data/v56.0/sobjects/Brand_FK__c";
            var response = string.Empty;
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/json";
            httpRequest.Headers["Authorization"] = "Bearer " + token.ToString();
            httpRequest.ContentType = "application/json";

            var data = json;

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();

            }
            //var issuccess = Update(new BrandModel {BrandId = int.Parse(brand.BrandDotNetId__c), SalesForceId = response.Trim('"') });
            //_contextAccessor.HttpContext.Session.SetString("recid", response.Trim('"'));
            //if ()
            //{

            //    return true;
            //}
            return false;
        }
    }
}
