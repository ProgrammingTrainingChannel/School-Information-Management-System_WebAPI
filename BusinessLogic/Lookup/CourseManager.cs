using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class CourseManager
    {
        public List<BusinessEntity.Lookup.CourseEntity> GetCourses()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblCourse> results = e.tblCourses.ToList();

            List<BusinessEntity.Lookup.CourseEntity> entities = new List<BusinessEntity.Lookup.CourseEntity>();
            foreach (DataAccessLogic.tblCourse Course in results)
            {
                entities.Add(new BusinessEntity.Lookup.CourseEntity(Course));
            }

            return entities;
        }

        public BusinessEntity.Lookup.CourseEntity GetCourseByID(int CourseID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblCourse> results = e.tblCourses.Where(x => x.ID == CourseID).ToList();

            List<BusinessEntity.Lookup.CourseEntity> entities = new List<BusinessEntity.Lookup.CourseEntity>();
            foreach (DataAccessLogic.tblCourse Course in results)
            {
                entities.Add(new BusinessEntity.Lookup.CourseEntity(Course));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveCourse(BusinessEntity.Lookup.CourseEntity Course)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblCourses.Add(Course.MapToModel<DataAccessLogic.tblCourse>());
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

        public BusinessEntity.Result UpdateCourse(BusinessEntity.Lookup.CourseEntity Course)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblCourses.Find(Course.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(Course);
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

        public BusinessEntity.Result DeleteCourse(BusinessEntity.Lookup.CourseEntity Course)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblCourses.Find(Course.ID);
                if (original != null)
                {
                    e.tblCourses.Remove(e.tblCourses.Where(x => x.ID == Course.ID).First());
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
