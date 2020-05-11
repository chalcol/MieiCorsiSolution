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
               
            })
                .ToListAsync();

            return courses;
        }

        public Task<CourseDetailsViewModel> GetDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
