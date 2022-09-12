using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Slutuppgift_Camp_Julia.Models
{
    public class Councelor
    {
        public int CouncelorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<CouncelorStay> CouncelorStay { get; set; }
    }
}
