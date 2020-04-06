using BusinessEntity.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Meeting
{
    public class MeetingFollowupModel : IBase
    {
        public int ID { get; set; }
        public string DetailMinute { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public MeetingScheduleModel MeetingSchedule { get; set; }

        public MeetingFollowupModel()
        {

        }

        public MeetingFollowupModel(BusinessEntity.Meeting.MeetingFollowupEntity meetingFollowup)
        {
            this.ID = meetingFollowup.ID;
            this.DetailMinute = meetingFollowup.DetailMinute;

            this.MeetingSchedule = new MeetingScheduleModel(meetingFollowup.MeetingSchedule);

            this.CreatedBy = meetingFollowup.CreatedBy;
            this.CreatedDate = meetingFollowup.CreatedDate;
            this.UpdatedBy = meetingFollowup.UpdatedBy;
            this.UpdatedDate = meetingFollowup.UpdatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Meeting.MeetingFollowupEntity meetingFollowup = new BusinessEntity.Meeting.MeetingFollowupEntity();
            meetingFollowup.ID = this.ID;
            meetingFollowup.DetailMinute = this.DetailMinute;

            meetingFollowup.MeetingSchedule = this.MeetingSchedule.MapToEntity<BusinessEntity.Meeting.MeetingScheduleEntity>();

            meetingFollowup.CreatedBy = this.CreatedBy;
            meetingFollowup.CreatedDate = this.CreatedDate;
            meetingFollowup.UpdatedBy = this.UpdatedBy;
            meetingFollowup.UpdatedDate = this.UpdatedDate;

            return meetingFollowup as T;
        }
    }
}
