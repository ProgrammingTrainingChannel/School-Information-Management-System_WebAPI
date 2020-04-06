using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class GenderEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public GenderEntity()
        {

        }

        public GenderEntity(DataAccessLogic.tblGender gender)
        {
            this.ID = gender.ID;
            this.Name = gender.Name;
            this.Description = gender.Description;
            this.CreatedBy = gender.CreatedBy;
            this.CreatedDate = gender.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblGender gender = new DataAccessLogic.tblGender();
            gender.ID = this.ID;
            gender.Name = this.Name;
            gender.Description = this.Description;
            gender.CreatedBy = this.CreatedBy;
            gender.CreatedDate = this.CreatedDate;

            return gender as T;
        }
    }
}
