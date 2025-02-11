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
        string Register(Models.RegisterRequest request);
        string Login(string username, string password);
    }

    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private const string SecretKey = "YourSuperSecretKey"; // 用於JWT簽名

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Register(Models.RegisterRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Country))
            {
                throw new Exception("Country cannot be null or empty.");
            }

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
            var user = _userRepository.GetUserByUsername(username);
            if (user == null || string.IsNullOrEmpty(user.Password) || user.Password != GetMd5Hash(password))
                throw new Exception("Invalid credentials.");


            // Ensure all nullable string properties are handled properly
            user.RealName = user.RealName ?? string.Empty;
            user.IdNumber = user.IdNumber ?? string.Empty;
            user.Phone = user.Phone ?? string.Empty;
            user.Country = user.Country ?? string.Empty;
            user.State = user.State ?? string.Empty;
            user.District = user.District ?? string.Empty;
            user.Address = user.Address ?? string.Empty;
            user.ZipCode = user.ZipCode ?? string.Empty;
            user.Email = user.Email ?? string.Empty;
            user.docfile1 = user.docfile1 ?? string.Empty;
            user.docfile2 = user.docfile2 ?? string.Empty;
            user.docfile2type = user.docfile2type ?? string.Empty;

            return GenerateJwtToken(user);

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
