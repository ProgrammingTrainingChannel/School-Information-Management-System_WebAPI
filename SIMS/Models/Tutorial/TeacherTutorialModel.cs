using BusinessEntity.Admission;
using BusinessEntity.Lookup;
using SIMS.Models.Admission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Tutorial
{
    public class TeacherTutorialModel : IBase
    {
        public int ID { get; set; }
        public int AcademicYear { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public TeacherModel Teacher { get; set; }

        public TeacherTutorialModel()
        {

        }

        public TeacherTutorialModel(BusinessEntity.Tutorial.TeacherTutorialEntity teacherTutorial)
        {
            this.ID = teacherTutorial.ID;
            this.AcademicYear = teacherTutorial.AcademicYear;

            this.Teacher = new TeacherModel(teacherTutorial.Teacher);

            this.CreatedBy = teacherTutorial.CreatedBy;
            this.CreatedDate = teacherTutorial.CreatedDate;
            this.UpdatedBy = teacherTutorial.UpdatedBy;
            this.UpdatedDate = teacherTutorial.UpdatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Tutorial.TeacherTutorialEntity teacherTutorial = new BusinessEntity.Tutorial.TeacherTutorialEntity();
            teacherTutorial.ID = this.ID;
            teacherTutorial.AcademicYear = this.AcademicYear;

            teacherTutorial.Teacher = this.Teacher.MapToEntity<BusinessEntity.Admission.TeacherEntity>();

            teacherTutorial.CreatedBy = this.CreatedBy;
            teacherTutorial.CreatedDate = this.CreatedDate;
            teacherTutorial.UpdatedBy = this.UpdatedBy;
            teacherTutorial.UpdatedDate = this.UpdatedDate;

            return teacherTutorial as T;
        }
    }
}
