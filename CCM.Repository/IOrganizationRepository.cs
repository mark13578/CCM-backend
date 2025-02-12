using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Repository
{
    public interface IOrganizationRepository
    {
        SysOrganization GetOrganizationById(Guid uuid);
        IEnumerable<SysOrganization> GetAllOrganizations();
        void AddOrganization(SysOrganization organization);
        void UpdateOrganization(SysOrganization organization);
        void DeleteOrganization(Guid uuid);
    }
}
