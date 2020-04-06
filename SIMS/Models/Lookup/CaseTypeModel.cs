using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Lookup
{
    public class CaseTypeModel : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public CaseTypeModel()
        {

        }

        public CaseTypeModel(BusinessEntity.Lookup.CaseTypeEntity caseType)
        {
            this.ID = caseType.ID;
            this.Name = caseType.Name;
            this.Description = caseType.Description;
            this.CreatedBy = caseType.CreatedBy;
            this.CreatedDate = caseType.CreatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Lookup.CaseTypeEntity caseType = new BusinessEntity.Lookup.CaseTypeEntity();
            caseType.ID = this.ID;
            caseType.Name = this.Name;
            caseType.Description = this.Description;
            caseType.CreatedBy = this.CreatedBy;
            caseType.CreatedDate = this.CreatedDate;

            return caseType as T;
        }
    }
}
