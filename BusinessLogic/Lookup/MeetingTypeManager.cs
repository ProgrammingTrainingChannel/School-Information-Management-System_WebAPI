using DataAccessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Lookup
{
    public class MeetingTypeManager
    {
        public List<BusinessEntity.Lookup.MeetingTypeEntity> GetMeetingTypes()
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblMeetingType> results = e.tblMeetingTypes.ToList();

            List<BusinessEntity.Lookup.MeetingTypeEntity> entities = new List<BusinessEntity.Lookup.MeetingTypeEntity>();
            foreach (DataAccessLogic.tblMeetingType MeetingType in results)
            {
                entities.Add(new BusinessEntity.Lookup.MeetingTypeEntity(MeetingType));
            }

            return entities;
        }

        public BusinessEntity.Lookup.MeetingTypeEntity GetMeetingTypeByID(int MeetingTypeID)
        {
            SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
            List<DataAccessLogic.tblMeetingType> results = e.tblMeetingTypes.Where(x => x.ID == MeetingTypeID).ToList();

            List<BusinessEntity.Lookup.MeetingTypeEntity> entities = new List<BusinessEntity.Lookup.MeetingTypeEntity>();
            foreach (DataAccessLogic.tblMeetingType MeetingType in results)
            {
                entities.Add(new BusinessEntity.Lookup.MeetingTypeEntity(MeetingType));
            }

            return entities.FirstOrDefault();
        }

        public BusinessEntity.Result SaveMeetingType(BusinessEntity.Lookup.MeetingTypeEntity MeetingType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                e.tblMeetingTypes.Add(MeetingType.MapToModel<DataAccessLogic.tblMeetingType>());
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

        public BusinessEntity.Result UpdateMeetingType(BusinessEntity.Lookup.MeetingTypeEntity MeetingType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblMeetingTypes.Find(MeetingType.ID);
                if (original != null)
                {
                    e.Entry(original).CurrentValues.SetValues(MeetingType);
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

        public BusinessEntity.Result DeleteMeetingType(BusinessEntity.Lookup.MeetingTypeEntity MeetingType)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                SchoolInformationManagementSystemDBEntities e = new SchoolInformationManagementSystemDBEntities();
                var original = e.tblMeetingTypes.Find(MeetingType.ID);
                if (original != null)
                {
                    e.tblMeetingTypes.Remove(e.tblMeetingTypes.Where(x => x.ID == MeetingType.ID).First());
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
