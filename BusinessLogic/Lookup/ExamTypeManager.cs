using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class ExamTypeManager
    {
        public List<BusinessEntity.Lookup.ExamTypeEntity> GetExamTypes()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblExamType> results = e.tblExamTypes.ToList();

            List<BusinessEntity.Lookup.ExamTypeEntity> entities = new List<BusinessEntity.Lookup.ExamTypeEntity>();
            foreach (DataAccessLogic.tblExamType ExamType in results)
            {
                entities.Add(new BusinessEntity.Lookup.ExamTypeEntity(ExamType));
            }

            return entities;
        }

        public BusinessEntity.Lookup.ExamTypeEntity GetExamTypeByID(int ExamTypeID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblExamType> results = e.tblExamTypes.Where(x => x.ID == ExamTypeID).ToList();

            List<BusinessEntity.Lookup.ExamTypeEntity> entities = new List<BusinessEntity.Lookup.ExamTypeEntity>();
            foreach (DataAccessLogic.tblExamType ExamType in results)
            {
                entities.Add(new BusinessEntity.Lookup.ExamTypeEntity(ExamType));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveExamType(BusinessEntity.Lookup.ExamTypeEntity ExamType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblExamTypes.Add(ExamType.MapToModel<DataAccessLogic.tblExamType>());
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

        public BusinessEntity.Result UpdateExamType(BusinessEntity.Lookup.ExamTypeEntity ExamType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblExamTypes.Find(ExamType.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(ExamType);
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

        public BusinessEntity.Result DeleteExamType(BusinessEntity.Lookup.ExamTypeEntity ExamType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblExamTypes.Find(ExamType.ID);
                if (original != null)
                {
                    e.tblExamTypes.Remove(e.tblExamTypes.Where(x => x.ID == ExamType.ID).First());
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
