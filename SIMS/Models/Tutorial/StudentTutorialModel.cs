using BusinessEntity.Admission;
using BusinessEntity.Lookup;
using SIMS.Models.Admission;
using SIMS.Models.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Tutorial
{
    public class StudentTutorialModel : IBase
    {
        public int ID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public GradeSectionModel GradeSection { get; set; }
        public StudentModel Student { get; set; }

        public StudentTutorialModel()
        {

        }

        public StudentTutorialModel(BusinessEntity.Tutorial.StudentTutorialEntity studentTutorial)
        {
            this.ID = studentTutorial.ID;

            this.Student = new StudentModel(studentTutorial.Student);
            this.GradeSection = new GradeSectionModel(studentTutorial.GradeSection);

            this.CreatedBy = studentTutorial.CreatedBy;
            this.CreatedDate = studentTutorial.CreatedDate;
            this.UpdatedBy = studentTutorial.UpdatedBy;
            this.UpdatedDate = studentTutorial.UpdatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Tutorial.StudentTutorialEntity studentTutorial = new BusinessEntity.Tutorial.StudentTutorialEntity();
            studentTutorial.ID = this.ID;

            studentTutorial.Student = this.Student.MapToEntity<BusinessEntity.Admission.StudentEntity>();
            studentTutorial.GradeSection = this.GradeSection.MapToEntity<BusinessEntity.Lookup.GradeSectionEntity>();

            studentTutorial.CreatedBy = this.CreatedBy;
            studentTutorial.CreatedDate = this.CreatedDate;
            studentTutorial.UpdatedBy = this.UpdatedBy;
            studentTutorial.UpdatedDate = this.UpdatedDate;

            return studentTutorial as T;
        }
    }
}
