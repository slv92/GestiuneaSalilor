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
    public partial class Inventory : Form
    {
        BusinessLayerClass bls = new BusinessLayerClass();


        public Inventory()
        {
            InitializeComponent();
            dataGridView1.DataSource = bls.SelectInvt();
        }

        
        private void Inventory_Load(object sender, EventArgs e)
        {

        }
    }
}
