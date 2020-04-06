using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Tutorial
{
    public class TeacherTutorialController : ApiController
    {
        [HttpGet]
        [Route("api/TeacherTutorial/GetTeacherTutorials")]
        public List<Models.Tutorial.TeacherTutorialModel> GetTeacherTutorials()
        {
            BusinessLogic.Tutorial.TeacherTutorialManager TeacherTutorialManager = new BusinessLogic.Tutorial.TeacherTutorialManager();

            List<BusinessEntity.Tutorial.TeacherTutorialEntity> TeacherTutorials = TeacherTutorialManager.GetTeacherTutorials();
            List<Models.Tutorial.TeacherTutorialModel> TeacherTutorialModels = new List<Models.Tutorial.TeacherTutorialModel>();

            foreach (BusinessEntity.Tutorial.TeacherTutorialEntity TeacherTutorial in TeacherTutorials)
            {
                TeacherTutorialModels.Add(new Models.Tutorial.TeacherTutorialModel(TeacherTutorial));
            }

            return TeacherTutorialModels;
        }

        [HttpGet]
        [Route("api/TeacherTutorial/GetTeacherTutorialByID")]
        public Models.Tutorial.TeacherTutorialModel GetTeacherTutorialByID(int TeacherTutorialID)
        {
            BusinessLogic.Tutorial.TeacherTutorialManager TeacherTutorialManager = new BusinessLogic.Tutorial.TeacherTutorialManager();
            BusinessEntity.Tutorial.TeacherTutorialEntity TeacherTutorial = TeacherTutorialManager.GetTeacherTutorialByID(TeacherTutorialID);

            return new Models.Tutorial.TeacherTutorialModel(TeacherTutorial);
        }

        [HttpPost]
        [Route("api/TeacherTutorial/SaveTeacherTutorial")]
        public BusinessEntity.Result SaveTeacherTutorial(Models.Tutorial.TeacherTutorialModel TeacherTutorial)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Tutorial.TeacherTutorialManager TeacherTutorialManager = new BusinessLogic.Tutorial.TeacherTutorialManager();
                result = TeacherTutorialManager.SaveTeacherTutorial(TeacherTutorial.MapToEntity<BusinessEntity.Tutorial.TeacherTutorialEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "TeacherTutorial save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/TeacherTutorial/UpdateTeacherTutorial")]
        public BusinessEntity.Result UpdateTeacherTutorial(Models.Tutorial.TeacherTutorialModel TeacherTutorial)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Tutorial.TeacherTutorialManager TeacherTutorialManager = new BusinessLogic.Tutorial.TeacherTutorialManager();
                result = TeacherTutorialManager.UpdateTeacherTutorial(TeacherTutorial.MapToEntity<BusinessEntity.Tutorial.TeacherTutorialEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "TeacherTutorial update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/TeacherTutorial/DeleteTeacherTutorial")]
        public BusinessEntity.Result DeleteTeacherTutorial(Models.Tutorial.TeacherTutorialModel TeacherTutorial)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Tutorial.TeacherTutorialManager TeacherTutorialManager = new BusinessLogic.Tutorial.TeacherTutorialManager();
                result = TeacherTutorialManager.DeleteTeacherTutorial(TeacherTutorial.MapToEntity<BusinessEntity.Tutorial.TeacherTutorialEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "TeacherTutorial delete failed.";

                return result;
            }
        }
    }
}
