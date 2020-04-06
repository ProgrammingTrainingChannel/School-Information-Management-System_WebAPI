using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class GradeManager
    {
        public List<BusinessEntity.Lookup.GradeEntity> GetGrades()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblGrade> results = e.tblGrades.ToList();

            List<BusinessEntity.Lookup.GradeEntity> entities = new List<BusinessEntity.Lookup.GradeEntity>();
            foreach (DataAccessLogic.tblGrade Grade in results)
            {
                entities.Add(new BusinessEntity.Lookup.GradeEntity(Grade));
            }

            return entities;
        }

        public BusinessEntity.Lookup.GradeEntity GetGradeByID(int GradeID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblGrade> results = e.tblGrades.Where(x => x.ID == GradeID).ToList();

            List<BusinessEntity.Lookup.GradeEntity> entities = new List<BusinessEntity.Lookup.GradeEntity>();
            foreach (DataAccessLogic.tblGrade Grade in results)
            {
                entities.Add(new BusinessEntity.Lookup.GradeEntity(Grade));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveGrade(BusinessEntity.Lookup.GradeEntity Grade)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblGrades.Add(Grade.MapToModel<DataAccessLogic.tblGrade>());
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

        public BusinessEntity.Result UpdateGrade(BusinessEntity.Lookup.GradeEntity Grade)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblGrades.Find(Grade.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(Grade);
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

        public BusinessEntity.Result DeleteGrade(BusinessEntity.Lookup.GradeEntity Grade)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblGrades.Find(Grade.ID);
                if (original != null)
                {
                    e.tblGrades.Remove(e.tblGrades.Where(x => x.ID == Grade.ID).First());
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
