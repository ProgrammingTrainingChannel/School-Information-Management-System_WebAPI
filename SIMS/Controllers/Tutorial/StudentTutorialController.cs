using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Tutorial
{
    public class StudentTutorialController : ApiController
    {
        [HttpGet]
        [Route("api/StudentTutorial/GetStudentTutorials")]
        public List<Models.Tutorial.StudentTutorialModel> GetStudentTutorials()
        {
            BusinessLogic.Tutorial.StudentTutorialManager StudentTutorialManager = new BusinessLogic.Tutorial.StudentTutorialManager();

            List<BusinessEntity.Tutorial.StudentTutorialEntity> StudentTutorials = StudentTutorialManager.GetStudentTutorials();
            List<Models.Tutorial.StudentTutorialModel> StudentTutorialModels = new List<Models.Tutorial.StudentTutorialModel>();

            foreach (BusinessEntity.Tutorial.StudentTutorialEntity StudentTutorial in StudentTutorials)
            {
                StudentTutorialModels.Add(new Models.Tutorial.StudentTutorialModel(StudentTutorial));
            }

            return StudentTutorialModels;
        }

        [HttpGet]
        [Route("api/StudentTutorial/GetStudentTutorialByID")]
        public Models.Tutorial.StudentTutorialModel GetStudentTutorialByID(int StudentTutorialID)
        {
            BusinessLogic.Tutorial.StudentTutorialManager StudentTutorialManager = new BusinessLogic.Tutorial.StudentTutorialManager();
            BusinessEntity.Tutorial.StudentTutorialEntity StudentTutorial = StudentTutorialManager.GetStudentTutorialByID(StudentTutorialID);

            return new Models.Tutorial.StudentTutorialModel(StudentTutorial);
        }

        [HttpPost]
        [Route("api/StudentTutorial/SaveStudentTutorial")]
        public BusinessEntity.Result SaveStudentTutorial(Models.Tutorial.StudentTutorialModel StudentTutorial)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Tutorial.StudentTutorialManager StudentTutorialManager = new BusinessLogic.Tutorial.StudentTutorialManager();
                result = StudentTutorialManager.SaveStudentTutorial(StudentTutorial.MapToEntity<BusinessEntity.Tutorial.StudentTutorialEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "StudentTutorial save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/StudentTutorial/UpdateStudentTutorial")]
        public BusinessEntity.Result UpdateStudentTutorial(Models.Tutorial.StudentTutorialModel StudentTutorial)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Tutorial.StudentTutorialManager StudentTutorialManager = new BusinessLogic.Tutorial.StudentTutorialManager();
                result = StudentTutorialManager.UpdateStudentTutorial(StudentTutorial.MapToEntity<BusinessEntity.Tutorial.StudentTutorialEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "StudentTutorial update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/StudentTutorial/DeleteStudentTutorial")]
        public BusinessEntity.Result DeleteStudentTutorial(Models.Tutorial.StudentTutorialModel StudentTutorial)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Tutorial.StudentTutorialManager StudentTutorialManager = new BusinessLogic.Tutorial.StudentTutorialManager();
                result = StudentTutorialManager.DeleteStudentTutorial(StudentTutorial.MapToEntity<BusinessEntity.Tutorial.StudentTutorialEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "StudentTutorial delete failed.";

                return result;
            }
        }
    }
}
