using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class le_leaveApplication
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string LeaveType { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
        public DateTime LeaveFrom { get; set; }
        public DateTime LeaveTo { get; set; }
        public int? LeaveDurationDays { get; set; }
        public DateTime DateApplied { get; set; }
        public string ApplicationStatus { get; set; }
    }
}