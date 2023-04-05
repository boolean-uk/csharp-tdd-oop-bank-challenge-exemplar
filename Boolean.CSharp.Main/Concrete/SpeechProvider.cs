using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concrete
{
    public  class SpeechProvider : ISpeak
    {
        SpeechSynthesizer speaker;


        public SpeechProvider()
        {
            speaker = new SpeechSynthesizer(); //TODO:  find a solution for this
        }

        
        public void Speak(string speech)
        {
            speaker.Speak(speech);
        }
    }
}
