using System;
using System.IO;
using System.Net;



namespace sfl1_parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Here is the begning");

            ConnectionLoRa LoRa = new ConnectionLoRa();

            JSON Traitement = new JSON(LoRa.GetData());
            
            ConnectionBDD Bdd = new ConnectionBDD();

            Bdd.SendData(Traitement.DataDeserialized);
            /*
            //Test
            string[] data = { "0", "1", "2" };
            Bdd.SendData(data);
            */
        }
    }
}
