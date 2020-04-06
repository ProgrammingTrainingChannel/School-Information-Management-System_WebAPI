using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Lookup
{
    public class WoredaModel : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public WoredaModel()
        {

        }

        public WoredaModel(BusinessEntity.Lookup.WoredaEntity woreda)
        {
            this.ID = woreda.ID;
            this.Name = woreda.Name;
            this.Description = woreda.Description;
            this.CreatedBy = woreda.CreatedBy;
            this.CreatedDate = woreda.CreatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Lookup.WoredaEntity woreda = new BusinessEntity.Lookup.WoredaEntity();
            woreda.ID = this.ID;
            woreda.Name = this.Name;
            woreda.Description = this.Description;
            woreda.CreatedBy = this.CreatedBy;
            woreda.CreatedDate = this.CreatedDate;

            return woreda as T;
        }
    }
}
