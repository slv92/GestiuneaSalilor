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
    public partial class Log : Form
    {

        BusinessLayerClass bsl = new BusinessLayerClass();
        public Log()
        {
            InitializeComponent();
            
        
        }

       

        private void Log_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.LOG.ID = 0;
            ClassRoom c = new ClassRoom();
            c.Show();


        }

     


        private void button2_Click(object sender, EventArgs e)
        {
            SignIn sg = new SignIn();
            sg.Show();
        }

       

    }
}
