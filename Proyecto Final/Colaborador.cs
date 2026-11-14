using System.Drawing;

namespace Shalom
{
    // Datos de un integrante del equipo, para mostrar en las cards.
    public class Colaborador
    {
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Codigo { get; set; }
        public string Carrera { get; set; }
        public Image Foto { get; set; }        // null = todavía sin foto
        public string LinkedIn { get; set; }   // null = no tiene
        public string GitHub { get; set; }

        public Colaborador(string nombre, string rol, string codigo, string carrera,
                   string linkedIn = null, string gitHub = null)
        {
            Nombre = nombre; Rol = rol; Codigo = codigo; Carrera = carrera;
            LinkedIn = linkedIn; GitHub = gitHub;
        }

        public static Colaborador[] ObtenerEquipo()
        {
            return new Colaborador[]
            {
                new Colaborador("Alfonso David Moscoso Yparraguirre", "Desarrollador",  "N00574312", "Ingeniería de Software"),
                new Colaborador("Anshely Aznaila Quezada Prado",      "Desarrolladora", "N00474619", "Ingeniería de Software"),
                new Colaborador("Estrella Valeria Castañeda Rivas",   "Desarrolladora", "N00480736", "Ingeniería de Sistemas"),
                new Colaborador("Sergio Isaac Colán Sánchez",         "Desarrollador",  "N00525394", "Ingeniería de Redes y Sistemas",
                                "https://www.linkedin.com/in/sergiocolansanchez/", "https://github.com/sergiocolsati-create"),
                new Colaborador("Yanela Liz Acori Sanchez",           "Desarrolladora", "N00469214", "Ingeniería de Software",
                                "https://www.linkedin.com/in/yanela-acori-sanchez-7451983a6/", "https://github.com/yanlogic")
            };
        }

        // Busca a un integrante por su código de alumno.
        public static Colaborador Buscar(string codigo)
        {
            foreach (Colaborador c in ObtenerEquipo())
            {
                if (c.Codigo == codigo)
                    return c;
            }
            return null;
        }
    }
}
