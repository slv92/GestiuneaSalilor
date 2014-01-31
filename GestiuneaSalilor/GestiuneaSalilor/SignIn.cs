using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestiuneaSalilor
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }


        BusinessLayerClass blc=new BusinessLayerClass();

       

        private void button1_Click(object sender, EventArgs e)
        {

            if (blc.SearchUser(textBox1.Text) == false)
                MessageBox.Show("The username doesn't exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {

                string pass=blc.ReturnPassword(textBox1.Text);


                if (blc.DecryptPassword(pass) == textBox2.Text)
                {



                    ClassRoom frm = new ClassRoom();
                    frm.Show();

                }

                else
                    MessageBox.Show("Password doesn't match!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }




        }
       
        private void SignIn_Load(object sender, EventArgs e)
        {

        }




        
    }
}
