using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class MaritalStatusEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public MaritalStatusEntity()
        {

        }

        public MaritalStatusEntity(DataAccessLogic.tblMaritalStatu maritalStatus)
        {
            this.ID = maritalStatus.ID;
            this.Name = maritalStatus.Name;
            this.Description = maritalStatus.Description;
            this.CreatedBy = maritalStatus.CreatedBy;
            this.CreatedDate = maritalStatus.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblMaritalStatu maritalStatus = new DataAccessLogic.tblMaritalStatu();
            maritalStatus.ID = this.ID;
            maritalStatus.Name = this.Name;
            maritalStatus.Description = this.Description;
            maritalStatus.CreatedBy = this.CreatedBy;
            maritalStatus.CreatedDate = this.CreatedDate;

            return maritalStatus as T;
        }
    }
}
