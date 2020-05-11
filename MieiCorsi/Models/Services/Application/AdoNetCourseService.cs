using MieiCorsi.Models.Services.Infrastructure;
using MieiCorsi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MieiCorsi.Models.Services.Application
{
    public class AdoNetCourseService : ICourseService
    {
        private readonly IDatabaseAccessor db;

        public AdoNetCourseService(IDatabaseAccessor db)
        {
            this.db = db;
        }
        public async Task<List<CourseViewModel>> GetCoursesAsync()
        {
            String query = "SELECT * FROM Corsi";
            DataSet dataSet = db.Query(query);
            throw new NotImplementedException();
        }

        public Task <CourseDetailsViewModel> GetDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
