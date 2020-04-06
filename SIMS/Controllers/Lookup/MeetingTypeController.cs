using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class MeetingTypeController : ApiController
    {
        [HttpGet]
        [Route("api/MeetingType/GetMeetingTypes")]
        public List<Models.Lookup.MeetingTypeModel> GetMeetingTypes()
        {
            BusinessLogic.Lookup.MeetingTypeManager MeetingTypeManager = new BusinessLogic.Lookup.MeetingTypeManager();

            List<BusinessEntity.Lookup.MeetingTypeEntity> MeetingTypes = MeetingTypeManager.GetMeetingTypes();
            List<Models.Lookup.MeetingTypeModel> MeetingTypeModels = new List<Models.Lookup.MeetingTypeModel>();

            foreach (BusinessEntity.Lookup.MeetingTypeEntity MeetingType in MeetingTypes)
            {
                MeetingTypeModels.Add(new Models.Lookup.MeetingTypeModel(MeetingType));
            }

            return MeetingTypeModels;
        }

        [HttpGet]
        [Route("api/MeetingType/GetMeetingTypeByID")]
        public Models.Lookup.MeetingTypeModel GetMeetingTypeByID(int MeetingTypeID)
        {
            BusinessLogic.Lookup.MeetingTypeManager MeetingTypeManager = new BusinessLogic.Lookup.MeetingTypeManager();
            BusinessEntity.Lookup.MeetingTypeEntity MeetingType = MeetingTypeManager.GetMeetingTypeByID(MeetingTypeID);

            return new Models.Lookup.MeetingTypeModel(MeetingType);
        }

        [HttpPost]
        [Route("api/MeetingType/SaveMeetingType")]
        public BusinessEntity.Result SaveMeetingType(Models.Lookup.MeetingTypeModel MeetingType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.MeetingTypeManager MeetingTypeManager = new BusinessLogic.Lookup.MeetingTypeManager();
                result = MeetingTypeManager.SaveMeetingType(MeetingType.MapToEntity<BusinessEntity.Lookup.MeetingTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "MeetingType save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/MeetingType/UpdateMeetingType")]
        public BusinessEntity.Result UpdateMeetingType(Models.Lookup.MeetingTypeModel MeetingType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.MeetingTypeManager MeetingTypeManager = new BusinessLogic.Lookup.MeetingTypeManager();
                result = MeetingTypeManager.UpdateMeetingType(MeetingType.MapToEntity<BusinessEntity.Lookup.MeetingTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "MeetingType update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/MeetingType/DeleteMeetingType")]
        public BusinessEntity.Result DeleteMeetingType(Models.Lookup.MeetingTypeModel MeetingType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.MeetingTypeManager MeetingTypeManager = new BusinessLogic.Lookup.MeetingTypeManager();
                result = MeetingTypeManager.DeleteMeetingType(MeetingType.MapToEntity<BusinessEntity.Lookup.MeetingTypeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "MeetingType delete failed.";

                return result;
            }
        }
    }
}
