using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMS.Models.TeacherEvaluation
{
    public class EvaluationCriteriaModel : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public EvaluationCriteriaModel()
        {

        }

        public EvaluationCriteriaModel(BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity EvaluationCriteria)
        {
            this.ID = EvaluationCriteria.ID;
            this.Name = EvaluationCriteria.Name;
            this.Description = EvaluationCriteria.Description;
            this.CreatedBy = EvaluationCriteria.CreatedBy;
            this.CreatedDate = EvaluationCriteria.CreatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity EvaluationCriteria = new BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity();
            EvaluationCriteria.ID = this.ID;
            EvaluationCriteria.Name = this.Name;
            EvaluationCriteria.Description = this.Description;
            EvaluationCriteria.CreatedBy = this.CreatedBy;
            EvaluationCriteria.CreatedDate = this.CreatedDate;

            return EvaluationCriteria as T;
        }
    }
}