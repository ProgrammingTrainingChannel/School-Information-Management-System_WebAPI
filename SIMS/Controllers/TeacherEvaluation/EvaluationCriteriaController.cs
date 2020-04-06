using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.TeacherEvaluation
{
    public class EvaluationCriteriaController : ApiController
    {
        [HttpGet]
        [Route("api/EvaluationCriteria/GetEvaluationCriterias")]
        public List<Models.TeacherEvaluation.EvaluationCriteriaModel> GetEvaluationCriterias()
        {
            BusinessLogic.TeacherEvaluation.EvaluationCriteriaManager EvaluationCriteriaManager = new BusinessLogic.TeacherEvaluation.EvaluationCriteriaManager();

            List<BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity> EvaluationCriterias = EvaluationCriteriaManager.GetEvaluationCriterias();
            List<Models.TeacherEvaluation.EvaluationCriteriaModel> EvaluationCriteriaModels = new List<Models.TeacherEvaluation.EvaluationCriteriaModel>();

            foreach (BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity EvaluationCriteria in EvaluationCriterias)
            {
                EvaluationCriteriaModels.Add(new Models.TeacherEvaluation.EvaluationCriteriaModel(EvaluationCriteria));
            }

            return EvaluationCriteriaModels;
        }

        [HttpGet]
        [Route("api/EvaluationCriteria/GetEvaluationCriteriaByID")]
        public Models.TeacherEvaluation.EvaluationCriteriaModel GetEvaluationCriteriaByID(int EvaluationCriteriaID)
        {
            BusinessLogic.TeacherEvaluation.EvaluationCriteriaManager EvaluationCriteriaManager = new BusinessLogic.TeacherEvaluation.EvaluationCriteriaManager();
            BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity EvaluationCriteria = EvaluationCriteriaManager.GetEvaluationCriteriaByID(EvaluationCriteriaID);

            return new Models.TeacherEvaluation.EvaluationCriteriaModel(EvaluationCriteria);
        }

        [HttpPost]
        [Route("api/EvaluationCriteria/SaveEvaluationCriteria")]
        public BusinessEntity.Result SaveEvaluationCriteria(Models.TeacherEvaluation.EvaluationCriteriaModel EvaluationCriteria)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.TeacherEvaluation.EvaluationCriteriaManager EvaluationCriteriaManager = new BusinessLogic.TeacherEvaluation.EvaluationCriteriaManager();
                result = EvaluationCriteriaManager.SaveEvaluationCriteria(EvaluationCriteria.MapToEntity<BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "EvaluationCriteria save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/EvaluationCriteria/UpdateEvaluationCriteria")]
        public BusinessEntity.Result UpdateEvaluationCriteria(Models.TeacherEvaluation.EvaluationCriteriaModel EvaluationCriteria)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.TeacherEvaluation.EvaluationCriteriaManager EvaluationCriteriaManager = new BusinessLogic.TeacherEvaluation.EvaluationCriteriaManager();
                result = EvaluationCriteriaManager.UpdateEvaluationCriteria(EvaluationCriteria.MapToEntity<BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "EvaluationCriteria update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/EvaluationCriteria/DeleteEvaluationCriteria")]
        public BusinessEntity.Result DeleteEvaluationCriteria(Models.TeacherEvaluation.EvaluationCriteriaModel EvaluationCriteria)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.TeacherEvaluation.EvaluationCriteriaManager EvaluationCriteriaManager = new BusinessLogic.TeacherEvaluation.EvaluationCriteriaManager();
                result = EvaluationCriteriaManager.DeleteEvaluationCriteria(EvaluationCriteria.MapToEntity<BusinessEntity.TeacherEvaluation.EvaluationCriteriaEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "EvaluationCriteria delete failed.";

                return result;
            }
        }
    }
}
