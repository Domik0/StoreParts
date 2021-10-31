using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreParts.Class
{
    public class PartCount
    {
        public Part part { get; set; }
        public int count { get; set; }

        public PartCount(Part part, int count)
        {
            this.part = part;
            this.count = count;
        }
    }
}
