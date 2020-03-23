using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Traitement_JSON
{
    public class JsonDatatest
    {
        public string fruit { get; set; }
        public string size { get; set; }
        public string color { get; set; }
    }
    class Program
    {
        static async Task Main()
        {
            string[] device_ID = { "70b3d53af0032356", "70b3d53af0032355" }; // liste des ID des appareils (DevEUI)
            string[] urlcommands = { "sensors", "gateways", "servers" };
            string[] APIver = { "v1", "v2" };
            string serverIP = "82.231.146.148";
            string serverPort = "8440";
            string url = "https://" + serverIP + ":" + serverPort + "/" + APIver[0] + "/frame/" + device_ID[0];
            Console.WriteLine(url);

            string JsonDataSample = "{\"fruit\": \"Apple\",\"size\": \"Large\",\"color\": \"Red\"}";

            string JsonString = JSON.DataToJSON(JsonDataSample);

            Console.WriteLine(JsonString);

            while (true)
            {
                using (var httpClient = new HttpClient())//création du client Http
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), url))//creation de la requète à envoyer,
                                                                                             //envoyer = méthode "POST", url_destinataire
                    {
                        //request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
                        request.Headers.TryAddWithoutValidation("Accept", "application/json");// ? entète de la requète http ?

                        var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("stfelix:]u^!k_bgFKvqRb4U"));//demande d'autorisation de connexion(utilisateur:mot_de_passe)
                        request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");// ? entète de la requète http ?

                        //request.Content = new StringContent("{\"frame\":\"0123abcd\",\"port\":6}");//contenu JSON de la requète
                        //request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");// ?

                        var response = await httpClient.SendAsync(request);//réponse de la requète
                        Console.WriteLine(response);//affichage de la réponse

                    }
                }
            }
        }
    }

    public class JSON
    {
        public ObjData(string path)
        {
            JsonSerializer.Deserialize()
        }

        public static string DataToJSON(string Data)
        {
            string JSONData = JsonSerializer.Serialize(Data);
            return JSONData;
        }

        public static string JSONToData(Utf8JsonReader JSONData)
        {
            JsonSerializerOptions JSONSOptions = null;
            //string Data = JsonSerializer.Deserialize(JSONData, default, JSONSOptions);
            return "Data";
        }

    }

    public class ConnectBdd
    {
        
    }
}