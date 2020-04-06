using BusinessEntity.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Meeting
{
    public class MeetingFollowupEntity : IBase
    {
        public int ID { get; set; }
        public string DetailMinute { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public MeetingScheduleEntity MeetingSchedule { get; set; }

        public MeetingFollowupEntity()
        {

        }

        public MeetingFollowupEntity(DataAccessLogic.tblMeetingFollowup meetingFollowup)
        {
            this.ID = meetingFollowup.ID;
            this.DetailMinute = meetingFollowup.DetailMinute;

            this.MeetingSchedule = new MeetingScheduleEntity(meetingFollowup.tblMeetingSchedule);

            this.CreatedBy = meetingFollowup.CreatedBy;
            this.CreatedDate = meetingFollowup.CreatedDate;
            this.UpdatedBy = meetingFollowup.UpdatedBy;
            this.UpdatedDate = meetingFollowup.UpdatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblMeetingFollowup meetingFollowup = new DataAccessLogic.tblMeetingFollowup();
            meetingFollowup.ID = this.ID;
            meetingFollowup.DetailMinute = this.DetailMinute;

            meetingFollowup.MeetingScheduleID = this.MeetingSchedule.ID;

            meetingFollowup.CreatedBy = this.CreatedBy;
            meetingFollowup.CreatedDate = this.CreatedDate;
            meetingFollowup.UpdatedBy = this.UpdatedBy;
            meetingFollowup.UpdatedDate = this.UpdatedDate;

            return meetingFollowup as T;
        }
    }
}
