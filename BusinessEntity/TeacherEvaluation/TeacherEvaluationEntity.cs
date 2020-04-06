using BusinessEntity.Admission;
using BusinessEntity.Lookup;
using BusinessEntity.TeacherEvaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.TeacherEvaluation
{
    public class TeacherEvaluationEntity : IBase
    {
        public int ID { get; set; }
        public string Mark { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public AcademicQuarterEntity AcademicQuarterEntity { get; set; }
        public EvaluationCriteriaEntity EvaluationCriteriaEntity { get; set; }
        public TeacherEntity TeacherEntity { get; set; }

        public TeacherEvaluationEntity()
        {

        }

        public TeacherEvaluationEntity(DataAccessLogic.tblTeacherEvaluation TeacherEvaluation)
        {
            this.ID = TeacherEvaluation.ID;
            this.Mark = TeacherEvaluation.Mark;

            this.AcademicQuarterEntity = new AcademicQuarterEntity(TeacherEvaluation.tblAcademicQuarter);
            this.EvaluationCriteriaEntity = new EvaluationCriteriaEntity(TeacherEvaluation.tblEvaluationCriteria);
            this.TeacherEntity = new TeacherEntity(TeacherEvaluation.tblTeacher);

            this.CreatedBy = TeacherEvaluation.CreatedBy;
            this.CreatedDate = TeacherEvaluation.CreatedDate;
            this.UpdatedBy = TeacherEvaluation.UpdatedBy;
            this.UpdatedDate = TeacherEvaluation.UpdatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblTeacherEvaluation TeacherEvaluation = new DataAccessLogic.tblTeacherEvaluation();
            TeacherEvaluation.ID = this.ID;
            TeacherEvaluation.Mark = this.Mark;

            TeacherEvaluation.AcademicQuarterID = this.AcademicQuarterEntity.ID;
            TeacherEvaluation.EvaluationCriteriaID = this.EvaluationCriteriaEntity.ID;
            TeacherEvaluation.TeacherID = this.TeacherEntity.ID;

            TeacherEvaluation.CreatedBy = this.CreatedBy;
            TeacherEvaluation.CreatedDate = this.CreatedDate;
            TeacherEvaluation.CreatedBy = this.CreatedBy;
            TeacherEvaluation.CreatedDate = this.CreatedDate;

            return TeacherEvaluation as T;
        }
    }
}
