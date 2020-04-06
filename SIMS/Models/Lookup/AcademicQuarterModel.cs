using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMS.Models.Lookup
{
    public class AcademicQuarterModel : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public AcademicQuarterModel()
        {

        }

        public AcademicQuarterModel(BusinessEntity.Lookup.AcademicQuarterEntity academicQuarter)
        {
            this.ID = academicQuarter.ID;
            this.Name = academicQuarter.Name;
            this.Description = academicQuarter.Description;
            this.CreatedBy = academicQuarter.CreatedBy;
            this.CreatedDate = academicQuarter.CreatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Lookup.AcademicQuarterEntity academicQuarter = new BusinessEntity.Lookup.AcademicQuarterEntity();
            academicQuarter.ID = this.ID;
            academicQuarter.Name = this.Name;
            academicQuarter.Description = this.Description;
            academicQuarter.CreatedBy = this.CreatedBy;
            academicQuarter.CreatedDate = this.CreatedDate;

            return academicQuarter as T;
        }
    }
}