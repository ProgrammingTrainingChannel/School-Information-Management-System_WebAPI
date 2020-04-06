using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class SubCityController : ApiController
    {
        [HttpGet]
        [Route("api/SubCity/GetSubCitys")]
        public List<Models.Lookup.SubCityModel> GetSubCitys()
        {
            BusinessLogic.Lookup.SubCityManager SubCityManager = new BusinessLogic.Lookup.SubCityManager();

            List<BusinessEntity.Lookup.SubCityEntity> SubCitys = SubCityManager.GetSubCitys();
            List<Models.Lookup.SubCityModel> SubCityModels = new List<Models.Lookup.SubCityModel>();

            foreach (BusinessEntity.Lookup.SubCityEntity SubCity in SubCitys)
            {
                SubCityModels.Add(new Models.Lookup.SubCityModel(SubCity));
            }

            return SubCityModels;
        }

        [HttpGet]
        [Route("api/SubCity/GetSubCityByID")]
        public Models.Lookup.SubCityModel GetSubCityByID(int SubCityID)
        {
            BusinessLogic.Lookup.SubCityManager SubCityManager = new BusinessLogic.Lookup.SubCityManager();
            BusinessEntity.Lookup.SubCityEntity SubCity = SubCityManager.GetSubCityByID(SubCityID);

            return new Models.Lookup.SubCityModel(SubCity);
        }

        [HttpPost]
        [Route("api/SubCity/SaveSubCity")]
        public BusinessEntity.Result SaveSubCity(Models.Lookup.SubCityModel SubCity)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.SubCityManager SubCityManager = new BusinessLogic.Lookup.SubCityManager();
                result = SubCityManager.SaveSubCity(SubCity.MapToEntity<BusinessEntity.Lookup.SubCityEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "SubCity save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/SubCity/UpdateSubCity")]
        public BusinessEntity.Result UpdateSubCity(Models.Lookup.SubCityModel SubCity)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.SubCityManager SubCityManager = new BusinessLogic.Lookup.SubCityManager();
                result = SubCityManager.UpdateSubCity(SubCity.MapToEntity<BusinessEntity.Lookup.SubCityEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "SubCity update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/SubCity/DeleteSubCity")]
        public BusinessEntity.Result DeleteSubCity(Models.Lookup.SubCityModel SubCity)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.SubCityManager SubCityManager = new BusinessLogic.Lookup.SubCityManager();
                result = SubCityManager.DeleteSubCity(SubCity.MapToEntity<BusinessEntity.Lookup.SubCityEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "SubCity delete failed.";

                return result;
            }
        }
    }
}
