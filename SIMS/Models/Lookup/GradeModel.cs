using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Lookup
{
    public class GradeModel : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public GradeModel()
        {

        }

        public GradeModel(BusinessEntity.Lookup.GradeEntity grade)
        {
            this.ID = grade.ID;
            this.Name = grade.Name;
            this.Description = grade.Description;
            this.CreatedBy = grade.CreatedBy;
            this.CreatedDate = grade.CreatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Lookup.GradeEntity grade = new BusinessEntity.Lookup.GradeEntity();
            grade.ID = this.ID;
            grade.Name = this.Name;
            grade.Description = this.Description;
            grade.CreatedBy = this.CreatedBy;
            grade.CreatedDate = this.CreatedDate;

            return grade as T;
        }
    }
}
