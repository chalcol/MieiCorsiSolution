using System;

namespace MieiCorsi.Models.ViewModels
{
    public class LessonViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public String Description { get; set; }
        public TimeSpan Duration { get; set; }

    }
}