﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class objeto //Da las posiciones X, Y y Ancho a las demas clases
    {
        protected int x, y, ancho;
        public objeto()
        {
            ancho = 10;
        }
        public Boolean interseccion(objeto o) //Función que detecta los coliciones
        {
            int difx = Math.Abs(this.x - o.x);
            int dify = Math.Abs(this.y - o.y);
            if(difx >= 0 && difx < ancho && dify >= 0 && dify < ancho)
            {
                return true;
            } else
            {
                return false;
            }
    }
}}
