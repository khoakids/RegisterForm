using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Web.Models;
using Microsoft.AspNetCore.Http;

namespace Web.ViewModels
{
    public class HomeCreateViewModel
    {
        [Required(ErrorMessage = "Phải nhập Họ Tên")]
        [MaxLength(20, ErrorMessage = "Không thể vượt quá 20 ký tự")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Phải Nhập Email")]
        [Display(Name = "Office Email")]
        [RegularExpression(@"^[a-z][a-z0-9_\.]{5,32}@[a-z0-9]{2,}(\.[a-z0-9]{2,4}){1,2}$", ErrorMessage = "Phải nhập đúng định dạng Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phải nhập chức vụ")]
        public Department? Department { get; set; }
        public IFormFile Avatar { get; set; }

    }
}
