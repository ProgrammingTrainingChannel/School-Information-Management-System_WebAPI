using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Lookup
{
    public class ExamTypeEntity : IBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public ExamTypeEntity()
        {

        }

        public ExamTypeEntity(DataAccessLogic.tblExamType examType)
        {
            this.ID = examType.ID;
            this.Name = examType.Name;
            this.Description = examType.Description;
            this.CreatedBy = examType.CreatedBy;
            this.CreatedDate = examType.CreatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblExamType examType = new DataAccessLogic.tblExamType();
            examType.ID = this.ID;
            examType.Name = this.Name;
            examType.Description = this.Description;
            examType.CreatedBy = this.CreatedBy;
            examType.CreatedDate = this.CreatedDate;

            return examType as T;
        }
    }
}
