using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift_Camp_Julia.Models
{
    public class NextOfKinVisit
    {
        public int NextOfKinVisitID { get; set; }
        public int CamperID { get; set; }
        public int NextOfKinID { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
