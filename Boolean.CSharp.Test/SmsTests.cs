using Boolean.CSharp.Main.Concrete;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class SmsTests
    {
        [TestCase("hello!")]
        public void SmsTest(string message)
        {
            ISmsSender sender = new TwilioSMSProvider();
            sender.SendSMS(message);

        }
    }
}
