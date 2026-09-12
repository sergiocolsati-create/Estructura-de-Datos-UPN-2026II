using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Nododoble //creamos la nueva clase nododoble para lista enlazada doble
    {
        private string navi; // definimos el tipo de dato, en este caso al ser navegacion, usaremos un string que permite diferentes caracteres para una url
        private Nododoble next; // almacenara puntero que apunta al siguiente
        private Nododoble prev; // almacenara puntero que apunta al anteior

        public string Navi { get => navi; set => navi = value; } // get y set de Navi
        internal Nododoble Next { get => next; set => next = value; }// get y set de Nododoble      
        internal Nododoble Prev { get => prev; set => prev = value; }// get y set de nodod doble
    }
}
