using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class PermissionTypeEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public PermissionTypeEntity()
        {

        }

        public PermissionTypeEntity(DataAccessLogic.tblPermissionType permissionType)
        {
            this.ID = permissionType.ID;
            this.Name = permissionType.Name;
            this.Description = permissionType.Description;
            this.CreatedBy = permissionType.CreatedBy;
            this.CreatedDate = permissionType.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblPermissionType permissionType = new DataAccessLogic.tblPermissionType();
            permissionType.ID = this.ID;
            permissionType.Name = this.Name;
            permissionType.Description = this.Description;
            permissionType.CreatedBy = this.CreatedBy;
            permissionType.CreatedDate = this.CreatedDate;

            return permissionType as T;
        }
    }
}
