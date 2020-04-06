using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class RelationshipTypeManager
    {
        public List<BusinessEntity.Lookup.RelationshipTypeEntity> GetRelationshipTypes()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblRelationshipType> results = e.tblRelationshipTypes.ToList();

            List<BusinessEntity.Lookup.RelationshipTypeEntity> entities = new List<BusinessEntity.Lookup.RelationshipTypeEntity>();
            foreach (DataAccessLogic.tblRelationshipType RelationshipType in results)
            {
                entities.Add(new BusinessEntity.Lookup.RelationshipTypeEntity(RelationshipType));
            }

            return entities;
        }

        public BusinessEntity.Lookup.RelationshipTypeEntity GetRelationshipTypeByID(int RelationshipTypeID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblRelationshipType> results = e.tblRelationshipTypes.Where(x => x.ID == RelationshipTypeID).ToList();

            List<BusinessEntity.Lookup.RelationshipTypeEntity> entities = new List<BusinessEntity.Lookup.RelationshipTypeEntity>();
            foreach (DataAccessLogic.tblRelationshipType RelationshipType in results)
            {
                entities.Add(new BusinessEntity.Lookup.RelationshipTypeEntity(RelationshipType));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveRelationshipType(BusinessEntity.Lookup.RelationshipTypeEntity RelationshipType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblRelationshipTypes.Add(RelationshipType.MapToModel<DataAccessLogic.tblRelationshipType>());
                e.SaveChanges();

                result.Message = "Saved Successfully.";
                result.Status = true;
                return result;
            }
            catch (Exception)
            {
                result.Message = "Failed to save";
                result.Status = false;
                return result;
            }
        }

        public BusinessEntity.Result UpdateRelationshipType(BusinessEntity.Lookup.RelationshipTypeEntity RelationshipType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblRelationshipTypes.Find(RelationshipType.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(RelationshipType);
                    e.SaveChanges();

                    result.Message = "Updated Successfully.";
                    result.Status = true;
                    return result;
                }
                else
                {
                    result.Message = "Failed to update";
                    result.Status = false;
                    return result;
                }
            }
            catch (Exception)
            {
                result.Message = "Failed to update";
                result.Status = false;
                return result;
            }
        }

        public BusinessEntity.Result DeleteRelationshipType(BusinessEntity.Lookup.RelationshipTypeEntity RelationshipType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblRelationshipTypes.Find(RelationshipType.ID);
                if (original != null)
                {
                    e.tblRelationshipTypes.Remove(e.tblRelationshipTypes.Where(x => x.ID == RelationshipType.ID).First());
                    e.SaveChanges();

                    result.Message = "Deleted Successfully.";
                    result.Status = true;
                    return result;
                }
                else
                {
                    result.Message = "Failed to delete";
                    result.Status = false;
                    return result;
                }
            }
            catch (Exception)
            {
                result.Message = "Failed to delete";
                result.Status = false;
                return result;
            }
        }
    }
}
