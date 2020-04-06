using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Meeting
{
    public class MeetingFollowupController : ApiController
    {
        [HttpGet]
        [Route("api/MeetingFollowup/GetMeetingFollowups")]
        public List<Models.Meeting.MeetingFollowupModel> GetMeetingFollowups()
        {
            BusinessLogic.Meeting.MeetingFollowupManager MeetingFollowupManager = new BusinessLogic.Meeting.MeetingFollowupManager();

            List<BusinessEntity.Meeting.MeetingFollowupEntity> MeetingFollowups = MeetingFollowupManager.GetMeetingFollowups();
            List<Models.Meeting.MeetingFollowupModel> MeetingFollowupModels = new List<Models.Meeting.MeetingFollowupModel>();

            foreach (BusinessEntity.Meeting.MeetingFollowupEntity MeetingFollowup in MeetingFollowups)
            {
                MeetingFollowupModels.Add(new Models.Meeting.MeetingFollowupModel(MeetingFollowup));
            }

            return MeetingFollowupModels;
        }

        [HttpGet]
        [Route("api/MeetingFollowup/GetMeetingFollowupByID")]
        public Models.Meeting.MeetingFollowupModel GetMeetingFollowupByID(int MeetingFollowupID)
        {
            BusinessLogic.Meeting.MeetingFollowupManager MeetingFollowupManager = new BusinessLogic.Meeting.MeetingFollowupManager();
            BusinessEntity.Meeting.MeetingFollowupEntity MeetingFollowup = MeetingFollowupManager.GetMeetingFollowupByID(MeetingFollowupID);

            return new Models.Meeting.MeetingFollowupModel(MeetingFollowup);
        }

        [HttpPost]
        [Route("api/MeetingFollowup/SaveMeetingFollowup")]
        public BusinessEntity.Result SaveMeetingFollowup(Models.Meeting.MeetingFollowupModel MeetingFollowup)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Meeting.MeetingFollowupManager MeetingFollowupManager = new BusinessLogic.Meeting.MeetingFollowupManager();
                result = MeetingFollowupManager.SaveMeetingFollowup(MeetingFollowup.MapToEntity<BusinessEntity.Meeting.MeetingFollowupEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "MeetingFollowup save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/MeetingFollowup/UpdateMeetingFollowup")]
        public BusinessEntity.Result UpdateMeetingFollowup(Models.Meeting.MeetingFollowupModel MeetingFollowup)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Meeting.MeetingFollowupManager MeetingFollowupManager = new BusinessLogic.Meeting.MeetingFollowupManager();
                result = MeetingFollowupManager.UpdateMeetingFollowup(MeetingFollowup.MapToEntity<BusinessEntity.Meeting.MeetingFollowupEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "MeetingFollowup update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/MeetingFollowup/DeleteMeetingFollowup")]
        public BusinessEntity.Result DeleteMeetingFollowup(Models.Meeting.MeetingFollowupModel MeetingFollowup)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Meeting.MeetingFollowupManager MeetingFollowupManager = new BusinessLogic.Meeting.MeetingFollowupManager();
                result = MeetingFollowupManager.DeleteMeetingFollowup(MeetingFollowup.MapToEntity<BusinessEntity.Meeting.MeetingFollowupEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "MeetingFollowup delete failed.";

                return result;
            }
        }
    }
}
