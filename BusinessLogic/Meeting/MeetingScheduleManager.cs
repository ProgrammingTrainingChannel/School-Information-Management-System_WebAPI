using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Meeting
{
    public class MeetingScheduleManager
    {
        public List<BusinessEntity.Meeting.MeetingScheduleEntity> GetMeetingSchedules()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblMeetingSchedule> results = e.tblMeetingSchedules.ToList();

            List<BusinessEntity.Meeting.MeetingScheduleEntity> entities = new List<BusinessEntity.Meeting.MeetingScheduleEntity>();
            foreach (DataAccessLogic.tblMeetingSchedule MeetingSchedule in results)
            {
                entities.Add(new BusinessEntity.Meeting.MeetingScheduleEntity(MeetingSchedule));
            }

            return entities;
        }

        public BusinessEntity.Meeting.MeetingScheduleEntity GetMeetingScheduleByID(int MeetingScheduleID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblMeetingSchedule> results = e.tblMeetingSchedules.Where(x => x.ID == MeetingScheduleID).ToList();

            List<BusinessEntity.Meeting.MeetingScheduleEntity> entities = new List<BusinessEntity.Meeting.MeetingScheduleEntity>();
            foreach (DataAccessLogic.tblMeetingSchedule MeetingSchedule in results)
            {
                entities.Add(new BusinessEntity.Meeting.MeetingScheduleEntity(MeetingSchedule));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveMeetingSchedule(BusinessEntity.Meeting.MeetingScheduleEntity MeetingSchedule)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblMeetingSchedules.Add(MeetingSchedule.MapToModel<DataAccessLogic.tblMeetingSchedule>());
                e.SaveChanges();

                result.Message = "Saved Successfully.";
                result.Status = true;
                return result;
            }
            catch (Exception)
            {
                result.Message = "Failed to save";
                result.Status = false;
                return result;
            }
        }

        public BusinessEntity.Result UpdateMeetingSchedule(BusinessEntity.Meeting.MeetingScheduleEntity MeetingSchedule)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblMeetingSchedules.Find(MeetingSchedule.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(MeetingSchedule);
                    e.SaveChanges();

                    result.Message = "Updated Successfully.";
                    result.Status = true;
                    return result;
                }
                else
                {
                    result.Message = "Failed to update";
                    result.Status = false;
                    return result;
                }
            }
            catch (Exception)
            {
                result.Message = "Failed to update";
                result.Status = false;
                return result;
            }
        }

        public BusinessEntity.Result DeleteMeetingSchedule(BusinessEntity.Meeting.MeetingScheduleEntity MeetingSchedule)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblMeetingSchedules.Find(MeetingSchedule.ID);
                if (original != null)
                {
                    e.tblMeetingSchedules.Remove(e.tblMeetingSchedules.Where(x => x.ID == MeetingSchedule.ID).First());
                    e.SaveChanges();

                    result.Message = "Deleted Successfully.";
                    result.Status = true;
                    return result;
                }
                else
                {
                    result.Message = "Failed to delete";
                    result.Status = false;
                    return result;
                }
            }
            catch (Exception)
            {
                result.Message = "Failed to delete";
                result.Status = false;
                return result;
            }
        }
    }
}
