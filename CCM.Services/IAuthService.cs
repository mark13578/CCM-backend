using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Services
{
    public interface IAuthService
    {
        string Register(CCM.Models.RegisterRequest request); // 確保與 AuthService 一致
        string Login(string username, string password);
        SysUser GetProfile(Guid uuid);
        void UpdateProfile(Guid uuid, UpdateProfileRequest request);
        void DeleteUser(Guid uuid);
    }
}
