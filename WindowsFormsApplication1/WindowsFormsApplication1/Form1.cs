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
    public partial class Form1 : Form
    {
        public Form1()
        {
            int i;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Serpiente i = new Serpiente();
            i.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JuegoMemorama i = new JuegoMemorama();
            i.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Gato i = new Gato();
            i.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Transparent;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
