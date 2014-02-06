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
            FillDataGrid();

        }

        void FillDataGrid()
        {
            dataGridView1.DataSource = bls.SelectSalaa();
            if (Program.LOG.ID == 1)
              
                button2.Visible = true;
            else
                button2.Visible = false;

            if (Program.LOG.ID == 1 || Program.LOG.ID == 2)

                button3.Visible = true;
            else
                button3.Visible = false;

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
            int i = 0;
            string s = null;
            s = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            i = Convert.ToInt32(s);
            bls.setSalaID(i);

        }

        private void button2_Click(object sender, EventArgs e)
        {



            using (NewAccount s = new NewAccount())
            {


                if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {


                    if (bls.SearchUser(s.getU()))
                    {
                        MessageBox.Show("The username already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        bls.SetUs(2, s.getU(), s.getP());

                        if (bls.InsertUs())
                        {


                            MessageBox.Show("Succes", "OK",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Error during Inserting", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }


            }



        }

        private void button3_Click(object sender, EventArgs e)
        {

            using (AddClassRoom cr = new AddClassRoom())
            {


                if (cr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {


                    if (bls.SearchIDS(cr.getID()))
                    {
                        MessageBox.Show("The ID already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    else
                    {
                        bls.SetSVal(cr.getID(), cr.getNume(), cr.getResp());
                            if(bls.InsertS())
                            {
                                FillDataGrid();

                                bls.SetInv(cr.getID(),cr.getSc(),cr.getM(),cr.getC());

                                bls.InsertInvt();
                            }
                    }





                }




            }




          }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

 
 }
}

