using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LemonWayConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Adresse de la webapi
            string urlWS = "http://localhost:58492/api/";
            //Methode à utiliser
            string method = "math/fibo/";
            //Donnée à envoyer
            string data = "10";

            var httpWebRequestInfo = (HttpWebRequest)WebRequest.Create(urlWS + method + data);
            httpWebRequestInfo.Method = "GET";

            httpWebRequestInfo.ContentType = "text/html";

            var httpResponse = (HttpWebResponse)httpWebRequestInfo.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string responseFromServer = streamReader.ReadToEnd();

                streamReader.Close();

                Console.WriteLine(responseFromServer);
                Console.ReadLine();
            }
        }
    }
}
