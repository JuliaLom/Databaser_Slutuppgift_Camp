using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Slutuppgift_Camp_Julia.Models
{
    public class Camper
    {
        public int CamperID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<CamperStay> CamperStay { get; set; }
        public virtual ICollection<NextOfKinVisit> NextOfKinVisit {get; set; }

    }
}
