using BusinessEntity.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Admission
{
    public class StudentEntity : IBase
    {
        public int ID { get; set; }
        public string Fullname { get; set; }
        public string MotherName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string HouseNo { get; set; }
        public bool IsSponsored { get; set; }
        public bool IsHandicaped { get; set; }
        public int AdmissionYear { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public CampusEntity Campus { get; set; }
        public GenderEntity Gender { get; set; }
        public GradeSectionEntity GradeSection { get; set; }
        public RegionEntity Region { get; set; }
        public SubCityEntity SubCity { get; set; }
        public WoredaEntity Woreda { get; set; }

        public StudentEntity()
        {

        }

        public StudentEntity(DataAccessLogic.tblStudent student)
        {
            this.ID = student.ID;
            this.Fullname = student.Fullname;
            this.MotherName = student.MotherName;
            this.BirthDate = student.BirthDate;
            this.HouseNo = student.HouseNo;
            this.IsSponsored = student.IsSponsored;
            this.IsHandicaped = student.IsHandicaped;
            this.AdmissionYear = student.AdmissionYear;

            this.Campus = new CampusEntity(student.tblCampu);
            this.Gender = new GenderEntity(student.tblGender);
            this.GradeSection = new GradeSectionEntity(student.tblGradeSection);
            this.Region = new RegionEntity(student.tblRegion);
            this.SubCity = new SubCityEntity(student.tblSubCity);
            this.Woreda = new WoredaEntity(student.tblWoreda);

            this.CreatedBy = student.CreatedBy;
            this.CreatedDate = student.CreatedDate;
            this.UpdatedBy = student.UpdatedBy;
            this.UpdatedDate = student.UpdatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblStudent student = new DataAccessLogic.tblStudent();
            student.ID = this.ID;
            student.Fullname = this.Fullname;
            student.MotherName = this.MotherName;
            student.BirthDate = this.BirthDate;
            student.HouseNo = this.HouseNo;
            student.IsSponsored = this.IsSponsored;
            student.IsHandicaped = this.IsHandicaped;
            student.AdmissionYear = this.AdmissionYear;

            student.CampusID = this.Campus.ID;
            student.GenderID = this.Gender.ID;
            student.GradeSectionID = this.GradeSection.ID;
            student.RegionID = this.Region.ID;
            student.SubCityID = this.SubCity.ID;
            student.WoredaID = this.Woreda.ID;

            student.CreatedBy = this.CreatedBy;
            student.CreatedDate = this.CreatedDate;
            student.UpdatedBy = this.UpdatedBy;
            student.UpdatedDate = this.UpdatedDate;

            return student as T;
        }
    }
}
