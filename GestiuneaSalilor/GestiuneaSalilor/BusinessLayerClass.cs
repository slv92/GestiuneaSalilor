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

        public Users SetUs(int i, string a, string b)
        {
            us = dlc.SetUser(i, a, b);

            return us;
        }


        public SaliValues SetSVal(int i, string a, string b)
        {
            sal = dlc.SetSaliVal(i, a, b);

            return sal;
        }

        public Inventory2 SetInv(int a, int b, int c, int d)
        {
            inv = dlc.SetInventory(a, b, c, d);
            return inv;

        }

        public void setSalaID(int i)
        {
            sal.setID_SALA(i);

        }

        public bool InsertUs()
        {
            if (dlc.InsertUser())
                return true;
            else 
                return false;
        }

        public bool InsertS()
        {
            if (dlc.InsertSala())
                return true;
            else
                return false;

        }

        public bool InsertInvt()
        {
            if (dlc.InsertInventar())
                return true;
            else
                return false;

        }

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
        
        public int ReturnIdU(string name)
        {
            DataTable dt = new DataTable();

            dt = dlc.SelectU();
            
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Username"].ToString() == name)
                    return Convert.ToInt32( dr["ID_U"]);
                
            }


            return 0;



        }


        public bool SearchIDS(int nr)
        {

            DataTable dt = new DataTable();

            dt = dlc.SelectSala();
            int k = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32( dr["ID_S"]) == nr)
                    k = 1;

            }

            if (k == 1)
                return true;
            else
                return false;




        }


        public DataTable SelectSalaa()
        {
            DataTable dt = new DataTable();
            dt = dlc.SelectSala();
            return dt;


         }

        public DataTable SelectInvt()
        {
            DataTable dt = new DataTable();
            dt = dlc.SelectInventar();
            return dt;


        }




    }
}
