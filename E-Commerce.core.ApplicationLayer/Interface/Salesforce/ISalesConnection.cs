using E_Commerce.core.ApplicationLayer.BuyerModuleDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.core.ApplicationLayer.Interface.Salesforce
{
    public interface ISalesConnection
    {
        string Authentication();
    }
}
