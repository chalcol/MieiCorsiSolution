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
        private readonly CourseService courseService;

        public CorsiController(CourseService courseService) // In questo modo possiamo  creare l'istanza della classe CourseService senza la "NEW" 
            //: Questo meccanismo viene chiamato la DEPENDENCY INJECTION 
            //(il problema a questo punto è che il "CourseController" non può funzionare al meno  che no ci fornisca un istanza proprio di "CourseService" )
        {                                                    
            this.courseService = courseService;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Catalogo dei corsi";
           // var courseService = new CourseService();// Istanza della classe CourseService
            List<CourseViewModel> courses = courseService.GetCourses();//lista di corsi restituita dall'istanza della classe CourseService.
            return View(courses);
        }

        public IActionResult Details(int id)
        {
           // var courseDetailsService = new CourseService();
            CourseDetailsViewModel courseDetails = courseService.GetDetails(id);
            ViewData["Title"] = courseDetails.Title;
            return View(courseDetails);
        }
    }
}