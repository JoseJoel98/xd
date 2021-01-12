using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Cola : objeto //Clase Cola deriva de la clase objeto
    {
        Cola siguiente;
        public Cola(int x, int y) //Constructor que ubica a la serpiente 
        {
            this.x = x;
            this.y = y;
            siguiente = null;
        }
        public void dibujar(Graphics g) //Dibuja la serpiente y los cuadros que le siguen detras
        {
            if(siguiente != null) //Dibuja los siguientes cuadros de la serpiente
            {
                siguiente.dibujar(g);
            }
            g.FillRectangle(new SolidBrush(Color.Blue), this.x, this.y, this.ancho, this.ancho);
        }
        public void setxy(int x, int y) //Función que permite mover la serpiente
        {
            if(siguiente != null)
            {
                siguiente.setxy(this.x, this.y);
            }
            this.x = x;
            this.y = y;
        }
        public void meter() //Encadena los siguientes cuadros   
        {
            if(siguiente == null)
            {
                siguiente = new Cola(this.x, this.y);
            }
            else
            {
                siguiente.meter();
            }
        }
        public int verX() //Devuelve los valores de x protegidos
        {
            return this.x;
        }
        public int verY() //Devuelve los valores de y protegidos
        {
            return this.y;
        }
        public Cola verSiguiente()
        {
            return siguiente;
        }
    }
}
