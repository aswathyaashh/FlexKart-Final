using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.core.ApplicationLayer.BuyerModuleDTO
{
    public class ProductDTOReq
    {
        public string Name { get; set; }
        public string Brand_FK__c { get; set; }
        public string Price__c { get; set; }
        public string productDotNetId__c { get; set; }
        public string Quantity__c { get; set; }
        public string Specifications__c { get; set; }
        public string Sub_Category__c { get; set; }
        public string ImageUrl1__c { get; set; }
        public string ImageUrl2__c { get; set; }
    }
}
