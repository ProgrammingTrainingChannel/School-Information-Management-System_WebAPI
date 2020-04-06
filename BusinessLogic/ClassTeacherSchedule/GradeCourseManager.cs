using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ClassTeacherSchedule
{
    public class GradeCourseManager
    {
        public List<BusinessEntity.ClassTeacherSchedule.GradeCourseEntity> GetGradeCourses()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblGradeCourse> results = e.tblGradeCourses.ToList();

            List<BusinessEntity.ClassTeacherSchedule.GradeCourseEntity> entities = new List<BusinessEntity.ClassTeacherSchedule.GradeCourseEntity>();
            foreach (DataAccessLogic.tblGradeCourse GradeCourse in results)
            {
                entities.Add(new BusinessEntity.ClassTeacherSchedule.GradeCourseEntity(GradeCourse));
            }

            return entities;
        }

        public BusinessEntity.ClassTeacherSchedule.GradeCourseEntity GetGradeCourseByID(int GradeCourseID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblGradeCourse> results = e.tblGradeCourses.Where(x => x.ID == GradeCourseID).ToList();

            List<BusinessEntity.ClassTeacherSchedule.GradeCourseEntity> entities = new List<BusinessEntity.ClassTeacherSchedule.GradeCourseEntity>();
            foreach (DataAccessLogic.tblGradeCourse GradeCourse in results)
            {
                entities.Add(new BusinessEntity.ClassTeacherSchedule.GradeCourseEntity(GradeCourse));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveGradeCourse(BusinessEntity.ClassTeacherSchedule.GradeCourseEntity GradeCourse)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblGradeCourses.Add(GradeCourse.MapToModel<DataAccessLogic.tblGradeCourse>());
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

        public BusinessEntity.Result UpdateGradeCourse(BusinessEntity.ClassTeacherSchedule.GradeCourseEntity GradeCourse)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblGradeCourses.Find(GradeCourse.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(GradeCourse);
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

        public BusinessEntity.Result DeleteGradeCourse(BusinessEntity.ClassTeacherSchedule.GradeCourseEntity GradeCourse)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblGradeCourses.Find(GradeCourse.ID);
                if (original != null)
                {
                    e.tblGradeCourses.Remove(e.tblGradeCourses.Where(x => x.ID == GradeCourse.ID).First());
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
