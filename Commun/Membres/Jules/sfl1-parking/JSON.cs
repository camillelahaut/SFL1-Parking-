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
            DataDeserialized = this.JSONDesrialize(Data);
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
            switch (DevEUI)
            {
                case "70B3D53AF0032355":
                    return "1";//replace (Put identifer here)
                case "70B3D53AF0032356":
                    return "2";//replace (Put identifer here)
                default:
                    return "wrong DevEUI";
            }
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
