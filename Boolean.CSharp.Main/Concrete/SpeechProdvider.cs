using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concrete
{
    public  class SpeechProdvider : ISpeak
    {
        SpeechSynthesizer speaker;


        public SpeechProdvider()
        {
            speaker = new SpeechSynthesizer();
        }

        
        public void Speak(string speech)
        {
            speaker.Speak(speech);
        }
    }
}
