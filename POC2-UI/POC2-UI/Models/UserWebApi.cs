namespace POC2_UI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserWebApiEntity
    {
        public Guid Id { get; set; }

        public int? MemberShipUserID { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(150)]
        public string EmpName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public bool IsActive { get; set; }

        public bool IsContractor { get; set; }

        public Guid? RoleID { get; set; }

        public string ProfilePhotoID { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? LastLoginDate { get; set; }
    }
}