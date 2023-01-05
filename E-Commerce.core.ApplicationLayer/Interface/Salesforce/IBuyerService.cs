using E_Commerce.core.ApplicationLayer.BuyerModuleDTO;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.core.ApplicationLayer.Interface.Salesforce
{
    public interface IBuyerService
    {
        Task<AuthenticationRes> Authentication();

        //Task<BrandDTORes> AddBrand(BrandDTOReq brandDTOReq);
    }
}
