using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnderstandConneg.Model
{
    public class TalentScout
    {
        public IList<string> Departments { get; set; }
        public bool IsCtcBased { get; set; }
        public DateTime Doj { get; set; }
    }
}