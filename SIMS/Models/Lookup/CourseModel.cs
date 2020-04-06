using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Lookup
{
    public class CourseModel : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public CourseModel()
        {

        }

        public CourseModel(BusinessEntity.Lookup.CourseEntity course)
        {
            this.ID = course.ID;
            this.Name = course.Name;
            this.Description = course.Description;
            this.CreatedBy = course.CreatedBy;
            this.CreatedDate = course.CreatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Lookup.CourseEntity course = new BusinessEntity.Lookup.CourseEntity();
            course.ID = this.ID;
            course.Name = this.Name;
            course.Description = this.Description;
            course.CreatedBy = this.CreatedBy;
            course.CreatedDate = this.CreatedDate;

            return course as T;
        }
    }
}
