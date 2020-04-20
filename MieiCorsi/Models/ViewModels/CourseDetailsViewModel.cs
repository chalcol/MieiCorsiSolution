using MieiCorsi.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MieiCorsi.Models.ViewModels
{
    public class CourseDetailsViewModel : CourseViewModel
    {
        public string Description { get; set; }
        public List<LessonViewModel>Lessons { get; set; }

        public TimeSpan TotalCourseDuration
        {
            get => TimeSpan.FromSeconds(Lessons ?.Sum(l => l.Duration.TotalSeconds)?? 0);
        }
    }
}
