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
        SaliValues sv = new SaliValues();
        Inventory2 inv = new Inventory2();

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

        public SaliValues SetSaliVal(int i, string a, string b)
        {
            sv.setID_SALA(i);
            sv.setNumeS(a);
            sv.setResp(b);
            return sv;
        }

        public Inventory2 SetInventory(int a, int b, int c, int d)
        {
            inv.setIDS(a);
            inv.setScaune(b);
            inv.setMese(c);
            inv.setCalc(d);
            return inv;
        }
      

        public bool InsertUser()
        {
            Connection db = new Connection();


            string sqlQuery = "INSERT INTO Users ";
            sqlQuery += "(ID_U, Username, Password) ";
            sqlQuery += "VALUES ";
            sqlQuery += "(@ID_U, @Username, @Password)";



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@ID_U", us.getID().ToString());
            parameters.Add("@Username", us.getUsername());
            parameters.Add("@Password", EncryptPassword(us.getPassword()));


            return db.InsertUpdateDelete(sqlQuery, parameters, false);
        }

        public bool InsertSala()
        {
            Connection db = new Connection();

            Dictionary<string, string> parameters2 = new Dictionary<string, string>();
            parameters2.Add("@ID_S", sv.getID_SALA().ToString());
            parameters2.Add("@Nume_Sala", sv.getNumeS());
            parameters2.Add("@Responsabil", sv.getResp());


            return db.InsertUpdateDelete("InsertS", parameters2, true);


        }

        public bool InsertInventar()
        {
            Connection db = new Connection();

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@ID_S", inv.getID().ToString());
            parameters.Add("@Numar_Scaune", inv.getScaune().ToString());
            parameters.Add("@Numar_Mese", inv.getMese().ToString());
            parameters.Add("@Numar_calculatoare", inv.getCalc().ToString());


            return db.InsertUpdateDelete("InsertInventar", parameters, true);


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
