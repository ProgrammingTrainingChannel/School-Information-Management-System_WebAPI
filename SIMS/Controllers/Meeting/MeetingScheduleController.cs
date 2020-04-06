using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Meeting
{
    public class MeetingScheduleController : ApiController
    {
        [HttpGet]
        [Route("api/MeetingSchedule/GetMeetingSchedules")]
        public List<Models.Meeting.MeetingScheduleModel> GetMeetingSchedules()
        {
            BusinessLogic.Meeting.MeetingScheduleManager MeetingScheduleManager = new BusinessLogic.Meeting.MeetingScheduleManager();

            List<BusinessEntity.Meeting.MeetingScheduleEntity> MeetingSchedules = MeetingScheduleManager.GetMeetingSchedules();
            List<Models.Meeting.MeetingScheduleModel> MeetingScheduleModels = new List<Models.Meeting.MeetingScheduleModel>();

            foreach (BusinessEntity.Meeting.MeetingScheduleEntity MeetingSchedule in MeetingSchedules)
            {
                MeetingScheduleModels.Add(new Models.Meeting.MeetingScheduleModel(MeetingSchedule));
            }

            return MeetingScheduleModels;
        }

        [HttpGet]
        [Route("api/MeetingSchedule/GetMeetingScheduleByID")]
        public Models.Meeting.MeetingScheduleModel GetMeetingScheduleByID(int MeetingScheduleID)
        {
            BusinessLogic.Meeting.MeetingScheduleManager MeetingScheduleManager = new BusinessLogic.Meeting.MeetingScheduleManager();
            BusinessEntity.Meeting.MeetingScheduleEntity MeetingSchedule = MeetingScheduleManager.GetMeetingScheduleByID(MeetingScheduleID);

            return new Models.Meeting.MeetingScheduleModel(MeetingSchedule);
        }

        [HttpPost]
        [Route("api/MeetingSchedule/SaveMeetingSchedule")]
        public BusinessEntity.Result SaveMeetingSchedule(Models.Meeting.MeetingScheduleModel MeetingSchedule)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Meeting.MeetingScheduleManager MeetingScheduleManager = new BusinessLogic.Meeting.MeetingScheduleManager();
                result = MeetingScheduleManager.SaveMeetingSchedule(MeetingSchedule.MapToEntity<BusinessEntity.Meeting.MeetingScheduleEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "MeetingSchedule save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/MeetingSchedule/UpdateMeetingSchedule")]
        public BusinessEntity.Result UpdateMeetingSchedule(Models.Meeting.MeetingScheduleModel MeetingSchedule)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Meeting.MeetingScheduleManager MeetingScheduleManager = new BusinessLogic.Meeting.MeetingScheduleManager();
                result = MeetingScheduleManager.UpdateMeetingSchedule(MeetingSchedule.MapToEntity<BusinessEntity.Meeting.MeetingScheduleEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "MeetingSchedule update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/MeetingSchedule/DeleteMeetingSchedule")]
        public BusinessEntity.Result DeleteMeetingSchedule(Models.Meeting.MeetingScheduleModel MeetingSchedule)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Meeting.MeetingScheduleManager MeetingScheduleManager = new BusinessLogic.Meeting.MeetingScheduleManager();
                result = MeetingScheduleManager.DeleteMeetingSchedule(MeetingSchedule.MapToEntity<BusinessEntity.Meeting.MeetingScheduleEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "MeetingSchedule delete failed.";

                return result;
            }
        }
    }
}
