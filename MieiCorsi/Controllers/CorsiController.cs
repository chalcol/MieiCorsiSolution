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
        private readonly ICourseService courseService;

        public CorsiController(ICourseService courseService) 
            // In questo modo possiamo  creare l'istanza della classe CourseService senza la "NEW" 
            //: Questo meccanismo viene chiamato la DEPENDENCY INJECTION 
            //(il problema a questo punto è che il "CourseController" non può funzionare al meno  che no ci fornisca un istanza proprio di "CourseService" )
        {                                                    
            this.courseService = courseService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            ViewData["Title"] = "Catalogo dei corsi";
           // var courseService = new CourseService();// Istanza della classe CourseService
            List<CourseViewModel> courses = await courseService.GetCoursesAsync();
           
            //lista di corsi restituita dall'istanza della classe CourseService.
            return View(courses);
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
           // var courseDetailsService = new CourseService();
            CourseDetailsViewModel courseDetails = await courseService.GetDetailsAsync(id);
            ViewData["Title"] = courseDetails.Title;
            return View(courseDetails);
        }

        //Func<DateTime, bool> CanDrive =
        //    dob => dob.AddYears(18) <= DateTime.Today;

        ////lamda function con una sola istruzione nel corpo della funzione.

        //Func<DateTime, bool> CanDriv = (dob) =>
        // {
        //     bool value = dob.AddYears(18) <= DateTime.Today;
        //     return value;
        // };
        //// lamda function con più istruzioni nel corpo della funzione
    }
}