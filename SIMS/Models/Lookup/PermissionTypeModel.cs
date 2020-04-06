using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Lookup
{
    public class PermissionTypeModel : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public PermissionTypeModel()
        {

        }

        public PermissionTypeModel(BusinessEntity.Lookup.PermissionTypeEntity permissionType)
        {
            this.ID = permissionType.ID;
            this.Name = permissionType.Name;
            this.Description = permissionType.Description;
            this.CreatedBy = permissionType.CreatedBy;
            this.CreatedDate = permissionType.CreatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Lookup.PermissionTypeEntity permissionType = new BusinessEntity.Lookup.PermissionTypeEntity();
            permissionType.ID = this.ID;
            permissionType.Name = this.Name;
            permissionType.Description = this.Description;
            permissionType.CreatedBy = this.CreatedBy;
            permissionType.CreatedDate = this.CreatedDate;

            return permissionType as T;
        }
    }
}
