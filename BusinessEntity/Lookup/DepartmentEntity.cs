using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class DepartmentEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public DepartmentEntity()
        {

        }

        public DepartmentEntity(DataAccessLogic.tblDepartment department)
        {
            this.ID = department.ID;
            this.Name = department.Name;
            this.Description = department.Description;
            this.CreatedBy = department.CreatedBy;
            this.CreatedDate = department.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblDepartment department = new DataAccessLogic.tblDepartment();
            department.ID = this.ID;
            department.Name = this.Name;
            department.Description = this.Description;
            department.CreatedBy = this.CreatedBy;
            department.CreatedDate = this.CreatedDate;

            return department as T;
        }
    }
}
