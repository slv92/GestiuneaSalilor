using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GestiuneaSalilor
{
    class DataLayerClass
    {

        public DataLayerClass()
        {

        }

        Users us = new Users();

        public string EncryptPassword(string txtPassword)
        {
            byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(txtPassword);
            string encryptPassword = Convert.ToBase64String(passBytes);
            return encryptPassword;
        }



        public Users SetUser(int i, string a, string b)
        {
            us.setID(i);
            us.setPassword(b);
            us.setUsername(a);

            return us;

        }

      

        public bool InsertUser()
        {
            Connection db = new Connection();


            string sqlQuery = "INSERT INTO User ";
            sqlQuery += "(ID_U, Username, Password) ";
            sqlQuery += "VALUES ";
            sqlQuery += "(@ID_U, @Username, @Password)";



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@ID_U", us.getID().ToString());
            parameters.Add("@Username", us.getUsername());
            parameters.Add("@Password", EncryptPassword(us.getPassword()));


            return db.InsertUpdateDelete(sqlQuery, parameters, false);
        }




        public DataTable SelectU()
        {

            Connection db = new Connection();



            string sqlQuery = "SELECT * FROM Users ";

            return db.Select(sqlQuery, false);

        }

        public DataTable SelectSala()
        {

            Connection db = new Connection();



            string sqlQuery = "SELECT * FROM Sala";

            return db.Select(sqlQuery, false);

        }



        public DataTable SelectInventar()
        {

            Connection db = new Connection();



            string sqlQuery = "SELECT * FROM Inventar_Sala";

            return db.Select(sqlQuery, false);

        }






    }
}
