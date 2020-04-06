using SIMS.Models.Admission;
using SIMS.Models.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.ClassTeacherSchedule
{
    public class GradeCourseModel : IBase
    {
        public int ID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public CourseModel Course { get; set; }
        public GradeModel Grade { get; set; }
        public TeacherModel Teacher { get; set; }

        public GradeCourseModel()
        {

        }

        public GradeCourseModel(BusinessEntity.ClassTeacherSchedule.GradeCourseEntity course)
        {
            this.ID = course.ID;
            this.Course = new CourseModel(course.Course);
            this.Grade = new GradeModel(course.Grade);
            this.Teacher = new TeacherModel(course.Teacher);

            this.CreatedBy = course.CreatedBy;
            this.CreatedDate = course.CreatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.ClassTeacherSchedule.GradeCourseEntity course = new BusinessEntity.ClassTeacherSchedule.GradeCourseEntity();
            course.ID = this.ID;
            course.Course = this.Course.MapToEntity<BusinessEntity.Lookup.CourseEntity>();
            course.Grade = this.Grade.MapToEntity<BusinessEntity.Lookup.GradeEntity>();
            course.Teacher = this.Teacher.MapToEntity<BusinessEntity.Admission.TeacherEntity>();

            course.CreatedBy = this.CreatedBy;
            course.CreatedDate = this.CreatedDate;

            return course as T;
        }
    }
}
