using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concrete
{
    public  class SmsSender : ISmsSender
    {
        ISmsSender _smsProvider;


        public SmsSender(ISmsSender smsProvider)
        {
            _smsProvider = smsProvider;
        }

        
        public void SendSMS(string speech)
        {
            _smsProvider.SendSMS(speech);
        }
    }
}
