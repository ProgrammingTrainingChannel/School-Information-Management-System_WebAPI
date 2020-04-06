using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Admission
{
    public class StudentManager
    {
        public List<BusinessEntity.Admission.StudentEntity> GetStudents()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblStudent> results = e.tblStudents.ToList();

            List<BusinessEntity.Admission.StudentEntity> entities = new List<BusinessEntity.Admission.StudentEntity>();
            foreach (DataAccessLogic.tblStudent Student in results)
            {
                entities.Add(new BusinessEntity.Admission.StudentEntity(Student));
            }

            return entities;
        }

        public BusinessEntity.Admission.StudentEntity GetStudentByID(int StudentID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblStudent> results = e.tblStudents.Where(x => x.ID == StudentID).ToList();

            List<BusinessEntity.Admission.StudentEntity> entities = new List<BusinessEntity.Admission.StudentEntity>();
            foreach (DataAccessLogic.tblStudent Student in results)
            {
                entities.Add(new BusinessEntity.Admission.StudentEntity(Student));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveStudent(BusinessEntity.Admission.StudentEntity Student)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblStudents.Add(Student.MapToModel<DataAccessLogic.tblStudent>());
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

        public BusinessEntity.Result UpdateStudent(BusinessEntity.Admission.StudentEntity Student)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblStudents.Find(Student.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(Student);
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

        public BusinessEntity.Result DeleteStudent(BusinessEntity.Admission.StudentEntity Student)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblStudents.Find(Student.ID);
                if (original != null)
                {
                    e.tblStudents.Remove(e.tblStudents.Where(x => x.ID == Student.ID).First());
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
