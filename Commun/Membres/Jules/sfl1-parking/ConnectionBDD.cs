using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace sfl1_parking
{
    public class ConnectionBDD
    {
        private MySqlConnection connection;
        public ConnectionBDD() //constructeur
        {
            this.InitConnexion();
        }

        private void InitConnexion() //initialisation de la connexion
        {
            string IpAdress = "192.168.1.100";// 192.168.1.100 est l'adresse du serveur MySQL.
            string DB = "sfl1_bdd";// Nous avons créé une base de données nommée "sfl1_bdd".
            string UID = "sfl1-application";// L'utilisateur par défaut lors de l'installation de XAMPP est "sfl1-application".
            string PW = "a";//mot de passe "a".

            string connectionString = "SERVER=" + IpAdress + "; DATABASE=" + DB + "; UID=" + UID + "; PASSWORD=" + PW;
            this.connection = new MySqlConnection(connectionString);
        }

        public void SendData(string[] Data) //envoie de donnée
        {
            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();
                //création d'une commande SQL en rapport avec l'objet connexion
                MySqlCommand cmd = this.connection.CreateCommand();

                //Reqète SQL
                cmd.CommandText = "INSERT INTO Data (idData, Présence, Date) VALUES ('" + Data[0] + "','" + Data[1] + "','" + Data[2] + "')";

                //excution de la requète SQL
                cmd.ExecuteNonQuery();

                //fermeture de la connexion
                this.connection.Close();
            }
            catch (Exception e)
            {
                //getion des erreurs
                Console.WriteLine(e);
            }
        }

        public string GetDevEUI(string DevEUI)
        {
            string idCapteur = "";
            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();
                //création d'une commande SQL en rapport avec l'objet connexion
                MySqlCommand cmd = this.connection.CreateCommand();

                //Reqète SQL
                cmd.CommandText = "SELECT idCapteur FROM Capteurs WHERE DevEUI = '" + DevEUI + "'";

                //excution de la requète SQL
                cmd.ExecuteNonQuery();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    idCapteur = reader.GetString(1);
                }

                //fermeture de la connexion
                this.connection.Close();
            }
            catch (Exception e)
            {
                //getion des erreurs
                Console.WriteLine(e);
            }
            return idCapteur;
        }
    }
}
