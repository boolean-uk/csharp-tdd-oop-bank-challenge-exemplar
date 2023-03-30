using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concrete
{
    public class OverdraftRequest
    {
        public int Id { get; internal set; }
        public DateTime RequestDate { get; set; }
        public OverdraftStatus Status { get; set; }
        public decimal Amount { get; set; }
    } 
    
}
