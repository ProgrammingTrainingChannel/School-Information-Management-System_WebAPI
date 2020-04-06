using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class CaseTypeController : ApiController
    {
        [HttpGet]
        [Route("api/CaseType/GetCaseTypes")]
        public List<Models.Lookup.CaseTypeModel> GetCaseTypes()
        {
            BusinessLogic.Lookup.CaseTypeManager CaseTypeManager = new BusinessLogic.Lookup.CaseTypeManager();

            List<BusinessEntity.Lookup.CaseTypeEntity> CaseTypes = CaseTypeManager.GetCaseTypes();
            List<Models.Lookup.CaseTypeModel> CaseTypeModels = new List<Models.Lookup.CaseTypeModel>();

            foreach (BusinessEntity.Lookup.CaseTypeEntity CaseType in CaseTypes)
            {
                CaseTypeModels.Add(new Models.Lookup.CaseTypeModel(CaseType));
            }

            return CaseTypeModels;
        }

        [HttpGet]
        [Route("api/CaseType/GetCaseTypeByID")]
        public Models.Lookup.CaseTypeModel GetCaseTypeByID(int CaseTypeID)
        {
            BusinessLogic.Lookup.CaseTypeManager CaseTypeManager = new BusinessLogic.Lookup.CaseTypeManager();
            BusinessEntity.Lookup.CaseTypeEntity CaseType = CaseTypeManager.GetCaseTypeByID(CaseTypeID);

            return new Models.Lookup.CaseTypeModel(CaseType);
        }

        [HttpPost]
        [Route("api/CaseType/SaveCaseType")]
        public BusinessEntity.Result SaveCaseType(Models.Lookup.CaseTypeModel CaseType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.CaseTypeManager CaseTypeManager = new BusinessLogic.Lookup.CaseTypeManager();
                result = CaseTypeManager.SaveCaseType(CaseType.MapToEntity<BusinessEntity.Lookup.CaseTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "CaseType save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/CaseType/UpdateCaseType")]
        public BusinessEntity.Result UpdateCaseType(Models.Lookup.CaseTypeModel CaseType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.CaseTypeManager CaseTypeManager = new BusinessLogic.Lookup.CaseTypeManager();
                result = CaseTypeManager.UpdateCaseType(CaseType.MapToEntity<BusinessEntity.Lookup.CaseTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "CaseType update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/CaseType/DeleteCaseType")]
        public BusinessEntity.Result DeleteCaseType(Models.Lookup.CaseTypeModel CaseType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.CaseTypeManager CaseTypeManager = new BusinessLogic.Lookup.CaseTypeManager();
                result = CaseTypeManager.DeleteCaseType(CaseType.MapToEntity<BusinessEntity.Lookup.CaseTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "CaseType delete failed.";

                return result;
            }
        }
    }
}
