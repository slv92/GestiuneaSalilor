using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiuneaSalilor
{
    class SaliValues
    {
        public int ID_Sala { get; set; }
        public string Nume_Sala { get; set; }
        public string Responsabil { get; set; }


        public void setID_SALA(int x)
        {
            ID_Sala = x;
        }

        public int getID_SALA()
        {
            return ID_Sala;
        }

        public void setNumeS(string a)
        {
            Nume_Sala = a;
        }

        public string getNumeS()
        {
            return Nume_Sala;
        }


        public void setResp(string a)
        {
            Responsabil = a;
        }

        public string getResp()
        {
            return Responsabil;
        }
    }

    class Inventory2
    {
        public int ID_S { get; set; }
        public int Numar_Scaune { get; set; }
        public int Numar_Mese { get; set; }
        public int Numar_calculatoare { get; set; }


        public void setIDS(int a)
        {

            ID_S = a;
        }


        public int getID()
        {
            return ID_S;
        }


        public void setScaune(int a)
        {

            Numar_Scaune = a;
        }


        public int getScaune()
        {
            return Numar_Scaune;
        }

        public void setMese(int a)
        {

            Numar_Mese = a;
        }


        public int getMese()
        {
            return Numar_Mese;
        }

        public void setCalc(int a)
        {

            Numar_calculatoare = a;
        }


        public int getCalc()
        {
            return Numar_calculatoare;
        }





    }


    class Users
        {
            public int ID_U { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            
            
            public void setID(int a)
            {

                ID_U = a;
            }


            public int getID()
            {
                return ID_U;
            }


            public void setUsername(string b)
            {

                Username = b;
            }

            public string getUsername()
            {

                return Username;
            }

            public void setPassword(string b)
            {

                Password = b;
            }


            public string getPassword()
            {
                return Password;
            }

        }





    }

