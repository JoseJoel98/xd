using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Comida : objeto //Clase Comida deriva de la clase objeto
    {
        public Comida() //Constructor que genera la comida
        {
            this.x = generar(78);
            this.y = generar(39);
        }
        public void dibujar(Graphics g) //Metodo que dibuja la comida
        {
            g.FillRectangle(new SolidBrush(Color.Red), this.x, this.y, this.ancho, this.ancho);
        }
        public void colocar() //Da una nueva posicion aleatoria a X , Y
        {
            this.x = generar(78);
            this.y = generar(39);
        }
        public int generar(int n) //Genera la comida aleatoriamente
        {
            Random random = new Random();
            int num = random.Next(0, n) * 10;
            return num;
        }
    }
}
