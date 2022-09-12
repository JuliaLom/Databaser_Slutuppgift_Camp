using System;
using System.Collections.Generic;
using System.Text;

namespace Slutuppgift_Camp_Julia.Models
{
    public class CouncelorStay
    {
        public int CouncelorStayID { get; set; }
        public int CouncelorID { get; set; }
        public int CabinID { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
