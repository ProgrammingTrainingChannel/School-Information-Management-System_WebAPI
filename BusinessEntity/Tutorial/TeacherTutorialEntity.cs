using BusinessEntity.Admission;
using BusinessEntity.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Tutorial
{
    public class TeacherTutorialEntity : IBase
    {
        public int ID { get; set; }
        public int AcademicYear { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public TeacherEntity Teacher { get; set; }

        public TeacherTutorialEntity()
        {

        }

        public TeacherTutorialEntity(DataAccessLogic.tblTeacherTutorial teacherTutorial)
        {
            this.ID = teacherTutorial.ID;
            this.AcademicYear = teacherTutorial.AcademicYear;

            this.Teacher = new TeacherEntity(teacherTutorial.tblTeacher);

            this.CreatedBy = teacherTutorial.CreatedBy;
            this.CreatedDate = teacherTutorial.CreatedDate;
            this.UpdatedBy = teacherTutorial.UpdatedBy;
            this.UpdatedDate = teacherTutorial.UpdatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblTeacherTutorial teacherTutorial = new DataAccessLogic.tblTeacherTutorial();
            teacherTutorial.ID = this.ID;
            teacherTutorial.AcademicYear = this.AcademicYear;

            teacherTutorial.TeacherID = this.Teacher.ID;

            teacherTutorial.CreatedBy = this.CreatedBy;
            teacherTutorial.CreatedDate = this.CreatedDate;
            teacherTutorial.UpdatedBy = this.UpdatedBy;
            teacherTutorial.UpdatedDate = this.UpdatedDate;

            return teacherTutorial as T;
        }
    }
}
