using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semana05
{
    public partial class Reloj : Form

    {// Cuatro listas circulares, una por cada unidad de tiempo que se muestra.
        ListaCircularR lcent=new ListaCircularR();
        ListaCircularR lseg = new ListaCircularR();
        ListaCircularR lmin = new ListaCircularR();
        ListaCircularR lhor = new ListaCircularR();

        bool mode = true;// esta variable es la única forma en que el Tick sabe qué dirección tomar.
        public Reloj()
        {
            InitializeComponent();
            lcent.ContruirReloj(100); // centésimas de segundo: 0 a 99
            lseg.ContruirReloj(60);// segundos: 0 a 59
            lmin.ContruirReloj(60);// minutos: 0 a 59
            lhor.ContruirReloj(24);// horas: 0 a 23

            ActualizarLabel();// Muestra 00:00:00:00 apenas se abre la ventana,

        }
        
        private void timer1_Tick(object sender, EventArgs e) // Decide, según "mode", si debe sumar o restar tiempo.
        {
            if (mode)
            {
                int nuevoCent = lcent.AvanzarActual();
                if (nuevoCent == 0) // significa que pasó un segundo completo -> avanza segundos.
                {
                    int nuevoSegundo = lseg.AvanzarActual();// Avanza segundos. Si vuelve a 0, pasó un minuto -> avanza minutos.
                    if (nuevoSegundo == 0)
                    {
                        int nuevoMinuto = lmin.AvanzarActual();// Avanza minutos. Si vuelve a 0, pasó una hora -> avanza horas.
                        if (nuevoMinuto == 0)
                        {
                            lhor.AvanzarActual();
                        }
                    }
                }
            }
            else
            {
                int nuevoCent = lcent.RetrocederActual();
                if (nuevoCent == 99)// significa que "le pidió prestado" al segundo -> retrocede segundos.
                {
                    int nuevoSegundo = lseg.RetrocederActual();// Retrocede segundos. Si llega a 59, pidió prestado al minuto.
                    if (nuevoSegundo == 59)
                    {
                        int nuevoMinuto = lmin.RetrocederActual();// Retrocede minutos. Si llega a 59, pidió prestado a la hora.
                        if (nuevoMinuto == 59)
                        {
                            lhor.RetrocederActual();
                        }
                    }
                }

                if (lhor.ObtenerActual() == 0 && lmin.ObtenerActual() == 0 &&
                    lseg.ObtenerActual() == 0 && lcent.ObtenerActual() == 0)// Revisa si las 4 listas llegaron a cero al mismo tiempo, se detiene
                {
                    timer1.Stop();
                    MessageBox.Show("¡Tiempo terminado!");
                }
            }

            ActualizarLabel();
        }

        private void ActualizarLabel()
        {
            lblHora.Text =
                $"{lhor.ObtenerActual():00}:{lmin.ObtenerActual():00}:{lseg.ObtenerActual():00}:{lcent.ObtenerActual():00}";
        }


        private void bttnStart_Click(object sender, EventArgs e) // Botón Pausar/Iniciar: solo detiene o reanuda el timer,
        {
            if (timer1.Enabled)// si esta activado lo detiene y muestra en el texto Iniciar
            {
                timer1.Stop();
                bttnStart.Text = "Iniciar";
                return;
            }

            timer1.Start();// sino lo inicializa y cambie el texto a pausa
            bttnStart.Text = "Pausar";
        }

        private void btnCronometro_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            mode = true;

            lcent.Sincronizar(0);
            lseg.Sincronizar(0);
            lmin.Sincronizar(0);
            lhor.Sincronizar(0);

            ActualizarLabel();
            timer1.Start();
        }
        

        private void btnTemporizador_Click(object sender, EventArgs e)
        {
            try
            {
                int totalSegundos = int.Parse(txtTiempo.Text);

                timer1.Stop();
                mode = false;

                int horas = totalSegundos / 3600;
                int minutos = (totalSegundos % 3600) / 60;
                int segundos = totalSegundos % 60;

                lhor.Sincronizar(horas);
                lmin.Sincronizar(minutos);
                lseg.Sincronizar(segundos);
                lcent.Sincronizar(0);

                ActualizarLabel();
                timer1.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Debe ingresar un valor válido");
            }
        }

        private void lblHora_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
