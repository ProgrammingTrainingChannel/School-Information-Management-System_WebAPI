using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tutorial
{
    public class StudentTutorialManager
    {
        public List<BusinessEntity.Tutorial.StudentTutorialEntity> GetStudentTutorials()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblStudentTutorial> results = e.tblStudentTutorials.ToList();

            List<BusinessEntity.Tutorial.StudentTutorialEntity> entities = new List<BusinessEntity.Tutorial.StudentTutorialEntity>();
            foreach (DataAccessLogic.tblStudentTutorial StudentTutorial in results)
            {
                entities.Add(new BusinessEntity.Tutorial.StudentTutorialEntity(StudentTutorial));
            }

            return entities;
        }

        public BusinessEntity.Tutorial.StudentTutorialEntity GetStudentTutorialByID(int StudentTutorialID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblStudentTutorial> results = e.tblStudentTutorials.Where(x => x.ID == StudentTutorialID).ToList();

            List<BusinessEntity.Tutorial.StudentTutorialEntity> entities = new List<BusinessEntity.Tutorial.StudentTutorialEntity>();
            foreach (DataAccessLogic.tblStudentTutorial StudentTutorial in results)
            {
                entities.Add(new BusinessEntity.Tutorial.StudentTutorialEntity(StudentTutorial));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveStudentTutorial(BusinessEntity.Tutorial.StudentTutorialEntity StudentTutorial)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblStudentTutorials.Add(StudentTutorial.MapToModel<DataAccessLogic.tblStudentTutorial>());
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

        public BusinessEntity.Result UpdateStudentTutorial(BusinessEntity.Tutorial.StudentTutorialEntity StudentTutorial)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblStudentTutorials.Find(StudentTutorial.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(StudentTutorial);
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

        public BusinessEntity.Result DeleteStudentTutorial(BusinessEntity.Tutorial.StudentTutorialEntity StudentTutorial)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblStudentTutorials.Find(StudentTutorial.ID);
                if (original != null)
                {
                    e.tblStudentTutorials.Remove(e.tblStudentTutorials.Where(x => x.ID == StudentTutorial.ID).First());
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
