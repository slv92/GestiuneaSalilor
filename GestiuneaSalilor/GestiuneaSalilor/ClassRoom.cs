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

        private void Orar_Click(object sender, EventArgs e)
        {
            OrarMainForm form = new OrarMainForm();
            form.Show();
            int i=0;
            string s = null;
            s = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            i = Convert.ToInt32(s);
            bls.setSalaID(i);

        }




    }
}
