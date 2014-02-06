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

        SaliValues sv = new SaliValues();
        BusinessLayerClass blc = new BusinessLayerClass();

        private void AddClassRoom_Load(object sender, EventArgs e)
        {

        }

        // returneaza id-ul 
        public int getID()
        {
            return Convert.ToInt32( textBox1.Text);
        }

        // returneaza numele salii
        public string getNume()
        {
            return textBox2.Text;
        }

        // returneaza responsabilul salii
        public string getResp()
        {
            return textBox3.Text;
        }

        // returneaza numarul scaunelor
        public int getSc()
        {
            return Convert.ToInt32(textBox4.Text);
        }

        // returneaza numarul meselor
        public int getM()
        {
            return Convert.ToInt32(textBox5.Text);

        }

        // returneaza numarul calculatoarelor
        public int getC()
        {
            return Convert.ToInt32(textBox6.Text);

        }


        // Introduc in textBox-uri datele despre sala selectata
        public int Class
        {
            get
            {
                return int.Parse(this.textBox2.Tag.ToString());
            }
            set
            {


                if (value == 0)
                {
                    this.textBox2.Text = null;
                    this.textBox2.Tag = 0;
                    this.textBox3.Text = null;

                }
                else
                {
                    blc.SetSVal(value, null, null);


                    DataRow dr = blc.SelectSalaID();
                    this.textBox1.Text = value.ToString();
                    this.textBox2.Text = dr["Nume_Sala"].ToString();
                    this.textBox2.Tag = value;
                    this.textBox3.Text = dr["Responsabil"].ToString();


                    blc.SetInv(value, 0, 0, 0);
                    DataRow dr2 = blc.SelectInvID();
                    this.textBox4.Text = dr2["Numar_Scaune"].ToString();
                    this.textBox5.Text = dr2["Numar_Mese"].ToString();
                    this.textBox6.Text = dr2["Numar_calculatoare"].ToString();

                }

            }
        }

        // buton Save
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && getNume() != "" && getResp() != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Please complete all fields");
        }

        // buton Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }




    }
}
