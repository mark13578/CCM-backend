using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;
using CCM.Repository;
// Repository / UserRepository.cs
   
    using CCM.Infrastructure;

namespace CCM.Repository
{

    //public interface IUserRepository
    //{
    //    SysUser GetUserByUsername(string username);
    //    void AddUser(SysUser user);
    //}


    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public SysUser GetUserByUsername(string username)
        {
            return _context.SysUsers.FirstOrDefault(u => u.Username == username);
        }

        public SysUser GetUserById(Guid uuid)
        {
            return _context.SysUsers.FirstOrDefault(u => u.Uuid == uuid);
        }

        public void AddUser(SysUser user)
        {
            _context.SysUsers.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(SysUser user)
        {
            _context.SysUsers.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(Guid uuid)
        {
            var user = GetUserById(uuid);
            if (user != null)
            {
                _context.SysUsers.Remove(user);
                _context.SaveChanges();
            }
        }

       
        public void AddUserRole(SysUserRole userRole)
        {
            _context.SysUserRole.Add(userRole);
            _context.SaveChanges();
        }

        public IEnumerable<SysUserRole> GetUserRolesByUserId(Guid userUuid)
        {
            return _context.SysUserRole.Where(ur => ur.UserUuid == userUuid).ToList();
        }
    }


}
