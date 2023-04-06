using Boolean.CSharp.Main.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Boolean.CSharp.Main.Concrete
{
    public class TwilioSMSProvider : ISmsSender
    {
        
        public TwilioSMSProvider()
        {
        }

        public void SendSMS(string smsMessage)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string accountSid = appSettings["TWILIO_ACCOUNT_SID"];
            string authToken = appSettings["TWILIO_AUTH_TOKEN"];

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: smsMessage,
                from: new Twilio.Types.PhoneNumber("+447700168226"),
                to: new Twilio.Types.PhoneNumber("+447811579411")
            );

            Console.WriteLine(message.Sid);
        }
    }
}
