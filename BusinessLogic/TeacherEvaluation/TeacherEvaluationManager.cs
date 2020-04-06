using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.TeacherEvaluation
{
    public class TeacherEvaluationManager
    {
        public List<BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity> GetTeacherEvaluations()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblTeacherEvaluation> results = e.tblTeacherEvaluations.ToList();

            List<BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity> entities = new List<BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity>();
            foreach (DataAccessLogic.tblTeacherEvaluation TeacherEvaluation in results)
            {
                entities.Add(new BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity(TeacherEvaluation));
            }

            return entities;
        }

        public BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity GetTeacherEvaluationByID(int TeacherEvaluationID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblTeacherEvaluation> results = e.tblTeacherEvaluations.Where(x => x.ID == TeacherEvaluationID).ToList();

            List<BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity> entities = new List<BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity>();
            foreach (DataAccessLogic.tblTeacherEvaluation TeacherEvaluation in results)
            {
                entities.Add(new BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity(TeacherEvaluation));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveTeacherEvaluation(BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity TeacherEvaluation)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblTeacherEvaluations.Add(TeacherEvaluation.MapToModel<DataAccessLogic.tblTeacherEvaluation>());
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

        public BusinessEntity.Result UpdateTeacherEvaluation(BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity TeacherEvaluation)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblTeacherEvaluations.Find(TeacherEvaluation.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(TeacherEvaluation);
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

        public BusinessEntity.Result DeleteTeacherEvaluation(BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity TeacherEvaluation)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblTeacherEvaluations.Find(TeacherEvaluation.ID);
                if (original != null)
                {
                    e.tblTeacherEvaluations.Remove(e.tblTeacherEvaluations.Where(x => x.ID == TeacherEvaluation.ID).First());
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
