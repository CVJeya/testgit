using System;
using System.ComponentModel.DataAnnotations;

namespace UnitTestApi.Data
{
    public class TaskInfo
    {
        [Key]
        public int Id { get; set; }
        public string TaskName { get; set; }

        public int HoursNeeded { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}