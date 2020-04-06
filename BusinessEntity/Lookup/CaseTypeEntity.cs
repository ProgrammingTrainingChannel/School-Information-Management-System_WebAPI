using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class CaseTypeEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public CaseTypeEntity()
        {

        }

        public CaseTypeEntity(DataAccessLogic.tblCaseType caseType)
        {
            this.ID = caseType.ID;
            this.Name = caseType.Name;
            this.Description = caseType.Description;
            this.CreatedBy = caseType.CreatedBy;
            this.CreatedDate = caseType.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblPenalityType caseType = new DataAccessLogic.tblPenalityType();
            caseType.ID = this.ID;
            caseType.Name = this.Name;
            caseType.Description = this.Description;
            caseType.CreatedBy = this.CreatedBy;
            caseType.CreatedDate = this.CreatedDate;

            return caseType as T;
        }
    }
}
