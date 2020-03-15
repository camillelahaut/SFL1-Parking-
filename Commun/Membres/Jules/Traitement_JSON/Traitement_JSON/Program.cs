using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Traitement_JSON
{
    public class JsonData
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
            string serverPort = "11300";
            string url = "https://" + serverIP/* + ":" + serverPort*/ + "/" + APIver[0] + "/frame/" + device_ID[0] + "/";
            Console.WriteLine(url);

            string JsonDataSample = "{\"fruit\": \"Apple\",\"size\": \"Large\",\"color\": \"Red\"}";

            JsonData = DataToJSON(JsonDataSample);

            while (true)
            {
                break;
                using (var httpClient = new HttpClient())//création du client Http
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), url))//creation de la requète à envoyer,
                                                                                             //envoyer = méthode "POST", url_destinataire
                    {
                        request.Headers.TryAddWithoutValidation("Accept", "application/json");// ? entète de la requète http ?

                        var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("stfelix:]u^!k_bgFKvqRb4U"));//demande d'autorisation de connexion(utilisateur:mot_de_passe)
                        request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");// ? entète de la requète http ?

                        request.Content = new StringContent("{\"frame\":\"0123abcd\",\"port\":6}");//contenu JSON de la requète
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");// ?

                        var response = await httpClient.SendAsync(request);//réponse de la requète
                        Console.WriteLine(response);//affichage de la réponse

                    }
                }
            }
        }
    }

    class JSON
    {
        public string DataToJSON(string Data)
        {
            string JSONData = JsonSerializer.Serialize(Data);
            return JSONData;
        }

        public string JSONToData(string JSONData)
        {
            string Data = JsonSerializer.Deserialize<JsonData>(JSONData, null);
            return Data;
        }

    }
}
