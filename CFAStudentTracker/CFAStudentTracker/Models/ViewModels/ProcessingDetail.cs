using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CFAStudentTracker.Models
{
    public class ProcessingDetail
    {
        public Processing Proc { get; set; }
        public Record Rec { get; set; }
        public StudentFile StudFile { get; set; }
        public List<Note> Notes { get; set; }
        public Queue Queue { get; set; }
    }
}