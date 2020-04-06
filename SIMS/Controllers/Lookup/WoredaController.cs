using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class WoredaController : ApiController
    {
        [HttpGet]
        [Route("api/Woreda/GetWoredas")]
        public List<Models.Lookup.WoredaModel> GetWoredas()
        {
            BusinessLogic.Lookup.WoredaManager WoredaManager = new BusinessLogic.Lookup.WoredaManager();

            List<BusinessEntity.Lookup.WoredaEntity> Woredas = WoredaManager.GetWoredas();
            List<Models.Lookup.WoredaModel> WoredaModels = new List<Models.Lookup.WoredaModel>();

            foreach (BusinessEntity.Lookup.WoredaEntity Woreda in Woredas)
            {
                WoredaModels.Add(new Models.Lookup.WoredaModel(Woreda));
            }

            return WoredaModels;
        }

        [HttpGet]
        [Route("api/Woreda/GetWoredaByID")]
        public Models.Lookup.WoredaModel GetWoredaByID(int WoredaID)
        {
            BusinessLogic.Lookup.WoredaManager WoredaManager = new BusinessLogic.Lookup.WoredaManager();
            BusinessEntity.Lookup.WoredaEntity Woreda = WoredaManager.GetWoredaByID(WoredaID);

            return new Models.Lookup.WoredaModel(Woreda);
        }

        [HttpPost]
        [Route("api/Woreda/SaveWoreda")]
        public BusinessEntity.Result SaveWoreda(Models.Lookup.WoredaModel Woreda)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.WoredaManager WoredaManager = new BusinessLogic.Lookup.WoredaManager();
                result = WoredaManager.SaveWoreda(Woreda.MapToEntity<BusinessEntity.Lookup.WoredaEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Woreda save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/Woreda/UpdateWoreda")]
        public BusinessEntity.Result UpdateWoreda(Models.Lookup.WoredaModel Woreda)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.WoredaManager WoredaManager = new BusinessLogic.Lookup.WoredaManager();
                result = WoredaManager.UpdateWoreda(Woreda.MapToEntity<BusinessEntity.Lookup.WoredaEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Woreda update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/Woreda/DeleteWoreda")]
        public BusinessEntity.Result DeleteWoreda(Models.Lookup.WoredaModel Woreda)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.WoredaManager WoredaManager = new BusinessLogic.Lookup.WoredaManager();
                result = WoredaManager.DeleteWoreda(Woreda.MapToEntity<BusinessEntity.Lookup.WoredaEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Woreda delete failed.";

                return result;
            }
        }
    }
}
