using System;

namespace api101.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credit { get; set; }
        public DateTime InsertedDate { get; set; }
    }
}
