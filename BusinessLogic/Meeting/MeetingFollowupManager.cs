using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Meeting
{
    public class MeetingFollowupManager
    {
        public List<BusinessEntity.Meeting.MeetingFollowupEntity> GetMeetingFollowups()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblMeetingFollowup> results = e.tblMeetingFollowups.ToList();

            List<BusinessEntity.Meeting.MeetingFollowupEntity> entities = new List<BusinessEntity.Meeting.MeetingFollowupEntity>();
            foreach (DataAccessLogic.tblMeetingFollowup MeetingFollowup in results)
            {
                entities.Add(new BusinessEntity.Meeting.MeetingFollowupEntity(MeetingFollowup));
            }

            return entities;
        }

        public BusinessEntity.Meeting.MeetingFollowupEntity GetMeetingFollowupByID(int MeetingFollowupID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblMeetingFollowup> results = e.tblMeetingFollowups.Where(x => x.ID == MeetingFollowupID).ToList();

            List<BusinessEntity.Meeting.MeetingFollowupEntity> entities = new List<BusinessEntity.Meeting.MeetingFollowupEntity>();
            foreach (DataAccessLogic.tblMeetingFollowup MeetingFollowup in results)
            {
                entities.Add(new BusinessEntity.Meeting.MeetingFollowupEntity(MeetingFollowup));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveMeetingFollowup(BusinessEntity.Meeting.MeetingFollowupEntity MeetingFollowup)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblMeetingFollowups.Add(MeetingFollowup.MapToModel<DataAccessLogic.tblMeetingFollowup>());
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

        public BusinessEntity.Result UpdateMeetingFollowup(BusinessEntity.Meeting.MeetingFollowupEntity MeetingFollowup)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblMeetingFollowups.Find(MeetingFollowup.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(MeetingFollowup);
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

        public BusinessEntity.Result DeleteMeetingFollowup(BusinessEntity.Meeting.MeetingFollowupEntity MeetingFollowup)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblMeetingFollowups.Find(MeetingFollowup.ID);
                if (original != null)
                {
                    e.tblMeetingFollowups.Remove(e.tblMeetingFollowups.Where(x => x.ID == MeetingFollowup.ID).First());
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
