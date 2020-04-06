using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.ExtraCurricular
{
    public class ExtraCurricularActivityController : ApiController
    {
        [HttpGet]
        [Route("api/ExtraCurricularActivity/GetExtraCurricularActivitys")]
        public List<Models.ExtraCurricular.ExtraCurricularActivityModel> GetExtraCurricularActivitys()
        {
            BusinessLogic.ExtraCurricular.ExtraCurricularActivityManager ExtraCurricularActivityManager = new BusinessLogic.ExtraCurricular.ExtraCurricularActivityManager();

            List<BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity> ExtraCurricularActivitys = ExtraCurricularActivityManager.GetExtraCurricularActivitys();
            List<Models.ExtraCurricular.ExtraCurricularActivityModel> ExtraCurricularActivityModels = new List<Models.ExtraCurricular.ExtraCurricularActivityModel>();

            foreach (BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity ExtraCurricularActivity in ExtraCurricularActivitys)
            {
                ExtraCurricularActivityModels.Add(new Models.ExtraCurricular.ExtraCurricularActivityModel(ExtraCurricularActivity));
            }

            return ExtraCurricularActivityModels;
        }

        [HttpGet]
        [Route("api/ExtraCurricularActivity/GetExtraCurricularActivityByID")]
        public Models.ExtraCurricular.ExtraCurricularActivityModel GetExtraCurricularActivityByID(int ExtraCurricularActivityID)
        {
            BusinessLogic.ExtraCurricular.ExtraCurricularActivityManager ExtraCurricularActivityManager = new BusinessLogic.ExtraCurricular.ExtraCurricularActivityManager();
            BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity ExtraCurricularActivity = ExtraCurricularActivityManager.GetExtraCurricularActivityByID(ExtraCurricularActivityID);

            return new Models.ExtraCurricular.ExtraCurricularActivityModel(ExtraCurricularActivity);
        }

        [HttpPost]
        [Route("api/ExtraCurricularActivity/SaveExtraCurricularActivity")]
        public BusinessEntity.Result SaveExtraCurricularActivity(Models.ExtraCurricular.ExtraCurricularActivityModel ExtraCurricularActivity)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.ExtraCurricular.ExtraCurricularActivityManager ExtraCurricularActivityManager = new BusinessLogic.ExtraCurricular.ExtraCurricularActivityManager();
                result = ExtraCurricularActivityManager.SaveExtraCurricularActivity(ExtraCurricularActivity.MapToEntity<BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "ExtraCurricularActivity save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/ExtraCurricularActivity/UpdateExtraCurricularActivity")]
        public BusinessEntity.Result UpdateExtraCurricularActivity(Models.ExtraCurricular.ExtraCurricularActivityModel ExtraCurricularActivity)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.ExtraCurricular.ExtraCurricularActivityManager ExtraCurricularActivityManager = new BusinessLogic.ExtraCurricular.ExtraCurricularActivityManager();
                result = ExtraCurricularActivityManager.UpdateExtraCurricularActivity(ExtraCurricularActivity.MapToEntity<BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "ExtraCurricularActivity update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/ExtraCurricularActivity/DeleteExtraCurricularActivity")]
        public BusinessEntity.Result DeleteExtraCurricularActivity(Models.ExtraCurricular.ExtraCurricularActivityModel ExtraCurricularActivity)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.ExtraCurricular.ExtraCurricularActivityManager ExtraCurricularActivityManager = new BusinessLogic.ExtraCurricular.ExtraCurricularActivityManager();
                result = ExtraCurricularActivityManager.DeleteExtraCurricularActivity(ExtraCurricularActivity.MapToEntity<BusinessEntity.ExtraCurricular.ExtraCurricularActivityEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "ExtraCurricularActivity delete failed.";

                return result;
            }
        }
    }
}
