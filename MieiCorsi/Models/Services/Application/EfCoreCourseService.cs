using Microsoft.EntityFrameworkCore;
using MieiCorsi.Models.Entities;
using MieiCorsi.Models.Services.Infrastructure;
using MieiCorsi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MieiCorsi.Models.Services.Application
{
    public class EfCoreCourseService : ICourseService
    {
        private readonly MieiCorsiDbContext dbContext;

        public EfCoreCourseService(MieiCorsiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<CourseViewModel>> GetCoursesAsync()
        {
            List<CourseViewModel> courses = await dbContext.Corsi.Select(corso =>
            new CourseViewModel
            {
                Id = corso.Id,
                Title = corso.Title,
                ImagePath = corso.ImagePath,
                Author = corso.Author,
                Rating = corso.Rating,
                CurrentPrice = corso.CurrentPrice,
                FullPrice = corso.FullPrice
               
               
               
            }).AsNoTracking()
                .ToListAsync();

            return courses;
        }

        public async Task<CourseDetailsViewModel> GetDetailsAsync(int id)
        {
            CourseDetailsViewModel corsoDetails = await dbContext.Corsi.Where(corso => corso.Id == id)
                  .Select(corso =>
                   new CourseDetailsViewModel
                   {
                       Id = corso.Id,
                       Title = corso.Title,
                       Description = corso.Description,
                       ImagePath = corso.ImagePath,
                       Author = corso.Author,
                       Rating = corso.Rating,
                       CurrentPrice = corso.CurrentPrice,
                       FullPrice = corso.FullPrice,
                       Lessons = corso.Lessons.Select(lesson =>
                       new LessonViewModel
                       {
                           Id = lesson.Id,
                           Title = lesson.Title,
                           Description = lesson.Description,
                           Duration = lesson.Duration
                       }).ToList()
                   }).AsNoTracking()
                .SingleAsync();//Restituisce il primo elemento dell'elenco ma solleva un'eccezione se l'elenco è vuoto o ha più di un elemento univoco.

            return corsoDetails;
        }
    }
}
