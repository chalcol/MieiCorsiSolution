using MieiCorsi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MieiCorsi.Models.Services.Application
{
   public interface ICourseService
    {
        List<CourseViewModel> GetCourses();
        CourseDetailsViewModel GetDetails(int id);
    }
}
