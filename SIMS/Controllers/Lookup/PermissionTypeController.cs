using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class PermissionTypeController : ApiController
    {
        [HttpGet]
        [Route("api/PermissionType/GetPermissionTypes")]
        public List<Models.Lookup.PermissionTypeModel> GetPermissionTypes()
        {
            BusinessLogic.Lookup.PermissionTypeManager PermissionTypeManager = new BusinessLogic.Lookup.PermissionTypeManager();

            List<BusinessEntity.Lookup.PermissionTypeEntity> PermissionTypes = PermissionTypeManager.GetPermissionTypes();
            List<Models.Lookup.PermissionTypeModel> PermissionTypeModels = new List<Models.Lookup.PermissionTypeModel>();

            foreach (BusinessEntity.Lookup.PermissionTypeEntity PermissionType in PermissionTypes)
            {
                PermissionTypeModels.Add(new Models.Lookup.PermissionTypeModel(PermissionType));
            }

            return PermissionTypeModels;
        }

        [HttpGet]
        [Route("api/PermissionType/GetPermissionTypeByID")]
        public Models.Lookup.PermissionTypeModel GetPermissionTypeByID(int PermissionTypeID)
        {
            BusinessLogic.Lookup.PermissionTypeManager PermissionTypeManager = new BusinessLogic.Lookup.PermissionTypeManager();
            BusinessEntity.Lookup.PermissionTypeEntity PermissionType = PermissionTypeManager.GetPermissionTypeByID(PermissionTypeID);

            return new Models.Lookup.PermissionTypeModel(PermissionType);
        }

        [HttpPost]
        [Route("api/PermissionType/SavePermissionType")]
        public BusinessEntity.Result SavePermissionType(Models.Lookup.PermissionTypeModel PermissionType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.PermissionTypeManager PermissionTypeManager = new BusinessLogic.Lookup.PermissionTypeManager();
                result = PermissionTypeManager.SavePermissionType(PermissionType.MapToEntity<BusinessEntity.Lookup.PermissionTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "PermissionType save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/PermissionType/UpdatePermissionType")]
        public BusinessEntity.Result UpdatePermissionType(Models.Lookup.PermissionTypeModel PermissionType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.PermissionTypeManager PermissionTypeManager = new BusinessLogic.Lookup.PermissionTypeManager();
                result = PermissionTypeManager.UpdatePermissionType(PermissionType.MapToEntity<BusinessEntity.Lookup.PermissionTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "PermissionType update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/PermissionType/DeletePermissionType")]
        public BusinessEntity.Result DeletePermissionType(Models.Lookup.PermissionTypeModel PermissionType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.PermissionTypeManager PermissionTypeManager = new BusinessLogic.Lookup.PermissionTypeManager();
                result = PermissionTypeManager.DeletePermissionType(PermissionType.MapToEntity<BusinessEntity.Lookup.PermissionTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "PermissionType delete failed.";

                return result;
            }
        }
    }
}
