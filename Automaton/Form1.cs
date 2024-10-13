using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automaton
{
    public partial class Form1 : Form
    {
        // Add new symbols function
        private void AddSymbols(Dictionary<string, object> dict, string symbols)
        {
            // Quitar espacios y divisiones si es mas de un caracter ingresado
            string[] newSymbols = symbols.Split(new char[] { ' ', ',', '.', '-'}, StringSplitOptions.RemoveEmptyEntries);

            //Referencia a la lista de simbolos en el diccionario
            var dictSymbols = (List<string>)dict["symbols"];

            foreach (string symbol in newSymbols) {

                // Verificar que el o los simbolos ingresados no existan
                if (dictSymbols.Contains(symbol))
                {
                    MessageBox.Show($"Simbolo {symbol} ya existe!");
                }
                else
                {
                    // Si no existe, se agrega al automata
                    dictSymbols.Add(symbol);
                    MessageBox.Show($"Símbolos: {string.Join(", ", (List<string>)dict["symbols"])}");
                }
            }
        }
        // Add new states function
        private void AddStates(Dictionary<string, object> dict, string states)
        {
            // Quitar espacios y divisiones si es mas de un caracter ingresado
            string[] newStates = states.Split(new char[] { ' ', ',', '.', '-' }, StringSplitOptions.RemoveEmptyEntries);
            //Referencia a la lista de simbolos en el diccionario
            var dictStates = (List<string>)dict["states"];
            foreach (string state in newStates) 
            {
                // Verificar que el o los estados ingresadso no existan
                if (dictStates.Contains(state))
                {
                    MessageBox.Show($"Simbolo {state} ya existe!");
                }
                else
                {
                    // Si no existe, se agrega al automata
                    dictStates.Add(state);
                    MessageBox.Show($"Símbolos: {string.Join(", ", (List<string>)dict["states"])}");
                }
            }
        }

        // Add initial state function


        // Add Acceptance States function


        // Add Transitions function


        // Validate type of automaton function
        // Nondeterministic finite automaton (NFA)
        // Deterministic finite automaton (DFA)

        static bool isNFA(Dictionary<string, object> dict)
        {
            // Referencia a las transiciones {Key=(state, symbol): Value}
            var transitions = (Dictionary<(string state, string symbol), List<string>>)dict["transitions"];


            foreach (var transition in transitions)
            {                
                // Verificar si hay más de un destino para la misma transición
                if (transition.Value.Count != 1)
                {
                    // Si hay más de un destino, es no determinista
                    return true;
                }
            }
            // Si no hay transiciones duplicadas, es DFA
            
            
            // Referencia a los simbolos del automata
            var symbols = (List<string>)dict["symbols"];
            // Referencia a los estados del automata
            var states = (List<string>)dict["states"];

            // Recorrer cada estado y guardar los simbolos de transiciones
            // 
            
            foreach (var state in states)
            {
                // Conjunto para los símbolos vistos
                var seenSymbols = new HashSet<string>(); 

                // Recorrer las transiciones
                foreach (var transition in transitions)
                {
                    // Comparar si el estado origen de la transición es igual al estado
                    if (transition.Key.state == state)
                    {
                        // Agregar el símbolo al conjunto
                        seenSymbols.Add(transition.Key.symbol);
                    }
                }

                // Comparamos que la cantidad de símbolos únicos vistos sea igual a la cantidad de símbolos
                if (seenSymbols.Count != symbols.Count)
                {
                    return true; // Es no determinista
                }
            }
            return false;
        }


        // Convert NFA to DFA function


        // Clean Dict function



        // Create graphic from Dot file
        private void GraphicAutomaton(Dictionary<string, object> dict)
        {
            // Crear archivo Dot
            
            // Referencia a los estados de aceptación
            var acceptanceStatesList = (List<string>)dict["acceptanceStates"];

            // Referencia al estado inicial
            var initialState = (List<string>)dict["initialState"];

            // Referencia a las transiciones {Key=(state, symbol): Value}
            var transitions = (Dictionary<(string state, string symbol), List<string>>)dict["transitions"];

            using (StreamWriter writer = new StreamWriter("automato.dot"))
            {
                writer.WriteLine("digraph G {");
                writer.WriteLine(" Inicio [shape=none];");

                foreach (var item in (List<string>)dict["states"])
                {
                    string shape = acceptanceStatesList.Contains(item) ? "doublecircle": "circle";

                    writer.WriteLine($" {item} [shape={shape}];");
                }

                writer.WriteLine($" Inicio -> {initialState[0]};");

                foreach (var transition in transitions)
                {
                    foreach (var item in transition.Value)
                    {
                        writer.WriteLine($" {transition.Key.state} -> {item} [label = \"{transition.Key.symbol}\"];");                    
                    }
                }
                writer.WriteLine("}");
            }
            MessageBox.Show("Archivo Dot generado");

            // Graficar con Graphviz usando el archivo Dot como referencia

            // variable que contiene la ruta a dot.exe en la carpte Graphviz
            string graphvizPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Graphviz", "bin", "dot.exe");

            //MessageBox.Show($"Ruta graphviz: {graphvizPath}");

            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                //Si se tiene instalado graphviz, la línea FileName es la siguiente
                //FileName = "dot",
                FileName = graphvizPath,
                Arguments = "-Tpng automato.dot -o automato.png",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using (Process process = Process.Start(processStartInfo))
            {
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();
                if (!string.IsNullOrEmpty(errors))
                {
                    MessageBox.Show($"Error: {errors}");
                }

                // Comprobar si la imagen fue creada
                if (File.Exists("automato.png"))
                {
                    // Mostrar imagen en el pictureBox
                    pictureBox1.Image = Image.FromFile("automato.png");
                    //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    MessageBox.Show("Error, no se encontró imagen");
                }
            }

        }




        private Dictionary<string, object> automaton;
        public Form1()
        {
            InitializeComponent();

            automaton = new Dictionary<string, object>
            {
                {"symbols", new List<string> { "1", "0" }},
                {"states", new List<string> { "a", "b", "c" }},
                {"initialState", new List<string> { "a" } },
                {"acceptanceStates", new List<string> { "b" }},
                {"transitions", new Dictionary<(string state, string symbol), List<string>>
                    {
                        { ("a", "0"), new List<string>{"b", "c"} },
                        { ("c", "0"), new List<string>{"a"} },
                        { ("c", "1"), new List<string>{"b" } }
                    }
                }
            };

        }

        private void btnAddsymbols_Click(object sender, EventArgs e)
        {
            string symbols = txtSymbols.Text;
            AddSymbols(automaton, symbols);
        }

        private void btnAddStates_Click(object sender, EventArgs e)
        {
            string states = txtStates.Text;
            AddStates(automaton, states);
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            if (isNFA(automaton))
            {
                MessageBox.Show("El automata es Finito NO Determinista (NFA)");
            }
            else
            {
                MessageBox.Show("El automata es Finito Determinista (DFA)");
            }
            GraphicAutomaton(automaton);
        }
    }
}
