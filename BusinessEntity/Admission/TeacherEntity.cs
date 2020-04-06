using BusinessEntity.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Admission
{
    public class TeacherEntity : IBase
    {
        public int ID { get; set; }
        public string Fullname { get; set; }
        public string MotherName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FieldOfStudy { get; set; }
        public int YearOfExperience { get; set; }
        public string SkillDescription { get; set; }
        public string HouseNo { get; set; }
        public System.DateTime HiredDate { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public CampusEntity Campus { get; set; }
        public DepartmentEntity Department { get; set; }
        public GenderEntity Gender { get; set; }
        public MaritalStatusEntity MaritalStatus { get; set; }
        public RegionEntity Region { get; set; }
        public SubCityEntity SubCity { get; set; }
        public WoredaEntity Woreda { get; set; }

        public TeacherEntity()
        {

        }

        public TeacherEntity(DataAccessLogic.tblTeacher teacher)
        {
            this.ID = teacher.ID;
            this.Fullname = teacher.Fullname;
            this.MotherName = teacher.MotherName;
            this.BirthDate = teacher.BirthDate;
            this.PhoneNumber = teacher.PhoneNumber;
            this.Email = teacher.Email;
            this.FieldOfStudy = teacher.FieldOfStudy;
            this.YearOfExperience = teacher.YearOfExperience;
            this.SkillDescription = teacher.SkillDescription;
            this.HouseNo = teacher.HouseNo;
            this.HiredDate = teacher.HiredDate;
            this.Status = teacher.Status;

            this.Campus = new CampusEntity(teacher.tblCampu);
            this.Department = new DepartmentEntity(teacher.tblDepartment);
            this.Gender = new GenderEntity(teacher.tblGender);
            this.MaritalStatus = new MaritalStatusEntity(teacher.tblMaritalStatu);
            this.Region = new RegionEntity(teacher.tblRegion);
            this.SubCity = new SubCityEntity(teacher.tblSubCity);
            this.Woreda = new WoredaEntity(teacher.tblWoreda);

            this.CreatedBy = teacher.CreatedBy;
            this.CreatedDate = teacher.CreatedDate;
            this.UpdatedBy = teacher.UpdatedBy;
            this.UpdatedDate = teacher.UpdatedDate;
        }

        public T MapToModel<T>() where T : class
        {
            DataAccessLogic.tblTeacher teacher = new DataAccessLogic.tblTeacher();
            teacher.ID = this.ID;
            teacher.Fullname = this.Fullname;
            teacher.MotherName = this.MotherName;
            teacher.BirthDate = this.BirthDate;
            teacher.PhoneNumber = this.PhoneNumber;
            teacher.Email = this.Email;
            teacher.FieldOfStudy = this.FieldOfStudy;
            teacher.YearOfExperience = this.YearOfExperience;
            teacher.SkillDescription = this.SkillDescription;
            teacher.HouseNo = this.HouseNo;
            teacher.HiredDate = this.HiredDate;
            teacher.Status = this.Status;

            teacher.CampusID = this.Campus.ID;
            teacher.DepartmentID = this.Department.ID;
            teacher.GenderID = this.Gender.ID;
            teacher.MaritalStatusID = this.MaritalStatus.ID;
            teacher.RegionID = this.Region.ID;
            teacher.SubCityID = this.SubCity.ID;
            teacher.WoredaID = this.Woreda.ID;

            teacher.CreatedBy = this.CreatedBy;
            teacher.CreatedDate = this.CreatedDate;
            teacher.UpdatedBy = this.UpdatedBy;
            teacher.UpdatedDate = this.UpdatedDate;

            return teacher as T;
        }
    }
}
