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
    public partial class NewAccount : Form
    {
        public NewAccount()
        {
            InitializeComponent();
        }
        public string getU()
        {
            return textBox1.Text.ToString();


        }

        public string getP()
        {
            return textBox2.Text.ToString();
        }

        public string getCP()
        {
            return textBox3.Text.ToString();
        }

     
        private void button2_Click(object sender, EventArgs e)
        {

            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (getU() != "" && getP() != "" && getCP() != "")
            {
                if (getP() == getCP())
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The password doesn't match", "Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
                MessageBox.Show("Please complete all fields");

        }

        private void NewAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
