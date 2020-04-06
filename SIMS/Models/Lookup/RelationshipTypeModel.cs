using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Models.Lookup
{
    public class RelationshipTypeModel : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public RelationshipTypeModel()
        {

        }

        public RelationshipTypeModel(BusinessEntity.Lookup.RelationshipTypeEntity relationshipType)
        {
            this.ID = relationshipType.ID;
            this.Name = relationshipType.Name;
            this.Description = relationshipType.Description;
            this.CreatedBy = relationshipType.CreatedBy;
            this.CreatedDate = relationshipType.CreatedDate;
        }

        public T MapToEntity<T>() where T : class
        {
            BusinessEntity.Lookup.RelationshipTypeEntity relationshipType = new BusinessEntity.Lookup.RelationshipTypeEntity();
            relationshipType.ID = this.ID;
            relationshipType.Name = this.Name;
            relationshipType.Description = this.Description;
            relationshipType.CreatedBy = this.CreatedBy;
            relationshipType.CreatedDate = this.CreatedDate;

            return relationshipType as T;
        }
    }
}
