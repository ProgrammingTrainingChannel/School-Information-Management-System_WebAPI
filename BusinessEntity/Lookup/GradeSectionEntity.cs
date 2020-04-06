using BusinessEntity.Admission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class GradeSectionEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public GradeEntity Grade { get; set; }
        public TeacherEntity RoomTeacher { get; set; }

        public GradeSectionEntity()
        {

        }

        public GradeSectionEntity(DataAccessLogic.tblGradeSection gradeSection)
        {
            this.ID = gradeSection.ID;
            this.Name = gradeSection.Name;

            this.Grade = new GradeEntity(gradeSection.tblGrade);
            this.RoomTeacher = new TeacherEntity(gradeSection.tblTeacher);

            this.CreatedBy = gradeSection.CreatedBy;
            this.CreatedDate = gradeSection.CreatedDate;
            this.UpdatedBy = gradeSection.UpdatedBy;
            this.UpdatedDate = gradeSection.UpdatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblGradeSection gradeSection = new DataAccessLogic.tblGradeSection();
            gradeSection.ID = this.ID;
            gradeSection.Name = this.Name;

            gradeSection.GradeID = this.Grade.ID;
            gradeSection.RoomTeacherID = this.RoomTeacher.ID;

            gradeSection.CreatedBy = this.CreatedBy;
            gradeSection.CreatedDate = this.CreatedDate;

            return gradeSection as T;
        }
    }
}
