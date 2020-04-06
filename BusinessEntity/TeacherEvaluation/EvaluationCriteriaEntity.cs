using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.TeacherEvaluation
{
    public class EvaluationCriteriaEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public EvaluationCriteriaEntity()
        {

        }

        public EvaluationCriteriaEntity(DataAccessLogic.tblEvaluationCriteria evaluationCriteria)
        {
            this.ID = evaluationCriteria.ID;
            this.Name = evaluationCriteria.Name;
            this.Description = evaluationCriteria.Description;
            this.CreatedBy = evaluationCriteria.CreatedBy;
            this.CreatedDate = evaluationCriteria.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblEvaluationCriteria evaluationCriteria = new DataAccessLogic.tblEvaluationCriteria();
            evaluationCriteria.ID = this.ID;
            evaluationCriteria.Name = this.Name;
            evaluationCriteria.Description = this.Description;
            evaluationCriteria.CreatedBy = this.CreatedBy;
            evaluationCriteria.CreatedDate = this.CreatedDate;

            return evaluationCriteria as T;
        }
    }
}
