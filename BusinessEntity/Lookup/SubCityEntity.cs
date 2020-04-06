using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class SubCityEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public SubCityEntity()
        {

        }

        public SubCityEntity(DataAccessLogic.tblSubCity subCity)
        {
            this.ID = subCity.ID;
            this.Name = subCity.Name;
            this.Description = subCity.Description;
            this.CreatedBy = subCity.CreatedBy;
            this.CreatedDate = subCity.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblSubCity subCity = new DataAccessLogic.tblSubCity();
            subCity.ID = this.ID;
            subCity.Name = this.Name;
            subCity.Description = this.Description;
            subCity.CreatedBy = this.CreatedBy;
            subCity.CreatedDate = this.CreatedDate;

            return subCity as T;
        }
    }
}
