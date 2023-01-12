using E_Commerce.core.ApplicationLayer.DTOModel.Login;

namespace E_Commerce.core.ApplicationLayer.Interface
{
    public interface ILogin
    {
        public LoginResponseDTO LoginCheck(LoginDTO login);
    }
}

