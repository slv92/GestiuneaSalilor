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
    public partial class ClassRoom : Form
    {
        BusinessLayerClass bls = new BusinessLayerClass();

        public ClassRoom()
        {
            InitializeComponent();
            dataGridView1.DataSource = bls.SelectSalaa();
        
        }

        private void ClassRoom_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Inventory inn = new Inventory();
            inn.Show();
        }




    }
}
