using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class PenalityTypeEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public PenalityTypeEntity()
        {

        }

        public PenalityTypeEntity(DataAccessLogic.tblPenalityType penalityType)
        {
            this.ID = penalityType.ID;
            this.Name = penalityType.Name;
            this.Description = penalityType.Description;
            this.CreatedBy = penalityType.CreatedBy;
            this.CreatedDate = penalityType.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblPenalityType penalityType = new DataAccessLogic.tblPenalityType();
            penalityType.ID = this.ID;
            penalityType.Name = this.Name;
            penalityType.Description = this.Description;
            penalityType.CreatedBy = this.CreatedBy;
            penalityType.CreatedDate = this.CreatedDate;

            return penalityType as T;
        }
    }
}
