using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using E_Commerce.core.ApplicationLayer.Interface;
using E_Commerce.core.ApplicationLayer.DTOModel.Login;

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

        #region
        [HttpPost("AdminLogin")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(LoginResponseDTO), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get 2 values", Description = "Get Email and Password")]
        public IActionResult LoginCheck([FromBody] LoginDTO loginDto)
        {
            LoginResponseDTO response = _login.LoginCheck(loginDto);
            return Ok(response);
        }
        #endregion 
    }
}
