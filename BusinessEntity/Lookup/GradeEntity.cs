using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class GradeEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public GradeEntity()
        {

        }

        public GradeEntity(DataAccessLogic.tblGrade grade)
        {
            this.ID = grade.ID;
            this.Name = grade.Name;
            this.Description = grade.Description;
            this.CreatedBy = grade.CreatedBy;
            this.CreatedDate = grade.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblGrade grade = new DataAccessLogic.tblGrade();
            grade.ID = this.ID;
            grade.Name = this.Name;
            grade.Description = this.Description;
            grade.CreatedBy = this.CreatedBy;
            grade.CreatedDate = this.CreatedDate;

            return grade as T;
        }
    }
}
