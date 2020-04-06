using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class GradeSectionController : ApiController
    {
        [HttpGet]
        [Route("api/GradeSection/GetGradeSections")]
        public List<Models.Lookup.GradeSectionModel> GetGradeSections()
        {
            BusinessLogic.Lookup.GradeSectionManager GradeSectionManager = new BusinessLogic.Lookup.GradeSectionManager();

            List<BusinessEntity.Lookup.GradeSectionEntity> GradeSections = GradeSectionManager.GetGradeSections();
            List<Models.Lookup.GradeSectionModel> GradeSectionModels = new List<Models.Lookup.GradeSectionModel>();

            foreach (BusinessEntity.Lookup.GradeSectionEntity GradeSection in GradeSections)
            {
                GradeSectionModels.Add(new Models.Lookup.GradeSectionModel(GradeSection));
            }

            return GradeSectionModels;
        }

        [HttpGet]
        [Route("api/GradeSection/GetGradeSectionByID")]
        public Models.Lookup.GradeSectionModel GetGradeSectionByID(int GradeSectionID)
        {
            BusinessLogic.Lookup.GradeSectionManager GradeSectionManager = new BusinessLogic.Lookup.GradeSectionManager();
            BusinessEntity.Lookup.GradeSectionEntity GradeSection = GradeSectionManager.GetGradeSectionByID(GradeSectionID);

            return new Models.Lookup.GradeSectionModel(GradeSection);
        }

        [HttpPost]
        [Route("api/GradeSection/SaveGradeSection")]
        public BusinessEntity.Result SaveGradeSection(Models.Lookup.GradeSectionModel GradeSection)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.GradeSectionManager GradeSectionManager = new BusinessLogic.Lookup.GradeSectionManager();
                result = GradeSectionManager.SaveGradeSection(GradeSection.MapToEntity<BusinessEntity.Lookup.GradeSectionEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "GradeSection save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/GradeSection/UpdateGradeSection")]
        public BusinessEntity.Result UpdateGradeSection(Models.Lookup.GradeSectionModel GradeSection)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.GradeSectionManager GradeSectionManager = new BusinessLogic.Lookup.GradeSectionManager();
                result = GradeSectionManager.UpdateGradeSection(GradeSection.MapToEntity<BusinessEntity.Lookup.GradeSectionEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "GradeSection update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/GradeSection/DeleteGradeSection")]
        public BusinessEntity.Result DeleteGradeSection(Models.Lookup.GradeSectionModel GradeSection)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.GradeSectionManager GradeSectionManager = new BusinessLogic.Lookup.GradeSectionManager();
                result = GradeSectionManager.DeleteGradeSection(GradeSection.MapToEntity<BusinessEntity.Lookup.GradeSectionEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "GradeSection delete failed.";

                return result;
            }
        }
    }
}
