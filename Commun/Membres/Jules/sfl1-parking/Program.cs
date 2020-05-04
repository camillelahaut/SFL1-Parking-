using System;
using System.IO;
using System.Net;



namespace sfl1_parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begening of the application");

            ConnectionLoRa LoRa = new ConnectionLoRa();

            JSON Traitement = new JSON(LoRa.GetData());
            
            ConnectionBDD Bdd = new ConnectionBDD();

            Bdd.SendData(Traitement.DataDeserialized);
        }
    }
}
