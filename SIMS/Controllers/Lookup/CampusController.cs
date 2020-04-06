using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class CampusController : ApiController
    {
        [HttpGet]
        [Route("api/Campus/GetCampuss")]
        public List<Models.Lookup.CampusModel> GetCampuss()
        {
            BusinessLogic.Lookup.CampusManager CampusManager = new BusinessLogic.Lookup.CampusManager();

            List<BusinessEntity.Lookup.CampusEntity> Campuss = CampusManager.GetCampuss();
            List<Models.Lookup.CampusModel> CampusModels = new List<Models.Lookup.CampusModel>();

            foreach (BusinessEntity.Lookup.CampusEntity Campus in Campuss)
            {
                CampusModels.Add(new Models.Lookup.CampusModel(Campus));
            }

            return CampusModels;
        }

        [HttpGet]
        [Route("api/Campus/GetCampusByID")]
        public Models.Lookup.CampusModel GetCampusByID(int CampusID)
        {
            BusinessLogic.Lookup.CampusManager CampusManager = new BusinessLogic.Lookup.CampusManager();
            BusinessEntity.Lookup.CampusEntity Campus = CampusManager.GetCampusByID(CampusID);

            return new Models.Lookup.CampusModel(Campus);
        }

        [HttpPost]
        [Route("api/Campus/SaveCampus")]
        public BusinessEntity.Result SaveCampus(Models.Lookup.CampusModel Campus)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.CampusManager CampusManager = new BusinessLogic.Lookup.CampusManager();
                result = CampusManager.SaveCampus(Campus.MapToEntity<BusinessEntity.Lookup.CampusEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Campus save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/Campus/UpdateCampus")]
        public BusinessEntity.Result UpdateCampus(Models.Lookup.CampusModel Campus)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.CampusManager CampusManager = new BusinessLogic.Lookup.CampusManager();
                result = CampusManager.UpdateCampus(Campus.MapToEntity<BusinessEntity.Lookup.CampusEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Campus update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/Campus/DeleteCampus")]
        public BusinessEntity.Result DeleteCampus(Models.Lookup.CampusModel Campus)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.CampusManager CampusManager = new BusinessLogic.Lookup.CampusManager();
                result = CampusManager.DeleteCampus(Campus.MapToEntity<BusinessEntity.Lookup.CampusEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Campus delete failed.";

                return result;
            }
        }
    }
}
