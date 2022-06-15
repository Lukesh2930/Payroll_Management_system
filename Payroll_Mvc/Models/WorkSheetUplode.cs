using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll_Mvc.Models
{
    public class WorkSheetUplode
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public IEnumerable<WorkSheetUplode> FileList { get; set; }
    }
}