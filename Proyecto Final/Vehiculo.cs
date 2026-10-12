using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shalom
{
    // Cada vehículo tiene SU propia pila de carga y SU propia ruta
    public class Vehiculo
    {
        private string placa;
        private string conductor;
        private decimal capacidadKg;
        private PilaEnvios carga;
        private ListaRuta ruta;

        // Indispensable: crea la pila con la capacidad del vehículo
        public Vehiculo(string placa, string conductor, decimal capacidadKg)
        {
            this.placa = placa;
            this.conductor = conductor;
            this.capacidadKg = capacidadKg;
            carga = new PilaEnvios(capacidadKg);
            ruta = new ListaRuta();
        }

        public string Placa { get => placa; }
        public string Conductor { get => conductor; set => conductor = value; }
        public decimal CapacidadKg { get => capacidadKg; }
        public PilaEnvios Carga { get => carga; }
        public ListaRuta Ruta { get => ruta; }

        // Para la barra de carga
        public int PorcentajeCarga() { return (int)(carga.PesoActual * 100 / capacidadKg); }

        // Texto del ComboBox de vehículos
        public string MostrarDatos()
        {
            return "Placa: " + placa + " - Conductor: " + conductor +
                   " - Capacidad: " + capacidadKg + " kg";
        }
    }
}
    