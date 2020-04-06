using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMS.Models.Lookup
{
    public class RegionModel : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public RegionModel()
        {

        }

        public RegionModel(BusinessEntity.Lookup.RegionEntity region)
        {
            this.ID = region.ID;
            this.Name = region.Name;
            this.Description = region.Description;
            this.CreatedBy = region.CreatedBy;
            this.CreatedDate = region.CreatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Lookup.RegionEntity region = new BusinessEntity.Lookup.RegionEntity();
            region.ID = this.ID;
            region.Name = this.Name;
            region.Description = this.Description;
            region.CreatedBy = this.CreatedBy;
            region.CreatedDate = this.CreatedDate;

            return region as T;
        }
    }
}