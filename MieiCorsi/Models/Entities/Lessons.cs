using System;
using System.Collections.Generic;

namespace MieiCorsi.Models.Entities
{
    public partial class Lessons
    {
        public int Id { get; set; }
        public int CorsiId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }

        public virtual Corsi Corsi { get; set; }
    }
}
