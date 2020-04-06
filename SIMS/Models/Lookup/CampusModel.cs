using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Lookup
{
    public class CampusModel : IBase
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
        public RegionModel Region { get; set; }
        public SubCityModel SubCity { get; set; }
        public WoredaModel Woreda { get; set; }

        public CampusModel()
        {

        }

        public CampusModel(BusinessEntity.Lookup.CampusEntity campus)
        {
            this.ID = campus.ID;
            this.Name = campus.Name;
            this.PhoneNumber = campus.PhoneNumber;
            this.Email = campus.Email;
            this.HouseNo = campus.HouseNo;

            this.Region = new RegionModel(campus.Region);
            this.SubCity = new SubCityModel(campus.SubCity);
            this.Woreda = new WoredaModel(campus.Woreda);

            this.CreatedBy = campus.CreatedBy;
            this.CreatedDate = campus.CreatedDate;
            this.UpdatedBy = campus.UpdatedBy;
            this.UpdatedDate = campus.UpdatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Lookup.CampusEntity campus = new BusinessEntity.Lookup.CampusEntity();
            campus.ID = this.ID;
            campus.Name = this.Name;

            campus.PhoneNumber = this.PhoneNumber;
            campus.Email = this.Email;
            campus.HouseNo = this.HouseNo;

            campus.Region = this.Region.MapToEntity<BusinessEntity.Lookup.RegionEntity>();
            campus.SubCity = this.SubCity.MapToEntity<BusinessEntity.Lookup.SubCityEntity>();
            campus.Woreda = this.Woreda.MapToEntity<BusinessEntity.Lookup.WoredaEntity>();

            campus.CreatedBy = this.CreatedBy;
            campus.CreatedDate = this.CreatedDate;
            campus.UpdatedBy = this.UpdatedBy;
            campus.UpdatedDate = this.UpdatedDate;

            return campus as T;
        }
    }
}
