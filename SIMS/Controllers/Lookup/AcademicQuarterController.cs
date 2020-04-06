using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class AcademicQuarterController : ApiController
    {
        [HttpGet]
        [Route("api/AcademicQuarter/GetAcademicQuarters")]
        public List<Models.Lookup.AcademicQuarterModel> GetAcademicQuarters()
        {
            BusinessLogic.Lookup.AcademicQuarterManager AcademicQuarterManager = new BusinessLogic.Lookup.AcademicQuarterManager();

            List<BusinessEntity.Lookup.AcademicQuarterEntity> AcademicQuarters = AcademicQuarterManager.GetAcademicQuarters();
            List<Models.Lookup.AcademicQuarterModel> AcademicQuarterModels = new List<Models.Lookup.AcademicQuarterModel>();

            foreach (BusinessEntity.Lookup.AcademicQuarterEntity AcademicQuarter in AcademicQuarters)
            {
                AcademicQuarterModels.Add(new Models.Lookup.AcademicQuarterModel(AcademicQuarter));
            }

            return AcademicQuarterModels;
        }

        [HttpGet]
        [Route("api/AcademicQuarter/GetAcademicQuarterByID")]
        public Models.Lookup.AcademicQuarterModel GetAcademicQuarterByID(int AcademicQuarterID)
        {
            BusinessLogic.Lookup.AcademicQuarterManager AcademicQuarterManager = new BusinessLogic.Lookup.AcademicQuarterManager();
            BusinessEntity.Lookup.AcademicQuarterEntity AcademicQuarter = AcademicQuarterManager.GetAcademicQuarterByID(AcademicQuarterID);

            return new Models.Lookup.AcademicQuarterModel(AcademicQuarter);
        }

        [HttpPost]
        [Route("api/AcademicQuarter/SaveAcademicQuarter")]
        public BusinessEntity.Result SaveAcademicQuarter(Models.Lookup.AcademicQuarterModel AcademicQuarter)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.AcademicQuarterManager AcademicQuarterManager = new BusinessLogic.Lookup.AcademicQuarterManager();
                result = AcademicQuarterManager.SaveAcademicQuarter(AcademicQuarter.MapToEntity<BusinessEntity.Lookup.AcademicQuarterEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "AcademicQuarter save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/AcademicQuarter/UpdateAcademicQuarter")]
        public BusinessEntity.Result UpdateAcademicQuarter(Models.Lookup.AcademicQuarterModel AcademicQuarter)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.AcademicQuarterManager AcademicQuarterManager = new BusinessLogic.Lookup.AcademicQuarterManager();
                result = AcademicQuarterManager.UpdateAcademicQuarter(AcademicQuarter.MapToEntity<BusinessEntity.Lookup.AcademicQuarterEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "AcademicQuarter update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/AcademicQuarter/DeleteAcademicQuarter")]
        public BusinessEntity.Result DeleteAcademicQuarter(Models.Lookup.AcademicQuarterModel AcademicQuarter)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.AcademicQuarterManager AcademicQuarterManager = new BusinessLogic.Lookup.AcademicQuarterManager();
                result = AcademicQuarterManager.DeleteAcademicQuarter(AcademicQuarter.MapToEntity<BusinessEntity.Lookup.AcademicQuarterEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "AcademicQuarter delete failed.";

                return result;
            }
        }
    }
}
