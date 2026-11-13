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

        // Todo el equipo, definido UNA sola vez.
        public static Colaborador[] ObtenerEquipo()
        {
            return new Colaborador[]
            {
                new Colaborador
                {
                    Nombre = "Alfonso David Moscoso Yparraguirre",
                    Rol = "Desarrollador",
                    Codigo = "N00574312",
                    Carrera = "Ingeniería de Software"
                },
                new Colaborador
                {
                    Nombre = "Anshely Aznaila Quezada Prado",
                    Rol = "Desarrolladora",
                    Codigo = "N00474619",
                    Carrera = "Ingeniería de Software"
                },
                new Colaborador
                {
                    Nombre = "Estrella Valeria Castañeda Rivas",
                    Rol = "Desarrolladora",
                    Codigo = "N00000000",              // DEMO: reemplazar con su código real
                    Carrera = "Ingeniería de Software"  // DEMO
                },
                new Colaborador
                {
                    Nombre = "Sergio Isaac Colán Sánchez",
                    Rol = "Desarrollador",
                    Codigo = "N00525394",
                    Carrera = "Ingeniería de Redes y Sistemas",
                    LinkedIn = "https://www.linkedin.com/in/sergiocolansanchez/",
                    GitHub = "https://github.com/sergiocolsati-create"
                },
                new Colaborador
                {
                    Nombre = "Yanela Liz Acori Sanchez",
                    Rol = "Desarrolladora",
                    Codigo = "N00469214",
                    Carrera = "Ingeniería de Software",
                    LinkedIn = "https://www.linkedin.com/in/yanela-acori-sanchez-7451983a6/",
                    GitHub = "https://github.com/yanlogic"
                }
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
