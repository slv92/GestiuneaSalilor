﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiuneaSalilor
{
    class Values
    {
    
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
