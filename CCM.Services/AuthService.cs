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
using Microsoft.EntityFrameworkCore;
using CCM.Infrastructure;


namespace CCM.Services
{

    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private const string SecretKey = "YourSuperSecretKey";
        private const string DefaultPersonalRoleUuid = "00000000-0000-0000-0000-000000000001";

        public AuthService(AppDbContext context, IUserRepository userRepository, IUserRoleRepository userRoleRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        public string Register(Models.RegisterRequest request)
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
                Email = request.Email,
                Phone = request.Phone,
                CreateTime = DateTime.UtcNow,
                ModifyTime = DateTime.UtcNow
            };

            AddUserToDatabase(user);

            var roleUuid = request.RoleUuid ?? Guid.Parse(DefaultPersonalRoleUuid);

            var userRole = new SysUserRole
            {
                Uuid = Guid.NewGuid(),
                UserUuid = user.Uuid,
                RoleUuid = roleUuid
            };

            _userRoleRepository.AddUserRole(userRole);

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

        private void AddUserToDatabase(SysUser user)
        {
            _context.SysUsers.Add(user);
            _context.SaveChanges();
        }
    }

}
