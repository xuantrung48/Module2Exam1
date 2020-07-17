using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Student
    {
        [Required]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Nhập vào tên học viên!")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Nhập vào Email!")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Chọn giới tính học viên!")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Chọn ngày sinh của học viên!")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Chọn lớp học viên!")]
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
