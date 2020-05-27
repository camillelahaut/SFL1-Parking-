using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace sfl1_parking
{
    class JSON
    {
        public string[] DataDeserialized { get; set; }
        public JSON()
        {
            string Data = File.ReadAllText(@"E:\Drawing Git Repository\SFL1 - Parking -\Commun\Membres\Jules\sfl1 - parking\JsonFile.txt"); //exemple de réception
            Console.WriteLine("Début du traitement des données.");
            try
            {
                DataDeserialized = this.JSONDesrialize(Data);
            }
            catch (Exception e) {
                Console.WriteLine("Une erreur est survenue pendant le traitement des données.");
                Console.WriteLine(e);
            }
        }

        public JSON(string Data)
        {
            DataDeserialized = this.JSONDesrialize(Data);
        }

        private string[] JSONDesrialize(string Data)
        {
            Info infoObj = JsonSerializer.Deserialize<Info>(Data);

            string[] Deserialized = new string[3] { TranslateDevEUItoId(infoObj.DevEUI), infoObj.occuper, infoObj.lastUpdate };

            return Deserialized;
        }

        private string TranslateDevEUItoId(string DevEUI)
        {
            ConnectionBDD DevEUICheck = new ConnectionBDD();

            return DevEUICheck.GetDevEUI(DevEUI);
        }
    }

    class Info
    {
        public string DevEUI { get; set; }
        public string AppEUI { get; set; }
        public string Appkey { get; set; }
        public string occuper { get; set; }
        public string lastUpdate { get; set; }
    }
}
