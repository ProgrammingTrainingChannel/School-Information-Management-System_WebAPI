using SIMS.Models.Admission;
using SIMS.Models.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMS.Models.TeacherEvaluation
{
    public class TeacherEvaluationModel : IBase
    {
        public int ID { get; set; }
        public string Mark { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public AcademicQuarterModel AcademicQuarterModel { get; set; }
        public EvaluationCriteriaModel EvaluationCriteriaModel { get; set; }
        public TeacherModel TeacherModel { get; set; }

        public TeacherEvaluationModel()
        {

        }

        public TeacherEvaluationModel(BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity TeacherEvaluation)
        {
            this.ID = TeacherEvaluation.ID;
            this.Mark = TeacherEvaluation.Mark;

            this.AcademicQuarterModel = new AcademicQuarterModel(TeacherEvaluation.AcademicQuarterEntity);
            this.EvaluationCriteriaModel = new EvaluationCriteriaModel(TeacherEvaluation.EvaluationCriteriaEntity);
            this.TeacherModel = new TeacherModel(TeacherEvaluation.TeacherEntity);

            this.CreatedBy = TeacherEvaluation.CreatedBy;
            this.CreatedDate = TeacherEvaluation.CreatedDate;
            this.UpdatedBy = TeacherEvaluation.UpdatedBy;
            this.UpdatedDate = TeacherEvaluation.UpdatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity TeacherEvaluation = new BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity();
            TeacherEvaluation.ID = this.ID;
            TeacherEvaluation.Mark = this.Mark;

            TeacherEvaluation.AcademicQuarterEntity = this.AcademicQuarterModel.MapToEntity<BusinessEntity.Lookup.AcademicQuarterEntity>();
            TeacherEvaluation.EvaluationCriteriaEntity = this.EvaluationCriteriaModel.MapToEntity<BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity>();
            TeacherEvaluation.TeacherEntity = this.TeacherModel.MapToEntity<BusinessEntity.Admission.TeacherEntity>();

            TeacherEvaluation.CreatedBy = this.CreatedBy;
            TeacherEvaluation.CreatedDate = this.CreatedDate;
            TeacherEvaluation.UpdatedBy = this.UpdatedBy;
            TeacherEvaluation.UpdatedDate = this.UpdatedDate;

            return TeacherEvaluation as T;
        }
    }
}