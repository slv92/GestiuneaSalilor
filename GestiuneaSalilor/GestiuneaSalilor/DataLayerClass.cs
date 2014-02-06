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


        // salveaza informatii despre un user
        public Users SetUser(int i, string a, string b)
        {
            us.setID(i);
            us.setPassword(b);
            us.setUsername(a);

            return us;

        }

        // insereaza un user
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

        // selectez toti utilizatorii
        public DataTable SelectU()
        {

            Connection db = new Connection();



            string sqlQuery = "SELECT * FROM Users ";

            return db.Select(sqlQuery, false);

        }

        // salvez informatii despre o sala
        public SaliValues SetSaliVal(int i, string a, string b)
        {
            sv.setID_SALA(i);
            sv.setNumeS(a);
            sv.setResp(b);
            return sv;
        }

        //inserez o sala
        public bool InsertSala()
        {
            Connection db = new Connection();

            Dictionary<string, string> parameters2 = new Dictionary<string, string>();
            parameters2.Add("@ID_S", sv.getID_SALA().ToString());
            parameters2.Add("@Nume_Sala", sv.getNumeS());
            parameters2.Add("@Responsabil", sv.getResp());


            return db.InsertUpdateDelete("InsertS", parameters2, true);


        }

        // selectez o sala dupa id
        public DataRow SelectSalaById()
        {
            Connection db = new Connection();

            Dictionary<string, string> parameters2 = new Dictionary<string, string>();
            parameters2.Add("@ID_S", sv.getID_SALA().ToString());

            return db.Select("SelID_S", true, parameters2).AsEnumerable().First();


        }

            // selectez toate salile
        public DataTable SelectSala()
        {

            Connection db = new Connection();



            string sqlQuery = "SELECT * FROM Sala";

            return db.Select(sqlQuery, false);

        }

         // modific informatii despre o sala, inclusiv despre inventarul acesteia 
        public bool UpdateSali()
        {
            Connection db = new Connection();


            Dictionary<string, string> parameters2 = new Dictionary<string, string>();
            parameters2.Add("@ID_S", sv.getID_SALA().ToString());
            parameters2.Add("@Nume_Sala", sv.getNumeS());
            parameters2.Add("@Responsabil", sv.getResp());
            parameters2.Add("@Numar_Scaune", inv.getScaune().ToString());
            parameters2.Add("@Numar_Mese", inv.getMese().ToString());
            parameters2.Add("@Numar_calculatoare", inv.getCalc().ToString());



            return db.InsertUpdateDelete("UpdateSala", parameters2, true);


        }

        // sterg o sala,inclusiv informatiile din inventar referitoare la sala respectiva
        public bool DeleteSalaa()
        {

            Connection db = new Connection();

            Dictionary<string, string> parameters2 = new Dictionary<string, string>();
            parameters2.Add("@ID_S", sv.getID_SALA().ToString());

            return db.InsertUpdateDelete("DeleteSalaa", parameters2, true);

        }

        // salvez informatiile legate de inventarul unei sali
        public Inventory2 SetInventory(int a, int b, int c, int d)
        {
            inv.setIDS(a);
            inv.setScaune(b);
            inv.setMese(c);
            inv.setCalc(d);
            return inv;
        }
      

       

      // inserez in inventarul unei sali
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

      

        // selectez dupa id o intrare din tabela inventar_sala
        public DataRow SelectInventarId()
        {
            Connection db = new Connection();

            Dictionary<string, string> parameters2 = new Dictionary<string, string>();
            parameters2.Add("@ID_S", inv.getID().ToString());

            return db.Select("SelInvID", true, parameters2).AsEnumerable().First();


       }

       


        // selectez toate informatiile din inventar_sala
        public DataTable SelectInventar()
        {

            Connection db = new Connection();



            string sqlQuery = "SELECT * FROM Inventar_Sala";

            return db.Select(sqlQuery, false);

        }

       


      

    }
}
