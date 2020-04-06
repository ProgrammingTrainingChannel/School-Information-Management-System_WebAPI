using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class CampusEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string HouseNo { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public virtual RegionEntity Region { get; set; }
        public virtual SubCityEntity SubCity { get; set; }
        public virtual WoredaEntity Woreda { get; set; }

        public CampusEntity()
        {

        }

        public CampusEntity(DataAccessLogic.tblCampu campus)
        {
            this.ID = campus.ID;
            this.Name = campus.Name;
            this.PhoneNumber = campus.PhoneNumber;
            this.Email = campus.Email;
            this.HouseNo = campus.HouseNo;

            this.Region = new RegionEntity(campus.tblRegion);
            this.SubCity = new SubCityEntity(campus.tblSubCity);
            this.Woreda = new WoredaEntity(campus.tblWoreda);

            this.CreatedBy = campus.CreatedBy;
            this.CreatedDate = campus.CreatedDate;
            this.UpdatedBy = campus.UpdatedBy;
            this.UpdatedDate = campus.UpdatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblCampu campus = new DataAccessLogic.tblCampu();
            campus.ID = this.ID;
            campus.Name = this.Name;

            campus.PhoneNumber = this.PhoneNumber;
            campus.Email = this.Email;
            campus.HouseNo = this.HouseNo;

            campus.RegionID = this.Region.ID;
            campus.SubCityID = this.SubCity.ID;
            campus.WoredaID = this.Woreda.ID;

            campus.CreatedBy = this.CreatedBy;
            campus.CreatedDate = this.CreatedDate;
            campus.UpdatedBy = this.UpdatedBy;
            campus.UpdatedDate = this.UpdatedDate;

            return campus as T;
        }
    }
}
