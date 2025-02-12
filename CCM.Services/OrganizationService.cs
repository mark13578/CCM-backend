using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCM.Models;
using CCM.Repository;

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

    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public IEnumerable<SysOrganization> GetAllOrganizations()
        {
            return _organizationRepository.GetAllOrganizations();
        }

        public SysOrganization GetOrganizationById(Guid uuid)
        {
            return _organizationRepository.GetOrganizationById(uuid);
        }

        public void CreateOrganization(SysOrganization organization)
        {
            organization.Uuid = Guid.NewGuid();
            _organizationRepository.AddOrganization(organization);
        }

        public void UpdateOrganization(Guid uuid, SysOrganization organization)
        {
            var existingOrganization = _organizationRepository.GetOrganizationById(uuid);
            if (existingOrganization == null)
                throw new Exception("Organization not found.");

            existingOrganization.OrgName = organization.OrgName;
            existingOrganization.Tel = organization.Tel;
            existingOrganization.Ext = organization.Ext;
            existingOrganization.GuiNumber = organization.GuiNumber;
            existingOrganization.AdminUuid = organization.AdminUuid;
            existingOrganization.TechUuid = organization.TechUuid;
            existingOrganization.AccUuid = organization.AccUuid;
            existingOrganization.DocFile = organization.DocFile;
            existingOrganization.Permission = organization.Permission;

            _organizationRepository.UpdateOrganization(existingOrganization);
        }

        public void DeleteOrganization(Guid uuid)
        {
            _organizationRepository.DeleteOrganization(uuid);
        }
    }
}
