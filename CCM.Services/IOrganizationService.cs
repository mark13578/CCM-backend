using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;

namespace CCM.Services
{
    public interface IOrganizationService
    {
        IEnumerable<SysOrganization> GetAllOrganizations();
        SysOrganization GetOrganizationById(Guid uuid);
        void CreateOrganization(SysOrganization organization);
        void UpdateOrganization(Guid uuid, SysOrganization organization);
        void DeleteOrganization(Guid uuid);
    }
}
