﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class MeetingTypeEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public MeetingTypeEntity()
        {

        }

        public MeetingTypeEntity(DataAccessLogic.tblMeetingType meetingType)
        {
            this.ID = meetingType.ID;
            this.Name = meetingType.Name;
            this.Description = meetingType.Description;
            this.CreatedBy = meetingType.CreatedBy;
            this.CreatedDate = meetingType.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblMeetingType meetingType = new DataAccessLogic.tblMeetingType();
            meetingType.ID = this.ID;
            meetingType.Name = this.Name;
            meetingType.Description = this.Description;
            meetingType.CreatedBy = this.CreatedBy;
            meetingType.CreatedDate = this.CreatedDate;

            return meetingType as T;
        }
    }
}
