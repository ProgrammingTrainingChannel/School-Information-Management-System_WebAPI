using BusinessEntity.Admission;
using BusinessEntity.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.ClassTeacherSchedule
{
    public class GradeCourseEntity : IBase
    {
        public int ID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public CourseEntity Course { get; set; }
        public GradeEntity Grade { get; set; }
        public TeacherEntity Teacher { get; set; }

        public GradeCourseEntity()
        {

        }

        public GradeCourseEntity(DataAccessLogic.tblGradeCourse gradeCourse)
        {
            this.ID = gradeCourse.ID;
            this.Course = new CourseEntity(gradeCourse.tblCourse);
            this.Grade = new GradeEntity(gradeCourse.tblGrade);
            this.Teacher = new TeacherEntity(gradeCourse.tblTeacher);

            this.CreatedBy = gradeCourse.CreatedBy;
            this.CreatedDate = gradeCourse.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblGradeCourse gradeCourse = new DataAccessLogic.tblGradeCourse();
            gradeCourse.ID = this.ID;
            gradeCourse.CourseID = this.Course.ID;
            gradeCourse.GradeID = this.Grade.ID;
            gradeCourse.TeacherID = this.Teacher.ID;

            gradeCourse.CreatedBy = this.CreatedBy;
            gradeCourse.CreatedDate = this.CreatedDate;

            return gradeCourse as T;
        }
    }
}
