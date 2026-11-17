using System;
using System.Drawing;
using System.Windows.Forms;

namespace Shalom
{
    // Ventana con TODO el equipo a la vez: una card pequeña por integrante.
    // Al hacer clic en una, se abre su card completa (TarjetaColaborador) con sus links.
    public partial class Colaboradores : Form
    {
        private readonly Color rojo = Color.FromArgb(238, 42, 47);

        public Colaboradores()
        {
            InitializeComponent();

            foreach (Colaborador c in Colaborador.ObtenerEquipo())
                flpEquipo.Controls.Add(CrearCard(c));
        }

        // Card pequeña: franja roja, foto, nombre, rol y "Ver perfil"
        private Panel CrearCard(Colaborador c)
        {
            Panel card = new Panel();
            card.Size = new Size(196, 262);
            card.Margin = new Padding(8);
            card.BackColor = Color.White;
            card.Cursor = Cursors.Hand;

            Panel franja = new Panel();
            franja.Dock = DockStyle.Top;
            franja.Height = 6;
            franja.BackColor = rojo;

            PictureBox foto = new PictureBox();
            foto.Bounds = new Rectangle(38, 22, 120, 120);
            foto.SizeMode = PictureBoxSizeMode.Zoom;
            foto.BackColor = Color.FromArgb(238, 239, 241);   // Gris si no tiene foto
            foto.Image = c.Foto;

            Label nombre = new Label();
            nombre.Bounds = new Rectangle(8, 150, 180, 44);
            nombre.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            nombre.TextAlign = ContentAlignment.TopCenter;
            nombre.Text = c.Nombre;

            Label rol = new Label();
            rol.Bounds = new Rectangle(8, 196, 180, 20);
            rol.Font = new Font("Segoe UI", 9f);
            rol.ForeColor = rojo;
            rol.TextAlign = ContentAlignment.MiddleCenter;
            rol.Text = c.Rol;

            Label ver = new Label();
            ver.Bounds = new Rectangle(8, 228, 180, 20);
            ver.Font = new Font("Segoe UI", 8.25f, FontStyle.Underline);
            ver.ForeColor = Color.Gray;
            ver.TextAlign = ContentAlignment.MiddleCenter;
            ver.Text = "Ver perfil";

            card.Controls.Add(franja);
            card.Controls.Add(foto);
            card.Controls.Add(nombre);
            card.Controls.Add(rol);
            card.Controls.Add(ver);

            // Clic en cualquier parte de la card → abre la card completa de esa persona
            EventHandler abrir = (s, e) => TarjetaColaborador.Abrir(c.Codigo, this);
            card.Click += abrir;
            foreach (Control parte in card.Controls)
                parte.Click += abrir;

            return card;
        }
    }
}