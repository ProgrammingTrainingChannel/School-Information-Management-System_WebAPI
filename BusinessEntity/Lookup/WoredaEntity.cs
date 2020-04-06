using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class WoredaEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public WoredaEntity()
        {

        }

        public WoredaEntity(DataAccessLogic.tblWoreda woreda)
        {
            this.ID = woreda.ID;
            this.Name = woreda.Name;
            this.Description = woreda.Description;
            this.CreatedBy = woreda.CreatedBy;
            this.CreatedDate = woreda.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblWoreda woreda = new DataAccessLogic.tblWoreda();
            woreda.ID = this.ID;
            woreda.Name = this.Name;
            woreda.Description = this.Description;
            woreda.CreatedBy = this.CreatedBy;
            woreda.CreatedDate = this.CreatedDate;

            return woreda as T;
        }
    }
}
