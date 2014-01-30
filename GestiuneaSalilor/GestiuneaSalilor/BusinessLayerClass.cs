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


        public bool InsertUs()
        {
            if (dlc.InsertUser())
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
