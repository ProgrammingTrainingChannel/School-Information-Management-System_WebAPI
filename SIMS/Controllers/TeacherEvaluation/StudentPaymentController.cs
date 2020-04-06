using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SIMS.Controllers.StudentPayment
{
    public class StudentPaymentController : ApiController
    {
        [HttpGet]
        [Route("api/StudentPayment/GetStudentPayments")]
        public List<Models.TeacherEvaluation.StudentPaymentModel> GetStudentPayments()
        {
            BusinessLogic.StudentPayment.StudentPaymentManager StudentPaymentManager = new BusinessLogic.StudentPayment.StudentPaymentManager();

            List<BusinessEntity.TeacherEvaluation.StudentPaymentEntity> StudentPayments = StudentPaymentManager.GetStudentPayments();
            List<Models.TeacherEvaluation.StudentPaymentModel> StudentPaymentModels = new List<Models.TeacherEvaluation.StudentPaymentModel>();

            foreach (BusinessEntity.TeacherEvaluation.StudentPaymentEntity StudentPayment in StudentPayments)
            {
                StudentPaymentModels.Add(new Models.TeacherEvaluation.StudentPaymentModel(StudentPayment));
            }

            return StudentPaymentModels;
        }

        [HttpGet]
        [Route("api/StudentPayment/GetStudentPaymentByID")]
        public Models.TeacherEvaluation.StudentPaymentModel GetStudentPaymentByID(int StudentPaymentID)
        {
            BusinessLogic.StudentPayment.StudentPaymentManager StudentPaymentManager = new BusinessLogic.StudentPayment.StudentPaymentManager();
            BusinessEntity.TeacherEvaluation.StudentPaymentEntity StudentPayment = StudentPaymentManager.GetStudentPaymentByID(StudentPaymentID);

            return new Models.TeacherEvaluation.StudentPaymentModel(StudentPayment);
        }

        [HttpPost]
        [Route("api/StudentPayment/SaveStudentPayment")]
        public BusinessEntity.Result SaveStudentPayment(Models.TeacherEvaluation.StudentPaymentModel StudentPayment)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.StudentPayment.StudentPaymentManager StudentPaymentManager = new BusinessLogic.StudentPayment.StudentPaymentManager();
                result = StudentPaymentManager.SaveStudentPayment(StudentPayment.MapToEntity<BusinessEntity.TeacherEvaluation.StudentPaymentEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "StudentPayment save failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/StudentPayment/UpdateStudentPayment")]
        public BusinessEntity.Result UpdateStudentPayment(Models.TeacherEvaluation.StudentPaymentModel StudentPayment)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.StudentPayment.StudentPaymentManager StudentPaymentManager = new BusinessLogic.StudentPayment.StudentPaymentManager();
                result = StudentPaymentManager.UpdateStudentPayment(StudentPayment.MapToEntity<BusinessEntity.TeacherEvaluation.StudentPaymentEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "StudentPayment update failed.";

                return result;
            }
        }

        [HttpPost]
        [Route("api/StudentPayment/DeleteStudentPayment")]
        public BusinessEntity.Result DeleteStudentPayment(Models.TeacherEvaluation.StudentPaymentModel StudentPayment)
        {
            BusinessEntity.Result result = new BusinessEntity.Result();
            try
            {
                BusinessLogic.StudentPayment.StudentPaymentManager StudentPaymentManager = new BusinessLogic.StudentPayment.StudentPaymentManager();
                result = StudentPaymentManager.DeleteStudentPayment(StudentPayment.MapToEntity<BusinessEntity.TeacherEvaluation.StudentPaymentEntity>());

                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "StudentPayment delete failed.";

                return result;
            }
        }
    }
}
