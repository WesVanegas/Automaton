﻿using System;
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
using System.Windows.Markup;
using static System.Windows.Forms.AxHost;

namespace Automaton
{
    public partial class Form1 : Form
    {

        private void ShowTextinLog(string text)
        {
            //txtLog.Text += text + Environment.NewLine;
            var timestamp = DateTime.Now.ToString("HH:mm:ss");
            txtLog.Text += $"{timestamp}: {text}{Environment.NewLine}";
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

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
                    //MessageBox.Show($"Simbolo {symbol} ya existe!");
                    ShowTextinLog($"Simbolo {symbol} ya existe!");
                }
                else
                {
                    // Si no existe, se agrega al automata
                    dictSymbols.Add(symbol);
                    //MessageBox.Show($"Símbolos: {string.Join(", ", (List<string>)dict["symbols"])}");
                    ShowTextinLog($"Se agregó símbolo: {symbol}");
                    ShowTextinLog($"Símbolos: {string.Join(", ", (List<string>)dict["symbols"])}");
                    
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
                    //MessageBox.Show($"Estado {state} ya existe!");
                    ShowTextinLog($"Estado: {state} ya existe!");
                }
                else
                {
                    // Si no existe, se agrega al automata
                    dictStates.Add(state);
                    //MessageBox.Show($"Estados: {string.Join(", ", (List<string>)dict["states"])}");
                    ShowTextinLog($"Se agregó estado: {state}");
                    ShowTextinLog($"Estados: {string.Join(", ", (List<string>)dict["states"])}");
                }
            }
        }

        // Add initial state function

        private void AddInitialState(Dictionary<string, object> dict, string state)
        {
            state = state.Trim();
            //MessageBox.Show($"State: |{state}|");

            //Referencia a los estados y el estado inicial
            var dictStates = (List<string>)dict["states"];
            var dictInitialState = (List<string>)dict["initialState"];

            // Validar que el estado inicial se encuentre en los estados
            if (dictStates.Contains(state))
            {
                // Validar que no haya un estado inicial ya definido
                if (dictInitialState.Count() == 0)
                {
                    // Agregar estado inicial
                    dictInitialState.Add(state);

                    // Poner en primera posición el estado inical para facilitar la grafica
                    //MessageBox.Show($"Before State: {string.Join(",", dictStates)}");
                    int index = dictStates.IndexOf(state);
                    if (index != 0)
                    {
                        dictStates.RemoveAt(index);
                        dictStates.Insert(0, state);
                    }
                    //MessageBox.Show($"After State: {string.Join(",", dictStates)}");
                }
                else
                {
                    MessageBox.Show($"Ya hay definido un estado inicial: {dictInitialState[0]}");
                }
            }
            else
            {
                //MessageBox.Show($"Estado {state} no existe!");
                ShowTextinLog($"Estado {state} no existe!");
            }
        }


        // Add Acceptance States function
        private void AddAcceptanceStates(Dictionary<string, object> dict, string states)
        {
            string[] newAcceptanceStates = states.Split(new char[] { ' ', ',', '.', '-' }, StringSplitOptions.RemoveEmptyEntries);

            // Referencia a los estados de acceptación
            var dictAcceptanceStates = (List<string>)dict["acceptanceStates"];
            var dictStates = (List<string>)dict["states"];

            foreach (var state in newAcceptanceStates)
            {
                // Validar que el estado exista y no se encuentre en AcceptanceStates
                if (dictStates.Contains(state) & !dictAcceptanceStates.Contains(state))
                {
                    dictAcceptanceStates.Add(state);
                    //MessageBox.Show($"Se agregó estado de aceptación {state}");
                    ShowTextinLog($"Se agregó estado de aceptación {state}");
                }
                else
                {
                    //MessageBox.Show($"No se pudo agregar estado {state}\nNo existe como estado o ya se encuentra en los estados que aceptan.");
                    ShowTextinLog($"No se agregó estado de aceptación: {state}");
                }
            }

        }

        // Add Transitions function

        private void AddTransitions(Dictionary<string, object> dict, string origin, string symbol, string destination)
        {
            // Quitar espacios de los extremos
            origin = origin.Trim();
            symbol = symbol.Trim();
            destination = destination.Trim();

            // Referencias a los estados y los símbolos
            var dictStates = (List<string>)dict["states"];
            var dictSymbols = (List<string>)dict["symbols"];

            // Referencia a las transiciones {Key=(state, symbol): Value}
            var dictTransitions = (Dictionary<(string state, string symbol), List<string>>)dict["transitions"];

            // Validar que los estados ingresados (origin, destination) y el símbolo (symbol) existan en el automata.
            bool validation = dictSymbols.Contains(symbol) && dictStates.Contains(origin) && dictStates.Contains(destination);

            if (validation)
            {
                // Revisar si ya existe la transición con el estado y simbolo ingresado
                if (dictTransitions.ContainsKey((origin, symbol)))
                {
                    // Verificar que para los valores ingresados no existe el destino
                    if (!dictTransitions[(origin, symbol)].Contains(destination))
                    {
                        // Agregar nuevo destino
                        dictTransitions[(origin, symbol)].Add(destination);
                        //MessageBox.Show($"Transición ({origin},{symbol})={destination} Agregada!");
                        ShowTextinLog($"Transición ({origin},{symbol})={destination} Agregada!");
                    }
                    else
                    {
                        //MessageBox.Show($"Transición ({origin},{symbol})={destination} Ya existe!\n No se puede agregar nuevamente.");
                        ShowTextinLog($"Transición ({origin},{symbol})={destination} Ya existe!");
                    }

                }
                else
                {
                    // Si no existe la transición con el estado y simbolo ingresado, se agrega al automata
                    dictTransitions.Add((origin, symbol), new List<string> { destination });
                    //MessageBox.Show($"Transición ({origin},{symbol})={destination} Agregada!");
                    ShowTextinLog($"Transición ({origin},{symbol})={destination} Agregada!");
                }
            }
            else
            {
                //MessageBox.Show($"Transición ({origin},{symbol})={destination} no agregada!\nRevisar valores ingresados");
                ShowTextinLog($"Transición: ({origin},{symbol})={destination} no agregada!");
            }

        }


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
       


        // Show automaton data
        private void ShowAutomaton(Dictionary<string, object> dict)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in dict)
            {
                sb.AppendLine($"{item.Key}: {ValueConverter(item.Value)}");
            }

            MessageBox.Show(sb.ToString(), "Contenido del automata");
        }

        private static string ValueConverter(object value)
        {
            if (value is List<string> list)
            {
                return string.Join(", ", list);
            }
            else if (value is Dictionary<(string, string), List<string>> transitions)
            {
                var sb = new StringBuilder();
                foreach (var transition in transitions)
                {
                    sb.AppendLine($"({transition.Key.Item1}, {transition.Key.Item2}): {string.Join(", ", transition.Value)}");
                }
                return sb.ToString();
            }
            return Convert.ToString(value);
        }

        // Clean Dict function
        private void CleanAutomaton(Dictionary<string, object> dict)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                pictureBox1.Update();
            }
            
            //Referencias a cada llave del diccionarion
            var dictSymbols = (List<string>)dict["symbols"];
            var dictStates = (List<string>)dict["states"];
            var dictInitialState = (List<string>)dict["initialState"];
            var dictAcceptanceStates = (List<string>)dict["acceptanceStates"];
            var dictTransitions = (Dictionary<(string, string), List<string>>)dict["transitions"];

            if (File.Exists("automato.dot"))
            {
                File.Delete("automato.dot");
            }
            

            if (File.Exists("automato.png"))
            {
                File.Delete("automato.png");
            }

            // Borrar el contenido
            dictSymbols.Clear();
            dictStates.Clear();
            dictInitialState.Clear();
            dictAcceptanceStates.Clear();
            dictTransitions.Clear();
            ShowTextinLog("Se borraron los datos del automata.");
        }



        // Create graphic from Dot file
        private void GraphicAutomaton(Dictionary<string, object> dict)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                pictureBox1.Update();
            }
            
            if (File.Exists("automato.png"))
            {
                File.Delete("automato.png");
            }
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
                // La siguiente línea es para que el diagrama sea horizontal
		        //writer.WriteLine("rankdir=LR;");
                if (initialState.Count == 1)
                {
                    writer.WriteLine(" Inicio [shape=none];");
                }
                

                foreach (var item in (List<string>)dict["states"])
                {
                    string shape = acceptanceStatesList.Contains(item) ? "doublecircle": "circle";

                    writer.WriteLine($" {item} [shape={shape}];");
                }
                //var initial = initialState.Count()==0 ? "empty" : $"{initialState[0]}";
                if (initialState.Count() != 0)
                {
                    writer.WriteLine($" Inicio -> {initialState[0]};");
                }
                else
                {
                    MessageBox.Show("Automata sin suficientes datos para graficar.");
                    ShowTextinLog("Faltan datos. Se debe indicar cual es el estado inicial.");
                }

                foreach (var transition in transitions)
                {
                    foreach (var item in transition.Value)
                    {
                        writer.WriteLine($" {transition.Key.state} -> {item} [label = \"{transition.Key.symbol}\"];");                    
                    }
                }
                writer.WriteLine("}");
            }
            //MessageBox.Show("Archivo Dot generado");

            if (initialState.Count == 1)
            {
                if (isNFA(dict))
                {
                    MessageBox.Show("El automata es Finito NO Determinista (NFA)");
                }
                else
                {
                    MessageBox.Show("El automata es Finito Determinista (DFA)");
                }
            }

            // Graficar con Graphviz usando el archivo Dot como referencia

            // variable que contiene la ruta a dot.exe en la carpte Graphviz
            //string graphvizPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Graphviz", "bin", "dot.exe");
            string graphvizPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Graphviz", "bin", "dot.exe");

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

            if (!System.IO.File.Exists(graphvizPath))
            {
                //MessageBox.Show($"El archivo dot.exe no se encuentra en la ruta: {graphvizPath}");
                ShowTextinLog($"El archivo dot.exe no se encuentra en la ruta: {graphvizPath}");
            }

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
            
            GraphicAutomaton(automaton);
        }

        private void btnAddInitialState_Click(object sender, EventArgs e)
        {
            string initialState = txtInitialState.Text;
            AddInitialState(automaton, initialState);
        }

        private void btnAcceptanceStates_Click(object sender, EventArgs e)
        {
            string acceptanceStates = txtAcceptanceStates.Text;
            AddAcceptanceStates(automaton, acceptanceStates);
        }

        private void btnAddTransition_Click(object sender, EventArgs e)
        {
            string origin = txtOrigin.Text;
            string symbol = txtSymbol.Text;
            string destination = txtDestination.Text;

            AddTransitions(automaton, origin, symbol, destination);
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = null;
            txtSymbols.Clear();
            txtStates.Clear();
            txtInitialState.Clear();
            txtAcceptanceStates.Clear();
            txtOrigin.Clear();
            txtSymbol.Clear();
            txtDestination.Clear();
            CleanAutomaton(automaton);
        }

        private void btnViewAutomaton_Click(object sender, EventArgs e)
        {
            ShowAutomaton(automaton);
        }
    }
}
