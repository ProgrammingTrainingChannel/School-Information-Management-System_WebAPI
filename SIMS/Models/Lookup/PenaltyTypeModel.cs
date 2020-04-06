using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Lookup
{
    public class PenaltyTypeModel : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public PenaltyTypeModel()
        {

        }

        public PenaltyTypeModel(BusinessEntity.Lookup.PenalityTypeEntity penaltyType)
        {
            this.ID = penaltyType.ID;
            this.Name = penaltyType.Name;
            this.Description = penaltyType.Description;
            this.CreatedBy = penaltyType.CreatedBy;
            this.CreatedDate = penaltyType.CreatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Lookup.PenalityTypeEntity penaltyType = new BusinessEntity.Lookup.PenalityTypeEntity();
            penaltyType.ID = this.ID;
            penaltyType.Name = this.Name;
            penaltyType.Description = this.Description;
            penaltyType.CreatedBy = this.CreatedBy;
            penaltyType.CreatedDate = this.CreatedDate;

            return penaltyType as T;
        }
    }
}
