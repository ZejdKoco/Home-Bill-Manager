using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace Bill_Manager
{
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        public void Initialize()
        {
            /*server = "sql11.freemysqlhosting.net";
            database = "sql11223976";
            uid = "sql11223976";
            password = "nCpzVzEWxG";*/
            server = "127.0.0.1";
            database = "billmanager";
            uid = "zejdkoco";
            password = "14.10.1996zeko";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "Convert Zero Datetime=True;";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
         public bool OpenConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        throw new Exception("Cannot connect to server.  Contact administrator");

                    case 1045:
                        throw new Exception("Invalid username/password, please try again");
                }
                return false;
            }
        }

        //Close connection
         public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Insert statement
         public void InsertRacunTip(string naziv)
        {
            string query = "INSERT INTO vrsta_racuna(naziv) VALUES('"+naziv+"')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(MySqlException ex)
                {
                    throw new Exception("Naziv vec postoji!");
                }

                //close connection
                this.CloseConnection();
            }
        }

        
        public void InsertRacun(Bill racun)
        {
            string datum2 = racun.Datum.ToString("yyyy-MM-dd HH:mm:ss");
            string query = "INSERT INTO racuni(naziv, iznos, datum) VALUES('" + racun.Naziv + "', '" + racun.Iznos + "', '" + datum2 + "');";
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Greska!");
                }

                //close connection
                this.CloseConnection();
            }
        }

        
        public Bill_Container SelectAll()
        {
            string naziv;
            double iznos;
            DateTime datum;
            Bill_Container izlaz = new Bill_Container();
            string query1 = "SELECT * FROM racuni";
            string query2 = "SELECT * FROM vrsta_racuna";
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query1, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    naziv = dataReader["naziv"] as string;
                    iznos = Convert.ToDouble(dataReader["iznos"]);
                    datum = Convert.ToDateTime(dataReader["datum"]);
                    izlaz.Lista_racuna.Add(new Bill(naziv, iznos, datum));
                }

                //close Data Reader
                dataReader.Close();
                MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                //Create a data reader and Execute the command
                dataReader = cmd2.ExecuteReader();
                while (dataReader.Read())
                {
                    naziv = dataReader["naziv"] as string;
                    izlaz.Vrste_racuna.Add(naziv);
                }
                dataReader.Close();
                //close Connection
                this.CloseConnection();
                return izlaz;

                
            }
            else
            {
                throw new Exception("Greska pri ucitavanju!");
            }
        }

        
        public void DeleteRacun(Bill racun)
        {
            string datum2 = racun.Datum.ToString("yyyy-MM-dd HH:mm:ss");
            string query = "DELETE FROM racuni WHERE naziv = '" + racun.Naziv + "' AND iznos = '" + racun.Iznos + "' AND datum = '" + datum2 + "';";
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Greska! Ne moze se obrisati!");
                }

                //close connection
                this.CloseConnection();
            }
        }
        public void DeleteVrstuRacuna(string naziv)
        {
            string query = "DELETE FROM vrsta_racuna WHERE naziv = '" + naziv + "';";
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Greska!");
                }

                //close connection
                this.CloseConnection();
            }

        }
        public void DeleteAllRacuni()
        {
            string query = "TRUNCATE TABLE racuni;";
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Greska!");
                }

                //close connection
                this.CloseConnection();
            }
        }

        
    }
}
