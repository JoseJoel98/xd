using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Gato : Form
    {
        bool turno = true;
        int turnos = 0;
        public Gato()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turno)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turno = !turno;
            b.Enabled = false;
            turnos++;
            MirarGanador();
        }

        private void MirarGanador()
        {
            bool hayganador = false;
            //Horizontal
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                hayganador = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                hayganador = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                hayganador = true;
            }
            
            //Vertical
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                hayganador = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                hayganador = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                hayganador = true;
            }

            //Diagonal
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                hayganador = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
            {
                hayganador = true;
            }

            if (hayganador)
            {
                desabilitarBotones();
                string ganador = "";
                if (turno)
                {
                    ganador = "O";
                }
                else
                {
                    ganador = "X";
                }
                MessageBox.Show(ganador + " Gano", "Felicidades");
            }
            else
            {
                if(turnos ==9)
                {
                    MessageBox.Show("Empate", "Unlucky");
                }
            }
        }

        private void desabilitarBotones()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nuevoJuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turno = true;
            turnos = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }
    }
}
