﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.core.ApplicationLayer.BuyerModuleDTO
{
    public class SubCategoryDTOReq
    {
        public string Name { get; set; }
        public string SubCategoryDotNetId__c { get; set; }
        public string Parent_Category__c { get; set; }
    }
}
