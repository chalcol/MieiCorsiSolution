using MieiCorsi.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MieiCorsi.Models.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
       public String Description { get; set; }
        public string Author { get; set; }
        public float Rating { get; set; }
        public Money FullPrice { get; set; }
        public Money CurrentPrice { get; set; }
    }
}
