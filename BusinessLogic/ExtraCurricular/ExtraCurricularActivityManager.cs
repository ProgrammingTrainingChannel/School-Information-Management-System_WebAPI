using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ExtraCurricular
{
    public class ExtraCurricularActivityManager
    {
        public List<BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity> GetExtraCurricularActivitys()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblExtraCurricularActivity> results = e.tblExtraCurricularActivities.ToList();

            List<BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity> entities = new List<BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity>();
            foreach (DataAccessLogic.tblExtraCurricularActivity ExtraCurricularActivity in results)
            {
                entities.Add(new BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity(ExtraCurricularActivity));
            }

            return entities;
        }

        public BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity GetExtraCurricularActivityByID(int ExtraCurricularActivityID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblExtraCurricularActivity> results = e.tblExtraCurricularActivities.Where(x => x.ID == ExtraCurricularActivityID).ToList();

            List<BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity> entities = new List<BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity>();
            foreach (DataAccessLogic.tblExtraCurricularActivity ExtraCurricularActivity in results)
            {
                entities.Add(new BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity(ExtraCurricularActivity));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveExtraCurricularActivity(BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity ExtraCurricularActivity)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblExtraCurricularActivities.Add(ExtraCurricularActivity.MapToModel<DataAccessLogic.tblExtraCurricularActivity>());
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

        public BusinessEntity.Result UpdateExtraCurricularActivity(BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity ExtraCurricularActivity)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblExtraCurricularActivities.Find(ExtraCurricularActivity.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(ExtraCurricularActivity);
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

        public BusinessEntity.Result DeleteExtraCurricularActivity(BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity ExtraCurricularActivity)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblExtraCurricularActivities.Find(ExtraCurricularActivity.ID);
                if (original != null)
                {
                    e.tblExtraCurricularActivities.Remove(e.tblExtraCurricularActivities.Where(x => x.ID == ExtraCurricularActivity.ID).First());
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
