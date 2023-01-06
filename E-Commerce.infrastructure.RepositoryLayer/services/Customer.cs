using AutoMapper;
using E_Commerce.core.ApplicationLayer.DTOModel;
using E_Commerce.core.ApplicationLayer.DTOModel.Customer;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
using E_Commerce.core.ApplicationLayer.Interface;
using E_Commerce.core.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.infrastructure.RepositoryLayer.services
{
    public class Customer : ICustomer
    {
        #region(Private Variables)
        private readonly AdminDbContext _adminDbContext;
        private readonly IMapper _mapper;
        #endregion

        #region(Constructor)
        public Customer(AdminDbContext adminDbContext, IMapper mapper)
        {
            _adminDbContext = adminDbContext;
            _mapper = mapper;
        }

        public ApiResponse<bool> Delete(int customerId)
        {

            //CustomerModel1 customer = _adminDbContext.Customer.FirstOrDefault(i => i.CustomerId == customerId);
            //ApiResponse<bool> response = new ApiResponse<bool>();

            //if (customer != null)
            //{
            //    if (customer.Status == 0)
            //    {
            //        customer.Status = 1;
            //        // subCategory.UpdatedDate = DateTime.Now;
            //        _adminDbContext.Customer.Update(customer);
            //        _adminDbContext.SaveChanges();
            //        response.Success = true;
            //        response.Message = "Deleted";
            //        return response;

            //    }

            //    else
            //    {
            //        response.Success = false;
            //        response.Message = "Already Deleted category";
            //        response.Data = false;
            //        return response;
            //    }
            //}
            //    response.Success = false;
            //    response.Message = "Customer doesn't exist.";
            //    return response; 
            return null;
        }
        #endregion
        public ApiResponse<List<CustomerDTO>> Get()
        {
            //ApiResponse<List<CustomerDTO>> response = new ApiResponse<List<CustomerDTO>>();
            //var data = _mapper.Map<List<CustomerModel1>, List<CustomerDTO>>(_adminDbContext.Customer.Where(e => e.Status == 0).ToList());

            //if (data != null && data.Count > 0)
            //{
            //    response.Message = "Customer's Listed";
            //    response.Success = true;
            //    response.Data = data;
            //    return response;
            //}
            //else
            //{
            //    response.Message = "No Customer's Found";
            //    response.Success = false;
            //    return response;
            //}
            return null;
        }

        public ApiResponse<bool> Post(CustomerDTO customer)
        {
            //var customerModel = new CustomerModel1()
            //{
            //    CustomerName = customer.CustomerName
            //};

            //// categoryModel.UpdatedDate = null;
            //_adminDbContext.Customer.Add(customerModel);
            //_adminDbContext.SaveChanges();

            //var add = _adminDbContext.Customer.FirstOrDefault(e => e.CustomerName == customerModel.CustomerName);
            //ApiResponse<bool> addResponse = new ApiResponse<bool>();

            //if (add == null)
            //{
            //    addResponse.Success = false;
            //    addResponse.Message = "Customer is not added";
            //    addResponse.Data = false;
            //    return addResponse;
            //}
            //else
            //{
            //    addResponse.Success = true;
            //    addResponse.Message = "Customer is added";
            //    addResponse.Data = true;
            //    return addResponse;

            //}
            return null;
        }

        public ApiResponse<bool> Update(int id, CustomerDTO customer)
        {
            //var update = _adminDbContext.Customer.FirstOrDefault(e => e.CustomerId == id);
            //ApiResponse<bool> updateResponse = new ApiResponse<bool>();

            //if (update == null)
            //{
            //    updateResponse.Success = false;
            //    updateResponse.Message = "Customer doesnt exist";
            //    updateResponse.Data = false;
            //    return updateResponse;
            //}
            //else
            //{
            //    updateResponse.Success = true;
            //    updateResponse.Message = "Customer is updated";
            //    updateResponse.Data = true;
            //    update.CustomerName = customer.CustomerName;
            //    // update.UpdatedDate = DateTime.Now;
            //    _adminDbContext.Update(update);
            //    _adminDbContext.SaveChanges();
            //    return updateResponse;
            //}
            return null;
        }
    }
}
