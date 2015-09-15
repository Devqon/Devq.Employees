using System;
using System.Collections.Generic;
using Devq.Employees.Models;

namespace Devq.Employees.ViewModels
{
    public class ScheduleIndexViewModel
    {
        public int Year { get; set; }
        public int Week { get; set; }
        public int DepartmentId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int EmployeeId { get; set; }
        public IEnumerable<WorkDayPart> WorkDays { get; set; } 
    }
}