using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace sfl1_parking
{
    class ConnectionLoRa
    {

        string Data;
        public ConnectionLoRa() //objet de connexion au service LoRa
        {
            this.InitConnexion();
        }
        private void InitConnexion() //initialisation de la connexion
        {

            while (true)
            {
                Console.WriteLine("Choose option (1 or 2) : "); //choix de la méthode de connexion
                string choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        try
                        {
                            HttpWebRequest request = WebRequest.Create("http://82.231.146.148/servers/") as HttpWebRequest;

                            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                            Stream stream = response.GetResponseStream();
                            Console.WriteLine(stream);
                            //string Data = stream;
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            break;
                        }
                    case "2":
                        Data = File.ReadAllText(@"JsonFile.txt"); //exemple de réception
                        break;
                    default:
                        Console.WriteLine("Your input was wrong");
                        break;
                }
            }
        }

        public string GetData()
        {
            return Data;
        }
    }
}
