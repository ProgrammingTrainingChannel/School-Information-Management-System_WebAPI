using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class RegionEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public RegionEntity()
        {

        }

        public RegionEntity(DataAccessLogic.tblRegion region)
        {
            this.ID = region.ID;
            this.Name = region.Name;
            this.Description = region.Description;
            this.CreatedBy = region.CreatedBy;
            this.CreatedDate = region.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblRegion region = new DataAccessLogic.tblRegion();
            region.ID = this.ID;
            region.Name = this.Name;
            region.Description = this.Description;
            region.CreatedBy = this.CreatedBy;
            region.CreatedDate = this.CreatedDate;

            return region as T;
        }
    }
}
