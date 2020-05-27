using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

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
                            using (var httpClient = new HttpClient())
                            {
                                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://wiotys.wi6labs.net:8440/v1/frame/AC000001AC000001"))
                                {
                                    request.Headers.TryAddWithoutValidation("Accept", "application/json");

                                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("user:userPwd"));
                                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                                    request.Content = new StringContent("{\"frame\":\"0123abcd\",\"port\":6}");
                                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                                    var response = httpClient.SendAsync(request);
                                    Console.WriteLine("La communication avec la BDD MariaDB c'est éffectuée sans problèmes");
                                }
                            }
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Une erreur est survenue dans la connexion ou de la communication à la BDD MariaDB");
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
