using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicianAsistan.GoogleAuth
{
    public interface IGoogleAuthService
    {
        public Task<GoogleUserDTO> AuthenticateGoogleUserAsync();
        public Task<GoogleUserDTO> GetCurrentuserAsync();
        public Task LogoutAsync();
    }
}
