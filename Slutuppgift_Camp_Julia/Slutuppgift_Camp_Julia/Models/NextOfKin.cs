using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Slutuppgift_Camp_Julia.Models
{
    public class NextOfKin
    {
        public int NextOfKinID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<NextOfKinVisit> NextOfKinVisit { get; set; }
    }
}
