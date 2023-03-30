using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concrete
{
    public abstract class Account
    {
        public Guid Id { get; set; }

        public Account()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
