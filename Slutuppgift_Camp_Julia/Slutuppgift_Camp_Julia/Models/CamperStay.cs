using System;
using System.Collections.Generic;
using System.Text;

namespace Slutuppgift_Camp_Julia.Models
{
    public class CamperStay
    {
        public int CamperStayID { get; set; }
        public int CamperID { get; set; }
        public int CabinID { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        
    }
}
