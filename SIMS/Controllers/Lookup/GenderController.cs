using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class GenderController : ApiController
    {
        [HttpGet]
        [Route("api/Gender/GetGenders")]
        public List<Models.Lookup.GenderModel> GetGenders()
        {
            BusinessLogic.Lookup.GenderManager GenderManager = new BusinessLogic.Lookup.GenderManager();

            List<BusinessEntity.Lookup.GenderEntity> Genders = GenderManager.GetGenders();
            List<Models.Lookup.GenderModel> GenderModels = new List<Models.Lookup.GenderModel>();

            foreach (BusinessEntity.Lookup.GenderEntity Gender in Genders)
            {
                GenderModels.Add(new Models.Lookup.GenderModel(Gender));
            }

            return GenderModels;
        }

        [HttpGet]
        [Route("api/Gender/GetGenderByID")]
        public Models.Lookup.GenderModel GetGenderByID(int GenderID)
        {
            BusinessLogic.Lookup.GenderManager GenderManager = new BusinessLogic.Lookup.GenderManager();
            BusinessEntity.Lookup.GenderEntity Gender = GenderManager.GetGenderByID(GenderID);

            return new Models.Lookup.GenderModel(Gender);
        }

        [HttpPost]
        [Route("api/Gender/SaveGender")]
        public BusinessEntity.Result SaveGender(Models.Lookup.GenderModel Gender)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.GenderManager GenderManager = new BusinessLogic.Lookup.GenderManager();
                result = GenderManager.SaveGender(Gender.MapToEntity<BusinessEntity.Lookup.GenderEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Gender save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/Gender/UpdateGender")]
        public BusinessEntity.Result UpdateGender(Models.Lookup.GenderModel Gender)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.GenderManager GenderManager = new BusinessLogic.Lookup.GenderManager();
                result = GenderManager.UpdateGender(Gender.MapToEntity<BusinessEntity.Lookup.GenderEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Gender update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/Gender/DeleteGender")]
        public BusinessEntity.Result DeleteGender(Models.Lookup.GenderModel Gender)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.GenderManager GenderManager = new BusinessLogic.Lookup.GenderManager();
                result = GenderManager.DeleteGender(Gender.MapToEntity<BusinessEntity.Lookup.GenderEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Gender delete failed.";

                return result;
            }
        }
    }
}
