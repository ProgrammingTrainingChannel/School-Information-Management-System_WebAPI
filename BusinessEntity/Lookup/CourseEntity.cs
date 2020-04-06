using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class CourseEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public CourseEntity()
        {

        }

        public CourseEntity(DataAccessLogic.tblCourse course)
        {
            this.ID = course.ID;
            this.Name = course.Name;
            this.Description = course.Description;
            this.CreatedBy = course.CreatedBy;
            this.CreatedDate = course.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblCourse course = new DataAccessLogic.tblCourse();
            course.ID = this.ID;
            course.Name = this.Name;
            course.Description = this.Description;
            course.CreatedBy = this.CreatedBy;
            course.CreatedDate = this.CreatedDate;

            return course as T;
        }
    }
}
