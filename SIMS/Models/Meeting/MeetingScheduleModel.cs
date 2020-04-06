using BusinessEntity.Lookup;
using SIMS.Models.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Meeting
{
    public class MeetingScheduleModel : IBase
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public System.DateTime EndDate { get; set; }
        public string EndTime { get; set; }
        public string GeneralAgenda { get; set; }
        public string Organizer { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public MeetingTypeModel MeetingType { get; set; }

        public MeetingScheduleModel()
        {

        }

        public MeetingScheduleModel(BusinessEntity.Meeting.MeetingScheduleEntity meetingSchedule)
        {
            this.ID = meetingSchedule.ID;
            this.Title = meetingSchedule.Title;
            this.Description = meetingSchedule.Description;
            this.StartDate = meetingSchedule.StartDate;
            this.StartTime = meetingSchedule.StartTime;
            this.EndDate = meetingSchedule.EndDate;
            this.EndTime = meetingSchedule.EndTime;
            this.GeneralAgenda = meetingSchedule.GeneralAgenda;
            this.Organizer = meetingSchedule.Organizer;

            this.MeetingType = new MeetingTypeModel(meetingSchedule.MeetingType);

            this.CreatedBy = meetingSchedule.CreatedBy;
            this.CreatedDate = meetingSchedule.CreatedDate;
            this.UpdatedBy = meetingSchedule.UpdatedBy;
            this.UpdatedDate = meetingSchedule.UpdatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Meeting.MeetingScheduleEntity meetingSchedule = new BusinessEntity.Meeting.MeetingScheduleEntity();
            meetingSchedule.ID = this.ID;
            meetingSchedule.Title = this.Title;
            meetingSchedule.Description = this.Description;
            meetingSchedule.StartDate = this.StartDate;
            meetingSchedule.StartTime = this.StartTime;
            meetingSchedule.EndDate = this.EndDate;
            meetingSchedule.EndTime = this.EndTime;
            meetingSchedule.GeneralAgenda = this.GeneralAgenda;
            meetingSchedule.Organizer = this.Organizer;

            meetingSchedule.MeetingType = this.MeetingType.MapToEntity<BusinessEntity.Lookup.MeetingTypeEntity>();

            meetingSchedule.CreatedBy = this.CreatedBy;
            meetingSchedule.CreatedDate = this.CreatedDate;
            meetingSchedule.UpdatedBy = this.UpdatedBy;
            meetingSchedule.UpdatedDate = this.UpdatedDate;

            return meetingSchedule as T;
        }
    }
}
