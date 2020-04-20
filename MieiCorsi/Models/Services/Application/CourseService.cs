using MieiCorsi.Models.Enums;
using MieiCorsi.Models.ValueTypes;
using MieiCorsi.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace MieiCorsi.Models.Services.Application
{
    public class CourseService
    {
        
        public List<CourseViewModel> GetCourses()
        {
            var courseList = new List<CourseViewModel>(); // lista di corsi da passare al controller
            var rand = new Random();

            for (var i = 1; i <= 20; ++i)
            {
                var price = Convert.ToDecimal(rand.NextDouble() * 10 + 10);
               var course = new CourseViewModel

                {
                    Id = i,
                    Title = $"Corso{i}",
                    CurrentPrice = new Money(Currency.EUR,price),
                    FullPrice = new Money(Currency.EUR,rand.NextDouble()>0.5?price:price-1),
                    Author = "Nome Cognome",
                    Rating = rand.NextDouble()*5.0,
                    ImagePath = "~/logo.svg"
                };
                courseList.Add(course);
            }
            return courseList;
        }

        public CourseDetailsViewModel GetDetails(int id)
        {
            var rand = new Random();
            var price = Convert.ToDecimal(rand.NextDouble() * 10 + 10);
            var courseDetails = new CourseDetailsViewModel
            {
                Id = id,
                Title = $"Corso{id}",
                CurrentPrice = new Money(Currency.EUR, price),
                FullPrice = new Money(Currency.EUR, rand.NextDouble() > 0.5 ? price : price - 1),
                Author = "Nome Cognome",
                Rating = rand.NextDouble() * 5.0,
                Description = $"Description{id}",
                ImagePath = "~/logo.svg",
                Lessons = new List<LessonViewModel>()
            };
            for (var i = 1; i <= 5; ++i)
            {
                var lesson = new LessonViewModel
                {
                    Title = $"Lesson{i}",
                    Duration = TimeSpan.FromSeconds(rand.Next(40, 90))
                };
                courseDetails.Lessons.Add(lesson);
            }
            return courseDetails;
        }
    }
}
