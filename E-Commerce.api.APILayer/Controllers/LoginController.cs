using E_Commerce.core.ApplicationLayer.DTOModel.Login;
using E_Commerce.core.ApplicationLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;


namespace E_Commerce.api.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json", MediaTypeNames.Application.Xml)]
    [Produces("application/json", MediaTypeNames.Application.Xml)]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _login;
        public LoginController(ILogin login)
        {
            _login = login;
        }

        [HttpPost("AdminLogin")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(LoginResponseDTO), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get 2 values", Description = "Get Email and Password")]
#region
        public IActionResult LoginCheck([FromBody]LoginDTO loginDto)
        {
            
            //LoginDto login = new LoginDto();
            //loginDto.EmailId;
            //login.Password = password;
            LoginResponseDTO response = _login.LoginCheck(loginDto);
            return Ok(response);
           
        }
#endregion 

    }
}
