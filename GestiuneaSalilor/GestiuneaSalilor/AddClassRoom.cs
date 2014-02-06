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
    public partial class AddClassRoom : Form
    {
        public AddClassRoom()
        {
            InitializeComponent();
        }

       
        private void AddClassRoom_Load(object sender, EventArgs e)
        {

        }


        public int getID()
        {
            return Convert.ToInt32( textBox1.Text);
        }
        public string getNume()
        {
            return textBox2.Text;
        }

        public string getResp()
        {
            return textBox3.Text;
        }

        public int getSc()
        {
            return Convert.ToInt32(textBox4.Text);
        }
        public int getM()
        {
            return Convert.ToInt32(textBox5.Text);

        }

        public int getC()
        {
            return Convert.ToInt32(textBox6.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }




    }
}
