using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Infrastructure;
using CCM.Models;

namespace CCM.Repository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly AppDbContext _context;

        public OrganizationRepository(AppDbContext context)
        {
            _context = context;
        }

        public SysOrganization GetOrganizationById(Guid uuid)
        {
            return _context.SysOrganization.FirstOrDefault(o => o.Uuid == uuid);
        }

        public IEnumerable<SysOrganization> GetAllOrganizations()
        {
            return _context.SysOrganization.ToList();
        }

        public void AddOrganization(SysOrganization organization)
        {
            _context.SysOrganization.Add(organization);
            _context.SaveChanges();
        }

        public void UpdateOrganization(SysOrganization organization)
        {
            _context.SysOrganization.Update(organization);
            _context.SaveChanges();
        }

        public void DeleteOrganization(Guid uuid)
        {
            var organization = GetOrganizationById(uuid);
            if (organization != null)
            {
                _context.SysOrganization.Remove(organization);
                _context.SaveChanges();
            }
        }
    }
}
