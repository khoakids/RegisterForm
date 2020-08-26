using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{StatusCode}")]
         public ViewResult PageNotFound(int StatusCode)
        {
            ViewBag.ErrorMessage = $"Lỗi {StatusCode}: Tài nguyên không được tìm thấy!";
            return View();
        }
        [Route("Error")]
        public ViewResult Error()
        {
            return View("Exception");
        }
    }
}
