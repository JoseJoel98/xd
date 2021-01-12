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
    public partial class Serpiente : Form
    {
        Cola cabeza; //Cabeza que detecta la colision
        Comida comida; //Objeto de comida
        int puntaje = 0; 
        Graphics g; 
        int xdir = 0, ydir = 0; 
        int cuadro = 10;
        Boolean ejex = true, ejey = true; //Controlan los ejes
        public Serpiente()
        {
            InitializeComponent();
            cabeza = new Cola(10, 10); //Inicia la serpiente en esta posicion
            comida = new Comida(); //Inicia la comida
            g = canvas.CreateGraphics(); //Se crea un contexto grafico donde se va a dibujar
        }

        public void movimiento() //Funcion que permite que la serpiente se mueva
        {
            cabeza.setxy(cabeza.verX() + xdir, cabeza.verY() + ydir);
        }
        private void bucle_Tick(object sender, EventArgs e) //Timer para la velocidad de la serpiente
        {
            g.Clear(Color.White); //Cambia de colo por donde va pasando la serpiente
            cabeza.dibujar(g); //Dibuja la cabeza 
            comida.dibujar(g); //Dibuja la comida
            movimiento(); //Ejecuta la serpiente cada 50 milisegundos
            choquecuerpo(); //Funcion del choque de la serpiente consigo misma
            choquePared(); //Funcion del choque de la serpiente en las paredes
            if(cabeza.interseccion(comida)) //Aumenta el tamaño de la serpiente y el puntaje en 1, tambien da un nuevo lugar a la comida
            {
                comida.colocar();
                cabeza.meter();
                puntaje++;
                puntos.Text = puntaje.ToString();
            }
        }
        public  void choquePared() //Detecta si la serpiente choca con las paredes
        {
            if(cabeza.verX() < 0 || cabeza.verX() > 770 || cabeza.verY() < 0 || cabeza.verY() > 380)
            {
                findejuego();
            }
        }
        public void findejuego() //Funcion que da el fin del juego, y resetea todas las variables como al principio     
        {
            puntaje = 0;
            puntos.Text = "0";
            ejex = true;
            ejey = true;
            xdir = 0;
            ydir = 0;
            cabeza = new Cola(10, 10);
            comida = new Comida();
            MessageBox.Show("Perdiste");
        }
        public void choquecuerpo() //Detecta si la serpiente choca consigo misma
        {
            Cola temp;
            try
            {
                temp = cabeza.verSiguiente().verSiguiente();    
            }
            catch(Exception err)
            {
                temp = null;
            }
            while(temp != null)
            {
                if(cabeza.interseccion(temp))
                {
                    findejuego();
                }
                else
                {
                    temp = temp.verSiguiente();
                }
            }
        }
        private void Serpiente_KeyDown(object sender, KeyEventArgs e) //Evento que detecta las teclas que mueven a la serpiente 
        {
            if(ejex) //Si se esta en el eje X solo te podras mover en el eje Y
            {
                if(e.KeyCode == Keys.Up)
                {
                    ydir = -cuadro;
                    xdir = 0;
                    ejex = false;
                    ejey = true;
                }
                if(e.KeyCode == Keys.Down)
                {
                    ydir = cuadro;
                    xdir = 0;
                    ejex = false;
                    ejey = true;
                }
            }
            if(ejey) //Si se esta en el eje Y solo te podras mover en el eje X
            {
                if(e.KeyCode == Keys.Right)
                {
                    ydir = 0;
                    xdir = cuadro;
                    ejex = true;
                    ejey = false;
                }
                if(e.KeyCode == Keys.Left)
                {
                    ydir = 0;
                    xdir = -cuadro;
                    ejex = true;
                    ejey = false;
                }
            }
        }

        private void Serpiente_Load(object sender, EventArgs e)
        {
            canvas.BackColor = Color.Transparent;
        }
    }
}
