using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tutorial
{
    public class TeacherTutorialManager
    {
        public List<BusinessEntity.Tutorial.TeacherTutorialEntity> GetTeacherTutorials()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblTeacherTutorial> results = e.tblTeacherTutorials.ToList();

            List<BusinessEntity.Tutorial.TeacherTutorialEntity> entities = new List<BusinessEntity.Tutorial.TeacherTutorialEntity>();
            foreach (DataAccessLogic.tblTeacherTutorial TeacherTutorial in results)
            {
                entities.Add(new BusinessEntity.Tutorial.TeacherTutorialEntity(TeacherTutorial));
            }

            return entities;
        }

        public BusinessEntity.Tutorial.TeacherTutorialEntity GetTeacherTutorialByID(int TeacherTutorialID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblTeacherTutorial> results = e.tblTeacherTutorials.Where(x => x.ID == TeacherTutorialID).ToList();

            List<BusinessEntity.Tutorial.TeacherTutorialEntity> entities = new List<BusinessEntity.Tutorial.TeacherTutorialEntity>();
            foreach (DataAccessLogic.tblTeacherTutorial TeacherTutorial in results)
            {
                entities.Add(new BusinessEntity.Tutorial.TeacherTutorialEntity(TeacherTutorial));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveTeacherTutorial(BusinessEntity.Tutorial.TeacherTutorialEntity TeacherTutorial)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblTeacherTutorials.Add(TeacherTutorial.MapToModel<DataAccessLogic.tblTeacherTutorial>());
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

        public BusinessEntity.Result UpdateTeacherTutorial(BusinessEntity.Tutorial.TeacherTutorialEntity TeacherTutorial)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblTeacherTutorials.Find(TeacherTutorial.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(TeacherTutorial);
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

        public BusinessEntity.Result DeleteTeacherTutorial(BusinessEntity.Tutorial.TeacherTutorialEntity TeacherTutorial)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblTeacherTutorials.Find(TeacherTutorial.ID);
                if (original != null)
                {
                    e.tblTeacherTutorials.Remove(e.tblTeacherTutorials.Where(x => x.ID == TeacherTutorial.ID).First());
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
