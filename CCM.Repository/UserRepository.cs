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

    public interface IUserRepository
    {
        SysUser GetUserByUsername(string username);
        void AddUser(SysUser user);
    }


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

            public void AddUser(SysUser user)
            {
                _context.SysUsers.Add(user);
                _context.SaveChanges();
            }
        }
    

}
