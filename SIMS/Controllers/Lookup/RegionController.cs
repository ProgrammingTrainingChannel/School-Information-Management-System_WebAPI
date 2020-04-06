using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class RegionController : ApiController
    {
        [HttpGet]
        [Route("api/Region/GetRegions")]
        public List<Models.Lookup.RegionModel> GetRegions()
        {
            BusinessLogic.Lookup.RegionManager RegionManager = new BusinessLogic.Lookup.RegionManager();

            List<BusinessEntity.Lookup.RegionEntity> Regions = RegionManager.GetRegions();
            List<Models.Lookup.RegionModel> RegionModels = new List<Models.Lookup.RegionModel>();

            foreach (BusinessEntity.Lookup.RegionEntity Region in Regions)
            {
                RegionModels.Add(new Models.Lookup.RegionModel(Region));
            }

            return RegionModels;
        }

        [HttpGet]
        [Route("api/Region/GetRegionByID")]
        public Models.Lookup.RegionModel GetRegionByID(int RegionID)
        {
            BusinessLogic.Lookup.RegionManager RegionManager = new BusinessLogic.Lookup.RegionManager();
            BusinessEntity.Lookup.RegionEntity Region = RegionManager.GetRegionByID(RegionID);

            return new Models.Lookup.RegionModel(Region);
        }

        [HttpPost]
        [Route("api/Region/SaveRegion")]
        public BusinessEntity.Result SaveRegion(Models.Lookup.RegionModel Region)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.RegionManager RegionManager = new BusinessLogic.Lookup.RegionManager();
                result = RegionManager.SaveRegion(Region.MapToEntity<BusinessEntity.Lookup.RegionEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Region save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/Region/UpdateRegion")]
        public BusinessEntity.Result UpdateRegion(Models.Lookup.RegionModel Region)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.RegionManager RegionManager = new BusinessLogic.Lookup.RegionManager();
                result = RegionManager.UpdateRegion(Region.MapToEntity<BusinessEntity.Lookup.RegionEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Region update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/Region/DeleteRegion")]
        public BusinessEntity.Result DeleteRegion(Models.Lookup.RegionModel Region)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.RegionManager RegionManager = new BusinessLogic.Lookup.RegionManager();
                result = RegionManager.DeleteRegion(Region.MapToEntity<BusinessEntity.Lookup.RegionEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Region delete failed.";

                return result;
            }
        }
    }
}
