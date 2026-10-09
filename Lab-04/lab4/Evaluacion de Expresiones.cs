using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Evaluacion_de_Expresiones : Form
    {
        private List<string> pasos = new List<string>();  // lista donde guardo los pasos para mostrarlos al final
        public Evaluacion_de_Expresiones()
        {
            InitializeComponent();
        }

        private void Evaluacion_de_Expresiones_Load(object sender, EventArgs e)
        {

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            pasos.Clear(); // borra los pasos de la vez anterior
            lstEval.Items.Clear();// limpia el ListBox
            txtNota.Text = "-"; // deja la postfija en blanco
            txtRess.Text = "-"; // deja el resultado en blanco

            string[] simbolos = SepararSimbolos(txtExpresion.Text); // corta lo escrito en piezas: números, operadores, paréntesis

            if (simbolos.Length == 0)  // si no escribió nada
            {
                MessageBox.Show("Ingrese una expresión");
                return;  // sale del método
            }

            // 1) Infija -> Postfija
            List<string> postfija = InfijaAPostfija(simbolos); // convierte; devuelve null si los paréntesis están mal

            if (postfija == null) // paréntesis mal puestos
            {
                MessageBox.Show("Los paréntesis no están bien cerrados");
            }
            else
            {
                txtNota.Text = string.Join(" ", postfija); // muestra la postfija, ej: 2 3 + 4 *

                // 2) Evaluar la postfija
                double resultado;  // aquí se guardará la respuesta
                if (Evaluar(postfija, out resultado))  // devuelve true si pudo calcular
                {
                    txtRess.Text = resultado.ToString();  // muestra el resultado
                }
                else
                {
                    MessageBox.Show("La expresión no es válida");
                }
            }

            lstEval.Items.AddRange(pasos.ToArray()); // muestra todos los pasos en el ListBox
        }

        
        private string[] SepararSimbolos(string texto) // MÉTODO 2: corta el texto en piezas, ej: "(2+3)*4" -> ( 2 + 3 ) * 4
        {
            foreach (char s in "+-*/()")  // recorre cada operador y paréntesis
            {
                texto = texto.Replace(s.ToString(), " " + s + " "); // le pone espacios a los lados para poder separarlo
            }

            return texto.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // corta por espacios y descarta los vacíos
        }

        private int Precedencia(char op)  // MÉTODO 3: dice qué operador manda más
        {
            if (op == '*' || op == '/') return 2; // * y / se hacen primero
            if (op == '+' || op == '-') return 1; // + y - después
            return 0; // '(' queda en 0 para que nunca se saque por precedencia
        }

        private bool EsOperador(string simbolo)  // MÉTODO 4: responde si el símbolo es + - * /
        {
            return simbolo.Length == 1 && "+-*/".IndexOf(simbolo[0]) >= 0; // true si es un solo carácter y está en "+-*/"
        }

        
        private List<string> InfijaAPostfija(string[] simbolos) // MÉTODO 5: convierte infija a postfija (usa una pila)
        {
            pasos.Add("=== INFIJA A POSTFIJA ===");

            List<string> salida = new List<string>(); // aquí se va armando la postfija
            Pila<char> pila = new Pila<char>();  // pila donde esperan los operadores

            foreach (string s in simbolos) // revisa cada pieza, de izquierda a derecha
            {
                if (EsOperador(s))  // CASO 1: es un operador
                {
                    char op = s[0]; // lo paso a char para la pila


                    while (!pila.isEmpty() && Precedencia(pila.Top()) >= Precedencia(op))  // mientras la cima mande igual o más que el nuevo (Top e isEmpty son de Pila)
                    {
                        char sacado = pila.pop(); // saco el de la cima (pop es de Pila)
                        salida.Add(sacado.ToString());  // lo mando a la salida
                        pasos.Add("Operador '" + op + "': saco '" + sacado + "' hacia la salida");  // anoto el paso
                    }

                    pila.push(op);// ahora guardo el nuevo operador en la pila (push es de Pila)
                    pasos.Add("Operador '" + op + "': push a la pila");  // anoto el paso
                }
                else if (s == "(")  // CASO 2: paréntesis que abre
                {
                    pila.push('(');
                    pasos.Add("'(': push a la pila");
                }
                else if (s == ")")  // CASO 3: paréntesis que cierra
                {
                    while (!pila.isEmpty() && pila.Top() != '(')  // saco todo hasta encontrar el '('
                    {
                        char sacado = pila.pop(); // saco un operador
                        salida.Add(sacado.ToString()); // lo mando a la salida
                        pasos.Add("')': saco '" + sacado + "' hacia la salida");  // anoto el paso
                    }

                    if (pila.isEmpty())  // si la pila se vació, nunca hubo '('
                    {
                        return null; // error: hay un ')' de más
                    }

                    pila.pop(); // saco el '(' y lo descarto (los paréntesis no van en la postfija)
                    pasos.Add("')': descarto el '(' de la pila");  // anoto el paso
                }
                else  // CASO 4: es un número
                {
                    salida.Add(s);   // los números van directo a la salida
                    pasos.Add("Número " + s + ": va directo a la salida");  // anoto el paso
                }
            }

            while (!pila.isEmpty())  // al terminar, vacío lo que quedó en la pila
            {
                char sacado = pila.pop();   // saco el de la cima

                if (sacado == '(')  // si quedó un '(' sin cerrar
                {
                    return null; // había un '(' sin su ')'
                }

                salida.Add(sacado.ToString()); // lo mando a la salida
                pasos.Add("Fin: saco '" + sacado + "' hacia la salida"); // anoto el paso
            }

            return salida;  // devuelve la postfija lista
        }

      
        private bool Evaluar(List<string> postfija, out double resultado)  // MÉTODO 6: calcula la postfija (usa otra pila). Devuelve true si salió bien
        {
            pasos.Add("");  // línea en blanco para separar 
            pasos.Add("=== EVALUACIÓN DE LA POSTFIJA ==="); // título para el ListBox

            resultado = 0;
            Pila<double> pila = new Pila<double>(); // pila donde guardo los números

            foreach (string s in postfija) // revisa cada pieza de la postfija
            {
                if (EsOperador(s))   // si es operador, hay que calcular
                {
                    if (pila.isEmpty()) return false;  // si no hay número para sacar, la expresión está mal
                    double b = pila.pop(); // saco el segundo número (sale primero el de arriba)

                    if (pila.isEmpty()) return false;  // si no hay un segundo número, está mal
                    double a = pila.pop();  // saco el primer número

                    if (s == "/" && b == 0) return false; // no se puede dividir entre cero

                    double r = Calcular(a, b, s[0]);  // hago la operación a (operador) b
                    pila.push(r);  // guardo el resultado en la pila para seguir usándolo
                    pasos.Add(a + " " + s + " " + b + " = " + r + "  (push " + r + ")");   // anoto el paso
                }
                else // si no es operador, es un número
                {
                    double valor; // aquí se guarda el número convertido
                    if (!double.TryParse(s, out valor)) return false;  // convierte texto a número; si no puede, la expresión está mal

                    pila.push(valor);  // lo guardo en la pila
                    pasos.Add("Número " + s + ": push a la pila"); // anoto el paso
                }
            }

            if (pila.isEmpty()) return false;  // si no quedó nada, no había expresión

            resultado = pila.pop(); // lo último que queda en la pila es la respuesta
            pasos.Add("Resultado final: " + resultado);  // anoto el resultado

            return pila.isEmpty(); // si sobra algo, faltaban operadores
        }

        private double Calcular(double a, double b, char op) // MÉTODO 7: hace la operación entre dos números
        {
            if (op == '+') return a + b;
            if (op == '-') return a - b;
            if (op == '*') return a * b;
            return a / b;
        }

    }
    }

