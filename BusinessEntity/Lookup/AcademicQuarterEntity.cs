using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class AcademicQuarterEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public AcademicQuarterEntity()
        {

        }

        public AcademicQuarterEntity(DataAccessLogic.tblAcademicQuarter academicQuarter)
        {
            this.ID = academicQuarter.ID;
            this.Name = academicQuarter.Name;
            this.Description = academicQuarter.Description;
            this.CreatedBy = academicQuarter.CreatedBy;
            this.CreatedDate = academicQuarter.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblAcademicQuarter academicQuarter = new DataAccessLogic.tblAcademicQuarter();
            academicQuarter.ID = this.ID;
            academicQuarter.Name = this.Name;
            academicQuarter.Description = this.Description;
            academicQuarter.CreatedBy = this.CreatedBy;
            academicQuarter.CreatedDate = this.CreatedDate;

            return academicQuarter as T;
        }
    }
}
