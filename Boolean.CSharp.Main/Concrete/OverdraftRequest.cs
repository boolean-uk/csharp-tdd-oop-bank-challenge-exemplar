﻿using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concrete
{
    public class OverdraftRequest : IOverdraftRequest
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public OverdraftStatus Status { get; set; }
        public decimal Amount { get; set; }
    } 
    
}
