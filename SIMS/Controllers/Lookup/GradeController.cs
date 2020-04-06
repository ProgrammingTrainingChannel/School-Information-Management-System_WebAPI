using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class GradeController : ApiController
    {
        [HttpGet]
        [Route("api/Grade/GetGrades")]
        public List<Models.Lookup.GradeModel> GetGrades()
        {
            BusinessLogic.Lookup.GradeManager GradeManager = new BusinessLogic.Lookup.GradeManager();

            List<BusinessEntity.Lookup.GradeEntity> Grades = GradeManager.GetGrades();
            List<Models.Lookup.GradeModel> GradeModels = new List<Models.Lookup.GradeModel>();

            foreach (BusinessEntity.Lookup.GradeEntity Grade in Grades)
            {
                GradeModels.Add(new Models.Lookup.GradeModel(Grade));
            }

            return GradeModels;
        }

        [HttpGet]
        [Route("api/Grade/GetGradeByID")]
        public Models.Lookup.GradeModel GetGradeByID(int GradeID)
        {
            BusinessLogic.Lookup.GradeManager GradeManager = new BusinessLogic.Lookup.GradeManager();
            BusinessEntity.Lookup.GradeEntity Grade = GradeManager.GetGradeByID(GradeID);

            return new Models.Lookup.GradeModel(Grade);
        }

        [HttpPost]
        [Route("api/Grade/SaveGrade")]
        public BusinessEntity.Result SaveGrade(Models.Lookup.GradeModel Grade)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.GradeManager GradeManager = new BusinessLogic.Lookup.GradeManager();
                result = GradeManager.SaveGrade(Grade.MapToEntity<BusinessEntity.Lookup.GradeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Grade save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/Grade/UpdateGrade")]
        public BusinessEntity.Result UpdateGrade(Models.Lookup.GradeModel Grade)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.GradeManager GradeManager = new BusinessLogic.Lookup.GradeManager();
                result = GradeManager.UpdateGrade(Grade.MapToEntity<BusinessEntity.Lookup.GradeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Grade update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/Grade/DeleteGrade")]
        public BusinessEntity.Result DeleteGrade(Models.Lookup.GradeModel Grade)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Lookup.GradeManager GradeManager = new BusinessLogic.Lookup.GradeManager();
                result = GradeManager.DeleteGrade(Grade.MapToEntity<BusinessEntity.Lookup.GradeEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Grade delete failed.";

                return result;
            }
        }
    }
}
