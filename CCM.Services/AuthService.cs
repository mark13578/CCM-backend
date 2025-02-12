using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;
using CCM.Repository;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity.Data;


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
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private const string SecretKey = "YourSuperSecretKey"; // 用於JWT簽名
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Register(CCM.Models.RegisterRequest request)
        {
            var existingUser = _userRepository.GetUserByUsername(request.Username);
            if (existingUser != null)
                throw new Exception("Username already exists.");

            var encryptedPassword = GetMd5Hash(request.Password);
            var user = new SysUser
            {
                Uuid = Guid.NewGuid(),
                Username = request.Username,
                Password = encryptedPassword,
                RealName = request.RealName,
                IdNumber = request.IdNumber,
                Phone = request.Phone,
                Country = request.Country,
                State = request.State,
                District = request.District,
                Address = request.Address,
                ZipCode = request.Zipcode,
                Email = request.Email,
                CreateTime = DateTime.UtcNow,
                ModifyTime = DateTime.UtcNow
            };

            _userRepository.AddUser(user);
            return "Registration successful";
        }

        public string Login(string username, string password)
        {
            var encryptedPassword = GetMd5Hash(password);
            var user = _userRepository.GetUserByUsername(username);
            if (user == null || string.IsNullOrEmpty(user.Password) || user.Password != encryptedPassword)
                throw new Exception("Invalid credentials.");

            return GenerateJwtToken(user);
        }

        public SysUser GetProfile(Guid uuid)
        {
            return _userRepository.GetUserById(uuid);
        }

        public void UpdateProfile(Guid uuid, UpdateProfileRequest request)
        {
            var user = _userRepository.GetUserById(uuid);
            if (user == null) throw new Exception("User not found.");

            user.RealName = request.RealName;
            user.Phone = request.Phone;
            user.Address = request.Address;
            user.Email = request.Email;
            user.ModifyTime = DateTime.UtcNow;

            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(Guid uuid)
        {
            _userRepository.DeleteUser(uuid);
        }

        private string GetMd5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        private string GenerateJwtToken(SysUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Uuid.ToString()),
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

       
    }

}
