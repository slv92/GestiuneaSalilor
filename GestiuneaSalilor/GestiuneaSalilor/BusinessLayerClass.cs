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
    class BusinessLayerClass
    {

        public DataLayerClass dlc = new DataLayerClass();
        Users us = new Users();
        SaliValues sal = new SaliValues();
        Inventory2 inv = new Inventory2();


        public string DecryptPassword(string encryptedPassword)
        {
            byte[] passByteData = Convert.FromBase64String(encryptedPassword);
            string originalPassword = System.Text.Encoding.Unicode.GetString(passByteData);
            return originalPassword;
        }

        // salvez informatii despre un user
        public Users SetUs(int i, string a, string b)
        {
            us = dlc.SetUser(i, a, b);

            return us;
        }

        // apelez functia de inserare user din dataLayer
        public bool InsertUs()
        {
            if (dlc.InsertUser())
                return true;
            else
                return false;
        }

        // caut un user in tabela
        public bool SearchUser(string name)
        {

            DataTable dt = new DataTable();

            dt = dlc.SelectU();
            int k = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Username"].ToString() == name)
                    k = 1;

            }

            if (k == 1)
                return true;
            else
                return false;




        }

        // returnez parola corespunzatoare unui user
        public string ReturnPassword(string name)
        {
            DataTable dt = new DataTable();

            dt = dlc.SelectU();
            int k = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Username"].ToString() == name)
                    return dr["Password"].ToString();
                k = 1;
            }


            return null;



        }

        //  returnez id-ul corespunzator unui user( SuperAdmin=1, admin=2) 
        public int ReturnIdU(string name)
        {
            DataTable dt = new DataTable();

            dt = dlc.SelectU();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Username"].ToString() == name)
                    return Convert.ToInt32(dr["ID_U"]);

            }


            return 0;



        }



        // salvez informatii despre o sala
        public SaliValues SetSVal(int i, string a, string b)
        {
            sal = dlc.SetSaliVal(i, a, b);

            return sal;
        }

        //  apelez functia de selectare a unei sali in functie de id-ul acesteia
        public DataRow SelectSalaID()
        {
            DataRow dr = dlc.SelectSalaById();

            return dr;
        }

        //apelez functia de insert a unei sali
        public bool InsertS()
        {
            if (dlc.InsertSala())
                return true;
            else
                return false;

        }

        // apelez functia de update a unei sali
        public bool UpdateS()
        {
            if (dlc.UpdateSali())
                return true;
            else
                return false;
        }

        // apelez functia de delete a unei sali
        public bool DeleteS()
        {
            if (dlc.DeleteSalaa())
                return true;
            else
                return false;
        }

        // caut o sala dupa id
        public bool SearchIDS(int nr)
        {

            DataTable dt = new DataTable();

            dt = dlc.SelectSala();
            int k = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["ID_S"]) == nr)
                    k = 1;

            }

            if (k == 1)
                return true;
            else
                return false;

        }
        
        // selectez o sala
        public DataTable SelectSalaa()
        {
            DataTable dt = new DataTable();
            dt = dlc.SelectSala();
            return dt;


        }


        public void setSalaID(int i)
        {
            sal.setID_SALA(i);

        }

       // salvez informatii despre inventarul unei sali

        public Inventory2 SetInv(int a, int b, int c, int d)
        {
            inv = dlc.SetInventory(a, b, c, d);
            return inv;

        }

        // selectez id-ul unei sali din tabelul inventar
        public DataRow SelectInvID()
        {
            DataRow dr = dlc.SelectInventarId();
            return dr;
         }


        // inserez informatii in tabela inventar_sala       
        public bool InsertInvt()
        {
            if (dlc.InsertInventar())
                return true;
            else
                return false;

        }

       // selectez informatiile din tabela inventar_sala

        public DataTable SelectInvt()
        {
            DataTable dt = new DataTable();
            dt = dlc.SelectInventar();
            return dt;


        }



    }
}
