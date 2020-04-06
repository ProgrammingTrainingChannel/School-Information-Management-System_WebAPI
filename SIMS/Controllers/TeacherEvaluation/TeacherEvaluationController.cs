using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.TeacherEvaluation
{
    public class TeacherEvaluationController : ApiController
    {
        [HttpGet]
        [Route("api/TeacherEvaluation/GetTeacherEvaluations")]
        public List<Models.TeacherEvaluation.TeacherEvaluationModel> GetTeacherEvaluations()
        {
            BusinessLogic.TeacherEvaluation.TeacherEvaluationManager TeacherEvaluationManager = new BusinessLogic.TeacherEvaluation.TeacherEvaluationManager();

            List<BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity> TeacherEvaluations = TeacherEvaluationManager.GetTeacherEvaluations();
            List<Models.TeacherEvaluation.TeacherEvaluationModel> TeacherEvaluationModels = new List<Models.TeacherEvaluation.TeacherEvaluationModel>();

            foreach (BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity TeacherEvaluation in TeacherEvaluations)
            {
                TeacherEvaluationModels.Add(new Models.TeacherEvaluation.TeacherEvaluationModel(TeacherEvaluation));
            }

            return TeacherEvaluationModels;
        }

        [HttpGet]
        [Route("api/TeacherEvaluation/GetTeacherEvaluationByID")]
        public Models.TeacherEvaluation.TeacherEvaluationModel GetTeacherEvaluationByID(int TeacherEvaluationID)
        {
            BusinessLogic.TeacherEvaluation.TeacherEvaluationManager TeacherEvaluationManager = new BusinessLogic.TeacherEvaluation.TeacherEvaluationManager();
            BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity TeacherEvaluation = TeacherEvaluationManager.GetTeacherEvaluationByID(TeacherEvaluationID);

            return new Models.TeacherEvaluation.TeacherEvaluationModel(TeacherEvaluation);
        }

        [HttpPost]
        [Route("api/TeacherEvaluation/SaveTeacherEvaluation")]
        public BusinessEntity.Result SaveTeacherEvaluation(Models.TeacherEvaluation.TeacherEvaluationModel TeacherEvaluation)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.TeacherEvaluation.TeacherEvaluationManager TeacherEvaluationManager = new BusinessLogic.TeacherEvaluation.TeacherEvaluationManager();
                result = TeacherEvaluationManager.SaveTeacherEvaluation(TeacherEvaluation.MapToEntity<BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "TeacherEvaluation save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/TeacherEvaluation/UpdateTeacherEvaluation")]
        public BusinessEntity.Result UpdateTeacherEvaluation(Models.TeacherEvaluation.TeacherEvaluationModel TeacherEvaluation)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.TeacherEvaluation.TeacherEvaluationManager TeacherEvaluationManager = new BusinessLogic.TeacherEvaluation.TeacherEvaluationManager();
                result = TeacherEvaluationManager.UpdateTeacherEvaluation(TeacherEvaluation.MapToEntity<BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "TeacherEvaluation update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/TeacherEvaluation/DeleteTeacherEvaluation")]
        public BusinessEntity.Result DeleteTeacherEvaluation(Models.TeacherEvaluation.TeacherEvaluationModel TeacherEvaluation)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.TeacherEvaluation.TeacherEvaluationManager TeacherEvaluationManager = new BusinessLogic.TeacherEvaluation.TeacherEvaluationManager();
                result = TeacherEvaluationManager.DeleteTeacherEvaluation(TeacherEvaluation.MapToEntity<BusinessEntity.TeacherEvaluation.TeacherEvaluationEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "TeacherEvaluation delete failed.";

                return result;
            }
        }
    }
}
