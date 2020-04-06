using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class PenaltyTypeController : ApiController
    {
        [HttpGet]
        [Route("api/PenaltyType/GetPenaltyTypes")]
        public List<Models.Lookup.PenaltyTypeModel> GetPenaltyTypes()
        {
            BusinessLogic.Lookup.PenaltyTypeManager PenaltyTypeManager = new BusinessLogic.Lookup.PenaltyTypeManager();

            List<BusinessEntity.Lookup.PenalityTypeEntity> PenaltyTypes = PenaltyTypeManager.GetPenaltyTypes();
            List<Models.Lookup.PenaltyTypeModel> PenaltyTypeModels = new List<Models.Lookup.PenaltyTypeModel>();

            foreach (BusinessEntity.Lookup.PenalityTypeEntity PenaltyType in PenaltyTypes)
            {
                PenaltyTypeModels.Add(new Models.Lookup.PenaltyTypeModel(PenaltyType));
            }

            return PenaltyTypeModels;
        }

        [HttpGet]
        [Route("api/PenaltyType/GetPenaltyTypeByID")]
        public Models.Lookup.PenaltyTypeModel GetPenaltyTypeByID(int PenaltyTypeID)
        {
            BusinessLogic.Lookup.PenaltyTypeManager PenaltyTypeManager = new BusinessLogic.Lookup.PenaltyTypeManager();
            BusinessEntity.Lookup.PenalityTypeEntity PenaltyType = PenaltyTypeManager.GetPenaltyTypeByID(PenaltyTypeID);

            return new Models.Lookup.PenaltyTypeModel(PenaltyType);
        }

        [HttpPost]
        [Route("api/PenaltyType/SavePenaltyType")]
        public BusinessEntity.Result SavePenaltyType(Models.Lookup.PenaltyTypeModel PenaltyType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.PenaltyTypeManager PenaltyTypeManager = new BusinessLogic.Lookup.PenaltyTypeManager();
                result = PenaltyTypeManager.SavePenaltyType(PenaltyType.MapToEntity<BusinessEntity.Lookup.PenalityTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "PenaltyType save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/PenaltyType/UpdatePenaltyType")]
        public BusinessEntity.Result UpdatePenaltyType(Models.Lookup.PenaltyTypeModel PenaltyType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.PenaltyTypeManager PenaltyTypeManager = new BusinessLogic.Lookup.PenaltyTypeManager();
                result = PenaltyTypeManager.UpdatePenaltyType(PenaltyType.MapToEntity<BusinessEntity.Lookup.PenalityTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "PenaltyType update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/PenaltyType/DeletePenaltyType")]
        public BusinessEntity.Result DeletePenaltyType(Models.Lookup.PenaltyTypeModel PenaltyType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.PenaltyTypeManager PenaltyTypeManager = new BusinessLogic.Lookup.PenaltyTypeManager();
                result = PenaltyTypeManager.DeletePenaltyType(PenaltyType.MapToEntity<BusinessEntity.Lookup.PenalityTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "PenaltyType delete failed.";

                return result;
            }
        }
    }
}
