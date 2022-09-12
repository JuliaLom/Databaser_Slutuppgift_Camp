using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Slutuppgift_Camp_Julia.Models
{
    public class Cabin
    {
        public int CabinID { get; set; }
        public string Color { get; set; }
        public virtual ICollection<CamperStay> CamperStay { get; set; }
        public virtual ICollection<CouncelorStay> CouncelorStay { get; set; }
    }
}
