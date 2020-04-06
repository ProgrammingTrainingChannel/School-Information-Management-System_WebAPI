using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class ExamTypeController : ApiController
    {
        [HttpGet]
        [Route("api/ExamType/GetExamTypes")]
        public List<Models.Lookup.ExamTypeModel> GetExamTypes()
        {
            BusinessLogic.Lookup.ExamTypeManager ExamTypeManager = new BusinessLogic.Lookup.ExamTypeManager();

            List<BusinessEntity.Lookup.ExamTypeEntity> ExamTypes = ExamTypeManager.GetExamTypes();
            List<Models.Lookup.ExamTypeModel> ExamTypeModels = new List<Models.Lookup.ExamTypeModel>();

            foreach (BusinessEntity.Lookup.ExamTypeEntity ExamType in ExamTypes)
            {
                ExamTypeModels.Add(new Models.Lookup.ExamTypeModel(ExamType));
            }

            return ExamTypeModels;
        }

        [HttpGet]
        [Route("api/ExamType/GetExamTypeByID")]
        public Models.Lookup.ExamTypeModel GetExamTypeByID(int ExamTypeID)
        {
            BusinessLogic.Lookup.ExamTypeManager ExamTypeManager = new BusinessLogic.Lookup.ExamTypeManager();
            BusinessEntity.Lookup.ExamTypeEntity ExamType = ExamTypeManager.GetExamTypeByID(ExamTypeID);

            return new Models.Lookup.ExamTypeModel(ExamType);
        }

        [HttpPost]
        [Route("api/ExamType/SaveExamType")]
        public BusinessEntity.Result SaveExamType(Models.Lookup.ExamTypeModel ExamType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.ExamTypeManager ExamTypeManager = new BusinessLogic.Lookup.ExamTypeManager();
                result = ExamTypeManager.SaveExamType(ExamType.MapToEntity<BusinessEntity.Lookup.ExamTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "ExamType save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/ExamType/UpdateExamType")]
        public BusinessEntity.Result UpdateExamType(Models.Lookup.ExamTypeModel ExamType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.ExamTypeManager ExamTypeManager = new BusinessLogic.Lookup.ExamTypeManager();
                result = ExamTypeManager.UpdateExamType(ExamType.MapToEntity<BusinessEntity.Lookup.ExamTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "ExamType update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/ExamType/DeleteExamType")]
        public BusinessEntity.Result DeleteExamType(Models.Lookup.ExamTypeModel ExamType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.ExamTypeManager ExamTypeManager = new BusinessLogic.Lookup.ExamTypeManager();
                result = ExamTypeManager.DeleteExamType(ExamType.MapToEntity<BusinessEntity.Lookup.ExamTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "ExamType delete failed.";

                return result;
            }
        }
    }
}
