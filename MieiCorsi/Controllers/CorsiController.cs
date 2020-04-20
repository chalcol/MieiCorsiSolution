using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MieiCorsi.Models.Services.Application;
using MieiCorsi.Models.ViewModels;

namespace MieiCorsi.Controllers
{
    public class CorsiController : Controller
    {
        public IActionResult Index()
        {
            var courseService = new CourseService();// Istanza della classe CourseService
            List<CourseViewModel> courses = courseService.GetCourses();//lista di corsi restituita dall'istanza della classe CourseService.
            return View(courses);
        }

        public IActionResult Details(int id)
        {

            var courseDetailsService = new CourseService();
            CourseDetailsViewModel courseDetails = courseDetailsService.GetDetails(id);
            return View(courseDetails);
        }
    }
}