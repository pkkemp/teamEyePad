using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using presage;

namespace ALSProject
{
    class PresagePredictor
    {

        Presage presage;
        String buffer;
        String nextWord;

        public PresagePredictor()
        {
            buffer = "";
            nextWord = "";
            presage = new Presage
               (
                   callback_get_past_stream,
                   callback_get_future_stream,
                   "presage.xml"
               );
        }

        public void reset()
        {
            buffer = "";
        }


        public String[] getPredictions(string inputString)
        {
            buffer = inputString;
            return presage.predict();
        }

        private string callback_get_past_stream()
        {
            return buffer;

        }

        private string callback_get_future_stream()
        {
            return nextWord;
        }

        


    }
}
