using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace timesheet.model
{
    public class TimeDetails
    {
        [Key]
        public int Id { get; set; }

        public int empId { get; set; }
        [ForeignKey("Code")]
        public Employee Employee { get; set; }

        public int TaskName { get; set; }
        [ForeignKey("Name")]
        public Task Task { get; set; }

        public int Sunday { get; set; }
        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }
        public int Saturday { get; set; }
    }
}
