using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormAttendance
{
    public class EmployeeAttendance
    {
        public int AttendanceLogId { get; set; }
        public System.DateTime AttendanceDate { get; set; }
        public int EmployeeId { get; set; }
        public Nullable<System.DateTime> InTime { get; set; }
        public Nullable<System.DateTime> OutTime { get; set; }
        public Nullable<double> Duration { get; set; }
    }
}
