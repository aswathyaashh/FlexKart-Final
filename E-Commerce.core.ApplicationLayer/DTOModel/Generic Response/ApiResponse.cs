
namespace E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response
{
    public class ApiResponse<T> : ApiResponseBase
    {    
        public T Data { get; set; }
    }
}
