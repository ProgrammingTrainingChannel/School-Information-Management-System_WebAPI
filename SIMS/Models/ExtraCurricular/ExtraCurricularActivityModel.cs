using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.ExtraCurricular
{
    public class ExtraCurricularActivityModel : IBase
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime PlannedDate { get; set; }
        public Nullable<System.DateTime> ActualDate { get; set; }
        public string Organizers { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public ExtraCurricularActivityModel()
        {

        }

        public ExtraCurricularActivityModel(BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity extraCurricularActivity)
        {
            this.ID = extraCurricularActivity.ID;
            this.Title = extraCurricularActivity.Title;
            this.Description = extraCurricularActivity.Description;
            this.PlannedDate = extraCurricularActivity.PlannedDate;
            this.ActualDate = extraCurricularActivity.ActualDate;
            this.Organizers = extraCurricularActivity.Organizers;
            this.CreatedBy = extraCurricularActivity.CreatedBy;
            this.CreatedDate = extraCurricularActivity.CreatedDate;
            this.UpdatedBy = extraCurricularActivity.UpdatedBy;
            this.UpdatedDate = extraCurricularActivity.UpdatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity extraCurricularActivity = new BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity();
            extraCurricularActivity.ID = this.ID;
            extraCurricularActivity.Title = this.Title;
            extraCurricularActivity.Description = this.Description;
            extraCurricularActivity.PlannedDate = this.PlannedDate;
            extraCurricularActivity.ActualDate = this.ActualDate;
            extraCurricularActivity.Organizers = this.Organizers;
            extraCurricularActivity.CreatedBy = this.CreatedBy;
            extraCurricularActivity.CreatedDate = this.CreatedDate;
            extraCurricularActivity.UpdatedBy = this.UpdatedBy;
            extraCurricularActivity.UpdatedDate = this.UpdatedDate;

            return extraCurricularActivity as T;
        }
    }
}
