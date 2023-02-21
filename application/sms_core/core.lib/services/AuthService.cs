using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.lib.DAL;
using core.lib.mapper.DTO;
namespace core.lib.services
{
    public class AuthService: IAuthService
    {
        private readonly SmsDbContext _context;
        public AuthService(SmsDbContext context)
        {
            _context = context;
        }
        public Task<string> Login(LoginRequestDTO _loginRequest)
        {
            throw new NotImplementedException();
        }
    }
}