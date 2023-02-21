using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.lib.mapper.DTO;
namespace core.lib.services
{
    public interface IAuthService
    {
        public Task<String> Login(LoginRequestDTO _loginRequest);
    }
}