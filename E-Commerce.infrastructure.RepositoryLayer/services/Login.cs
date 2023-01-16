using AutoMapper;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using E_Commerce.core.DomainLayer.Entities;
using E_Commerce.core.ApplicationLayer.Interface;
using E_Commerce.core.ApplicationLayer.DTOModel.Login;


namespace E_Commerce.infrastructure.RepositoryLayer.services
{
    public class Login : ILogin
    {
        #region(Private Variables)

        private readonly AdminDbContext _admincontext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion

        #region(Constructor)
        public Login(AdminDbContext adminDbContext, IConfiguration iconfiguration, IMapper mapper)
        {
            _admincontext = adminDbContext;
            _configuration = iconfiguration;
            _mapper = mapper;
        }
        #endregion

        #region(Login)

        /// <summary>
        /// Login Fucntion 
        /// Here we use email, and password to login to dashboard page
        /// </summary>
        /// <returns></returns>
        public LoginResponseDTO LoginCheck(LoginDTO login)
        {
            LoginDTO loginModel = _mapper.Map<LoginModel, LoginDTO>(_admincontext.Login.FirstOrDefault(i => i.EmailId == login.EmailId));
            if (loginModel != null)
            {
                {
                    if (loginModel.Password == login.Password)
                    {
                        var loginData = _mapper.Map<LoginModel, LoginDTO>(_admincontext.Login.FirstOrDefault(i => i.EmailId == login.EmailId));
                        var modifyDate = _mapper.Map<LoginDTO, LoginModel>(loginData);
                        modifyDate.ModifiedDate = DateTime.UtcNow;
                        _admincontext.SaveChanges();
                        return new LoginResponseDTO()
                        {
                            Success = true,
                            Message = "Success",
                            ExpiryDate = DateTime.UtcNow.AddMinutes(60),
                            Token = CreateToken(login)
                        };
                    }
                    else
                    {
                        return new LoginResponseDTO()
                        {
                            Success = false,
                            Message = "Password is incorrect"
                        };
                    }
                }
            }
            else
            {
                return new LoginResponseDTO()
                {
                    Success = false,
                    Message = "Email Incorrect"

                };
            }
        }

        #endregion

        #region(Token)
        /// <summary>
        /// Token creation 
        /// Here we use email, role and expiryDate for generating token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string CreateToken(LoginDTO user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.EmailId),
                new Claim(ClaimTypes.Role, "Admin")
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var security = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddYears(1),
                signingCredentials: security);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        #endregion
    }
}

