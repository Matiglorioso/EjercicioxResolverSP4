using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryEjercicioxResolverSP4

{
    public partial class frmVentasDiarias : Form
    {
        float[,] Mozos = new float[5, 5];
        int e = 0;
        int i = 0;
        int f = 0;
        int c = 0;
        public void CompletarMatriz()
        {
            for (int f = 0; f < Mozos.GetLength(0) ; f++)
            {
                for (int c = 0; c < Mozos.GetLength(1) -1 ; c++)
                {
                    Mozos[f, c] = Convert.ToSingle(dgvImportes.Rows[f].Cells[c + 1].Value);
                }
            }
        }



        public frmVentasDiarias()
        {
            InitializeComponent();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 4; i++)
            {
                dgvImportes.Rows.Add(i.ToString());
            }
            dgvImportes.Rows[0].Cells[0].Value = "Julio";
            dgvImportes.Rows[1].Cells[0].Value = "Esteban";
            dgvImportes.Rows[2].Cells[0].Value = "Javier";
            dgvImportes.Rows[3].Cells[0].Value = "Gonzalo";
            dgvImportes.Rows[4].Cells[0].Value = "Alberto";
            dgvImportes.Columns[0].ReadOnly = true;

            for (int f = 0; f < 5; f++)
            {
                for (int c = 1; c < 5; c++)
                {
                    dgvImportes.Rows[f].Cells[c].Value = 0;
                }
            }

        }

        private void btnValidarDatos_Click(object sender, EventArgs e)
        {
            lstTotales.Items.Clear();
            txtMozodelDia.Clear();
            bool resultado = true;
            for (int c = 1; c < dgvImportes.ColumnCount; c++)
            {
                for (int f = 0; f < dgvImportes.RowCount; f++)
                {
                    if (dgvImportes.Rows[f].Cells[c].Value == null)
                    {
                        resultado = false;
                        MessageBox.Show("Complete las celdas faltantes", "ERROR", MessageBoxButtons.OK);
                    }
                }
            }
            if (resultado == true)
            {
                CompletarMatriz();
                MessageBox.Show("Los datos fueron ingresados correctamente" , "ATENCIÓN" , MessageBoxButtons.OK);
                for (int f = 0; f < Mozos.GetLength(0); f++)
                {
                    for (int c = 0; c < Mozos.GetLength(1) - 1; c++)
                    {
                        Mozos[f, 4] = Mozos[f, c] + Mozos[f, 4];
                    }
                }
                btnMozoDelDia.Enabled = true;
                btnTotales.Enabled = true;
            }

        }


        private void btnMozoDelDia_Click(object sender, EventArgs e)
        {
            float Total = Mozos[0, 4];
            int i = 0;
            for (int f = 0; f < Mozos.GetLength(0); f++)
            {
                if (Total < Mozos[f, 4])
                {
                    Total = Mozos[f, 4];
                    i = f;
                }
            }
            if (i == 0)
            {
                txtMozodelDia.Text = ("Julio");
            }
            if (i == 1)
            {
                txtMozodelDia.Text = ("Esteban");
            }
            if (i == 2)
            {
                txtMozodelDia.Text = ("Javier");
            }
            if (i == 3)
            {
                txtMozodelDia.Text = ("Gonzalo");
            }
            if (i == 4)
            {
                txtMozodelDia.Text = ("Alberto");
            }
        }

        private void btnTotales_Click(object sender, EventArgs e)
        {
            lstTotales.Items.Clear();
            lstTotales.Items.Add("Julio vendió $ " + Mozos[0, 4].ToString());
            lstTotales.Items.Add("Esteban vendió $ " + Mozos[1, 4].ToString());
            lstTotales.Items.Add("Javier vendió $ " + Mozos[2, 4].ToString());
            lstTotales.Items.Add("Gonzalo vendió $ " + Mozos[3, 4].ToString());
            lstTotales.Items.Add("Alberto vendió $ " + Mozos[4, 4].ToString());
            for (int f = 0; f < 5; f++)
            {
                for (int c = 0; c < 4; c++)
                {
                    dgvImportes.Rows[f].Cells[c + 1].Value = 0 ;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mrcConsultas_Enter(object sender, EventArgs e)
        {

        }

        private void txtMozodelDia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

