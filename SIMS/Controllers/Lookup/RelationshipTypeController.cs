using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class RelationshipTypeController : ApiController
    {
        [HttpGet]
        [Route("api/RelationshipType/GetRelationshipTypes")]
        public List<Models.Lookup.RelationshipTypeModel> GetRelationshipTypes()
        {
            BusinessLogic.Lookup.RelationshipTypeManager RelationshipTypeManager = new BusinessLogic.Lookup.RelationshipTypeManager();

            List<BusinessEntity.Lookup.RelationshipTypeEntity> RelationshipTypes = RelationshipTypeManager.GetRelationshipTypes();
            List<Models.Lookup.RelationshipTypeModel> RelationshipTypeModels = new List<Models.Lookup.RelationshipTypeModel>();

            foreach (BusinessEntity.Lookup.RelationshipTypeEntity RelationshipType in RelationshipTypes)
            {
                RelationshipTypeModels.Add(new Models.Lookup.RelationshipTypeModel(RelationshipType));
            }

            return RelationshipTypeModels;
        }

        [HttpGet]
        [Route("api/RelationshipType/GetRelationshipTypeByID")]
        public Models.Lookup.RelationshipTypeModel GetRelationshipTypeByID(int RelationshipTypeID)
        {
            BusinessLogic.Lookup.RelationshipTypeManager RelationshipTypeManager = new BusinessLogic.Lookup.RelationshipTypeManager();
            BusinessEntity.Lookup.RelationshipTypeEntity RelationshipType = RelationshipTypeManager.GetRelationshipTypeByID(RelationshipTypeID);

            return new Models.Lookup.RelationshipTypeModel(RelationshipType);
        }

        [HttpPost]
        [Route("api/RelationshipType/SaveRelationshipType")]
        public BusinessEntity.Result SaveRelationshipType(Models.Lookup.RelationshipTypeModel RelationshipType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.RelationshipTypeManager RelationshipTypeManager = new BusinessLogic.Lookup.RelationshipTypeManager();
                result = RelationshipTypeManager.SaveRelationshipType(RelationshipType.MapToEntity<BusinessEntity.Lookup.RelationshipTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "RelationshipType save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/RelationshipType/UpdateRelationshipType")]
        public BusinessEntity.Result UpdateRelationshipType(Models.Lookup.RelationshipTypeModel RelationshipType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.RelationshipTypeManager RelationshipTypeManager = new BusinessLogic.Lookup.RelationshipTypeManager();
                result = RelationshipTypeManager.UpdateRelationshipType(RelationshipType.MapToEntity<BusinessEntity.Lookup.RelationshipTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "RelationshipType update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/RelationshipType/DeleteRelationshipType")]
        public BusinessEntity.Result DeleteRelationshipType(Models.Lookup.RelationshipTypeModel RelationshipType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.RelationshipTypeManager RelationshipTypeManager = new BusinessLogic.Lookup.RelationshipTypeManager();
                result = RelationshipTypeManager.DeleteRelationshipType(RelationshipType.MapToEntity<BusinessEntity.Lookup.RelationshipTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "RelationshipType delete failed.";

                return result;
            }
        }
    }
}
