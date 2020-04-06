using BusinessEntity.Admission;
using BusinessEntity.Lookup;
using SIMS.Models.Admission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Lookup
{
    public class GradeSectionModel : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public GradeModel Grade { get; set; }
        public TeacherModel RoomTeacher { get; set; }

        public GradeSectionModel()
        {

        }

        public GradeSectionModel(BusinessEntity.Lookup.GradeSectionEntity gradeSection)
        {
            this.ID = gradeSection.ID;
            this.Name = gradeSection.Name;

            this.Grade = new GradeModel(gradeSection.Grade);
            this.RoomTeacher = new TeacherModel(gradeSection.RoomTeacher);

            this.CreatedBy = gradeSection.CreatedBy;
            this.CreatedDate = gradeSection.CreatedDate;
            this.UpdatedBy = gradeSection.UpdatedBy;
            this.UpdatedDate = gradeSection.UpdatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Lookup.GradeSectionEntity gradeSection = new BusinessEntity.Lookup.GradeSectionEntity();
            gradeSection.ID = this.ID;
            gradeSection.Name = this.Name;

            gradeSection.Grade = this.Grade.MapToEntity<BusinessEntity.Lookup.GradeEntity>();
            gradeSection.RoomTeacher = this.RoomTeacher.MapToEntity<BusinessEntity.Admission.TeacherEntity>();

            gradeSection.CreatedBy = this.CreatedBy;
            gradeSection.CreatedDate = this.CreatedDate;

            return gradeSection as T;
        }
    }
}
