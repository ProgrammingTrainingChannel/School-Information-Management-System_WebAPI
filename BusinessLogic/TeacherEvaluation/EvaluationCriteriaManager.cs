using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.TeacherEvaluation
{
    public class EvaluationCriteriaManager
    {
        public List<BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity> GetEvaluationCriterias()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblEvaluationCriteria> results = e.tblEvaluationCriterias.ToList();

            List<BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity> entities = new List<BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity>();
            foreach (DataAccessLogic.tblEvaluationCriteria EvaluationCriteria in results)
            {
                entities.Add(new BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity(EvaluationCriteria));
            }

            return entities;
        }

        public BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity GetEvaluationCriteriaByID(int EvaluationCriteriaID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblEvaluationCriteria> results = e.tblEvaluationCriterias.Where(x => x.ID == EvaluationCriteriaID).ToList();

            List<BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity> entities = new List<BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity>();
            foreach (DataAccessLogic.tblEvaluationCriteria EvaluationCriteria in results)
            {
                entities.Add(new BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity(EvaluationCriteria));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveEvaluationCriteria(BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity EvaluationCriteria)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblEvaluationCriterias.Add(EvaluationCriteria.MapToModel<DataAccessLogic.tblEvaluationCriteria>());
                e.SaveChanges();

                result.Message = "Saved Successfully.";
                result.Status = true;
                return result;
            }
            catch (Exception)
            {
                result.Message = "Failed to save";
                result.Status = false;
                return result;
            }
        }

        public BusinessEntity.Result UpdateEvaluationCriteria(BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity EvaluationCriteria)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblEvaluationCriterias.Find(EvaluationCriteria.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(EvaluationCriteria);
                    e.SaveChanges();

                    result.Message = "Updated Successfully.";
                    result.Status = true;
                    return result;
                }
                else
                {
                    result.Message = "Failed to update";
                    result.Status = false;
                    return result;
                }
            }
            catch (Exception)
            {
                result.Message = "Failed to update";
                result.Status = false;
                return result;
            }
        }

        public BusinessEntity.Result DeleteEvaluationCriteria(BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity EvaluationCriteria)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblEvaluationCriterias.Find(EvaluationCriteria.ID);
                if (original != null)
                {
                    e.tblEvaluationCriterias.Remove(e.tblEvaluationCriterias.Where(x => x.ID == EvaluationCriteria.ID).First());
                    e.SaveChanges();

                    result.Message = "Deleted Successfully.";
                    result.Status = true;
                    return result;
                }
                else
                {
                    result.Message = "Failed to delete";
                    result.Status = false;
                    return result;
                }
            }
            catch (Exception)
            {
                result.Message = "Failed to delete";
                result.Status = false;
                return result;
            }
        }
    }
}
