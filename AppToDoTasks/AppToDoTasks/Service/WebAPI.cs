using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unirest_net.http;
using System.IO;
using Xamarin;

namespace AppToDoTasks.Service
{
    public class WebAPI
    {
        public string CreateTranslation(string inputSentence)
        {
            string sentence = inputSentence;
            string translation = ReadOutLoudYoda(sentence);

            return translation;
        }
        public string ReadOutLoudYoda(string yoda)
        {
          
                var handle = Insights.TrackTime("Time for API to connect");

                handle.Start();

                var response = Unirest.get("https://yoda.p.mashape.com/yoda?sentence=" + yoda)
                 .header("X-Mashape-Key", "jNdTUH1UxUmshWJ0duG9JGydgLqGp13bv6IjsnmZCuwlTEAK62")
                 .header("Accept", "text/plain")
                 .asString();

                if (response.Code == 200)
                {
                    return response.Body;
                }

                handle.Stop();

                string errorMessages = "Could not connect to API";
                return errorMessages;                 

        }
    }
}
