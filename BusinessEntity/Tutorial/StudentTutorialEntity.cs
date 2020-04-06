using BusinessEntity.Admission;
using BusinessEntity.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Tutorial
{
    public class StudentTutorialEntity : IBase
    {
        public int ID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public GradeSectionEntity GradeSection { get; set; }
        public StudentEntity Student { get; set; }

        public StudentTutorialEntity()
        {

        }

        public StudentTutorialEntity(DataAccessLogic.tblStudentTutorial studentTutorial)
        {
            this.ID = studentTutorial.ID;

            this.Student = new StudentEntity(studentTutorial.tblStudent);
            this.GradeSection = new GradeSectionEntity(studentTutorial.tblGradeSection);

            this.CreatedBy = studentTutorial.CreatedBy;
            this.CreatedDate = studentTutorial.CreatedDate;
            this.UpdatedBy = studentTutorial.UpdatedBy;
            this.UpdatedDate = studentTutorial.UpdatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblStudentTutorial studentTutorial = new DataAccessLogic.tblStudentTutorial();
            studentTutorial.ID = this.ID;

            studentTutorial.StudentID = this.Student.ID;
            studentTutorial.GradeSectionID = this.GradeSection.ID;

            studentTutorial.CreatedBy = this.CreatedBy;
            studentTutorial.CreatedDate = this.CreatedDate;
            studentTutorial.UpdatedBy = this.UpdatedBy;
            studentTutorial.UpdatedDate = this.UpdatedDate;

            return studentTutorial as T;
        }
    }
}
