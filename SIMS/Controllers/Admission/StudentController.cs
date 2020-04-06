using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.Lookup
{
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("api/Student/GetStudents")]
        public List<Models.Admission.StudentModel> GetStudents()
        {
            BusinessLogic.Admission.StudentManager StudentManager = new BusinessLogic.Admission.StudentManager();

            List<BusinessEntity.Admission.StudentEntity> Students = StudentManager.GetStudents();
            List<Models.Admission.StudentModel> StudentModels = new List<Models.Admission.StudentModel>();

            foreach (BusinessEntity.Admission.StudentEntity Student in Students)
            {
                StudentModels.Add(new Models.Admission.StudentModel(Student));
            }

            return StudentModels;
        }

        [HttpGet]
        [Route("api/Student/GetStudentByID")]
        public Models.Admission.StudentModel GetStudentByID(int StudentID)
        {
            BusinessLogic.Admission.StudentManager StudentManager = new BusinessLogic.Admission.StudentManager();
            BusinessEntity.Admission.StudentEntity Student = StudentManager.GetStudentByID(StudentID);

            return new Models.Admission.StudentModel(Student);
        }

        [HttpPost]
        [Route("api/Student/SaveStudent")]
        public BusinessEntity.Result SaveStudent(Models.Admission.StudentModel Student)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Admission.StudentManager StudentManager = new BusinessLogic.Admission.StudentManager();
                result = StudentManager.SaveStudent(Student.MapToEntity<BusinessEntity.Admission.StudentEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Student save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/Student/UpdateStudent")]
        public BusinessEntity.Result UpdateStudent(Models.Admission.StudentModel Student)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Admission.StudentManager StudentManager = new BusinessLogic.Admission.StudentManager();
                result = StudentManager.UpdateStudent(Student.MapToEntity<BusinessEntity.Admission.StudentEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Student update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/Student/DeleteStudent")]
        public BusinessEntity.Result DeleteStudent(Models.Admission.StudentModel Student)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.Admission.StudentManager StudentManager = new BusinessLogic.Admission.StudentManager();
                result = StudentManager.DeleteStudent(Student.MapToEntity<BusinessEntity.Admission.StudentEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "Student delete failed.";

                return result;
            }
        }
    }
}
