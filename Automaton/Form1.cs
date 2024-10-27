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
            string[] newSymbols = symbols.Split(new char[] { ' ', ',', '.', '-' }, StringSplitOptions.RemoveEmptyEntries);

            //Referencia a la lista de simbolos en el diccionario
            var dictSymbols = (List<string>)dict["symbols"];

            foreach (string symbol in newSymbols)
            {

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
                    cboSymbol.Items.Add(symbol);
                    //MessageBox.Show($"Símbolos: {string.Join(", ", (List<string>)dict["symbols"])}");
                    ShowTextinLog($"Symbol added: {symbol}");
                    ShowTextinLog($"Symbols: {string.Join(", ", (List<string>)dict["symbols"])}");

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
                    ShowTextinLog($"State: {state} already exists!");
                }
                else
                {
                    // Si no existe, se agrega al automata
                    dictStates.Add(state);
                    cboOrigin.Items.Add(state);
                    cboDestination.Items.Add(state);
                    //MessageBox.Show($"Estados: {string.Join(", ", (List<string>)dict["states"])}");
                    ShowTextinLog($"State was added: {state}");
                    ShowTextinLog($"States: {string.Join(", ", (List<string>)dict["states"])}");
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
                    ShowTextinLog($"Initial state was added: {state}");

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
                    MessageBox.Show($"There is already a initial state: {dictInitialState[0]}");
                }
            }
            else
            {
                //MessageBox.Show($"Estado {state} no existe!");
                ShowTextinLog($"State {state} does not exist!");
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
                    ShowTextinLog($"Acceptance state added: {state}");
                }
                else
                {
                    //MessageBox.Show($"No se pudo agregar estado {state}\nNo existe como estado o ya se encuentra en los estados que aceptan.");
                    ShowTextinLog($"No acceptance state added: {state}");
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
                        ShowTextinLog($"Transition ({origin},{symbol})={destination} added!");
                    }
                    else
                    {
                        //MessageBox.Show($"Transición ({origin},{symbol})={destination} Ya existe!\n No se puede agregar nuevamente.");
                        ShowTextinLog($"Transition ({origin},{symbol})={destination} already exist!");
                    }

                }
                else
                {
                    // Si no existe la transición con el estado y simbolo ingresado, se agrega al automata
                    dictTransitions.Add((origin, symbol), new List<string> { destination });
                    //MessageBox.Show($"Transición ({origin},{symbol})={destination} Agregada!");
                    ShowTextinLog($"Transition ({origin},{symbol})={destination} added!");
                }
            }
            else
            {
                //MessageBox.Show($"Transición ({origin},{symbol})={destination} no agregada!\nRevisar valores ingresados");
                ShowTextinLog($"Transition: ({origin},{symbol})={destination} was not added!");
            }

        }

        private bool ValidateAutomatonContent(Dictionary<string, object> dict)
        {
            var dictAcceptanceStates = (List<string>)dict["acceptanceStates"];
            var dictInitialState = (List<string>)dict["initialState"];
            var dictSymbols = (List<string>)dict["symbols"];

            if (dictAcceptanceStates.Count() != 0 && dictInitialState.Count != 0 && dictSymbols.Count() != 0)
            {
                return true;
            }
            return false;
        }



        // Validate type of automaton function
        // Nondeterministic finite automaton (NFA)
        // Deterministic finite automaton (DFA)

        static bool IsNFA(Dictionary<string, object> dict)
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

            MessageBox.Show(sb.ToString(), "Automaton");
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
            ShowTextinLog("The data on the automaton has been erased.");
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

            if (File.Exists("automato.dot"))
            {
                File.Delete("automato.dot");
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

                writer.WriteLine(" Inicio [shape=none];");



                foreach (var item in (List<string>)dict["states"])
                {
                    string shape = acceptanceStatesList.Contains(item) ? "doublecircle" : "circle";

                    writer.WriteLine($" {item} [shape={shape}];");
                }
                //var initial = initialState.Count()==0 ? "empty" : $"{initialState[0]}";

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
            //MessageBox.Show("Archivo Dot generado");


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
                ShowTextinLog($"The dot.exe file is not located in the path: {graphvizPath}");
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
                    ShowTextinLog("Automaton was graphed");
                }
                else
                {
                    MessageBox.Show("Error, the image was not found.");
                }
            }

        }




        private Dictionary<string, object> automaton;
        private Dictionary<string, object> automatonCopy;

        public Form1()
        {
            InitializeComponent();

            automaton = new Dictionary<string, object>
            {
                {"symbols", new List<string> { "1", "0" }},
                {"states", new List<string> { "a", "b", "c"}},
                {"initialState", new List<string> { "a" } },
                {"acceptanceStates", new List<string> { "b" }},
                {"transitions", new Dictionary<(string state, string symbol), List<string>>
                    {
                            { ("a", "1"), new List<string>{"b"} },
                       //{ ("a", "0"), new List<string>{"b"} },
                        { ("b", "0"), new List<string>{"a", "b"} },
                        { ("b", "1"), new List<string>{"c"} },
                        { ("c", "0"), new List<string>{"a"} },
                        { ("c", "1"), new List<string>{"b"} },

                    }
                }
            };

        }

        private void btnAddsymbols_Click(object sender, EventArgs e)
        {
            string symbols = txtSymbols.Text;
            AddSymbols(automaton, symbols);
            txtSymbols.Clear();
        }

        private void btnAddStates_Click(object sender, EventArgs e)
        {
            string states = txtStates.Text;
            AddStates(automaton, states);
            txtStates.Clear();
        }
        private Dictionary<string, object> DeepCopyAutomaton(Dictionary<string, object> original)
        {
            var copy = new Dictionary<string, object>();

            foreach (var entry in original)
            {
                if (entry.Value is List<string>)
                {
                    copy[entry.Key] = new List<string>((List<string>)entry.Value);
                }
                else if (entry.Value is Dictionary<string, string>)
                {
                    copy[entry.Key] = new Dictionary<string, string>((Dictionary<string, string>)entry.Value);
                }
                else
                {
                    copy[entry.Key] = entry.Value;
                }
            }

            return copy;
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            if (ValidateAutomatonContent(automaton))
            {
                automatonCopy = DeepCopyAutomaton(automaton);
                if (IsNFA(automaton))
                {
                    MessageBox.Show("The introduced automaton is Finite NOT Deterministic (NFA)");
                    ConvertToDeterministic(automaton);
                    ShowTextinLog("Automaton was converted to Finite Deterministic (DFA)");

                }
                else
                {
                    MessageBox.Show("The introduced automaton is Finite Deterministic (DFA)");
                }
                GraphicAutomaton(automaton);

                btnModify.Enabled = true;
                btnGraph.Enabled = false;
                btnAddTransition.Enabled = false;
                btnAddStates.Enabled = false;
                btnAddsymbols.Enabled = false;
                btnAddInitialState.Enabled = false;
                btnAcceptanceStates.Enabled = false;
                btnRemoveAcceptanceStates.Enabled = false;
                btnRemoveStates.Enabled = false;
                btnRemoveSymbols.Enabled = false;
                btnRemoveInitialState.Enabled = false;
            }
            else
            {
                MessageBox.Show("Automaton without enough data to graph");
                ShowTextinLog("Data is missing, automaton was no graphed.");
            }

        }

        private void ConvertToDeterministic(Dictionary<string, object> dict)
        {
            // Referencia a las transiciones {Key=(state, symbol): Value}
            var transitions = (Dictionary<(string state, string symbol), List<string>>)dict["transitions"];
            var states = (List<string>)dict["states"];
            var symbols = (List<string>)dict["symbols"];
            var newTransitions = new Dictionary<(string state, string symbol), List<string>>();
            var newAcceptanceStateList = new List<string>();

            CreateInitialTransition(dict, transitions, newTransitions);

            //Empezar a partir de los demas estados, rellenar transiciones

            while (newTransitions.Any(tr => tr.Value == null || tr.Value.Count == 0))
            {
                foreach (var tr in newTransitions.ToList())
                {
                    //Si la transición no tiene destino, buscar si existe en la transición vieja para asignarle el estado
                    if (tr.Value == null || tr.Value.Count == 0)
                    {
                        AddDestination(dict, newAcceptanceStateList, newTransitions, transitions, tr, symbols);
                    }
                    var newTr = newTransitions[tr.Key];

                    //Crear siguientes transiciones
                    CreateTransitionByDestination(newTransitions, symbols, newTr);
                }

            }
            List<string> newStates = newTransitions
             .Select(t => t.Key.state)
             .Distinct() // Elimina duplicados
             .ToList();
            automaton["states"] = newStates;
            automaton["acceptanceStates"] = newAcceptanceStateList;
            automaton["transitions"] = newTransitions;

        }

        private void AddDestination(Dictionary<string, object> dict, List<string> newAcceptanceStatesList, Dictionary<(string state, string symbol), List<string>> newTransitions, Dictionary<(string state, string symbol), List<string>> transitions, KeyValuePair<(string state, string symbol), List<string>> tr, List<string> symbols)
        {
            if (tr.Key.state.Count() > 1 && tr.Key.state != "Error")
            {
                var states = new List<string>();
                var valuesCompleted = new List<string>();
                foreach (var state in tr.Key.state)
                {
                    states.Add(state.ToString());
                }

                //Hay que buscar por cada estado, su destino
                foreach (var item in states)
                {
                    var symbol = tr.Key.symbol;
                    var values = transitions.Where(x => x.Key == (item, symbol)).SelectMany(x => x.Value).Distinct().ToList();
                    foreach (var item1 in values)
                    {
                        valuesCompleted.Add(item1);

                    }
                }

                valuesCompleted = valuesCompleted.Distinct().ToList();
                valuesCompleted.Sort(StringComparer.Ordinal);
                if (valuesCompleted.Count > 1)
                {
                    var concatenatedValues = string.Join("", valuesCompleted);
                    newTransitions[tr.Key] = new List<string> { concatenatedValues };
                    //Validar si el estado asignado coincide con el o los estados viejos para reasignar
                    ValidateAcceptanceState(dict, valuesCompleted, tr.Key.state, newAcceptanceStatesList);

                }
                else if (valuesCompleted.Count == 1)
                {
                    newTransitions[tr.Key] = valuesCompleted;
                    ValidateAcceptanceState(dict, valuesCompleted, tr.Key.state, newAcceptanceStatesList);

                }
                else
                {
                    newTransitions[tr.Key] = new List<string> { "Error" };
                }

            }
            else
            {
                if (transitions.Keys.Contains(tr.Key))
                {
                    var values = transitions.Where(x => x.Key == tr.Key).SelectMany(x => x.Value).Distinct().ToList();
                    values.Sort(StringComparer.Ordinal);
                    if (values.Count > 1)
                    {
                        var concatenatedValues = string.Join("", values);
                        newTransitions[tr.Key] = new List<string> { concatenatedValues };
                        ValidateAcceptanceState(dict, values, tr.Key.state, newAcceptanceStatesList);

                    }
                    else
                    {
                        newTransitions[tr.Key] = values;
                        ValidateAcceptanceState(dict, values, tr.Key.state, newAcceptanceStatesList);

                    }
                }
                else
                {
                    //Si no hay estado que coincida con la key, añadir error como destino
                    newTransitions[tr.Key] = new List<string> { "Error" };
                }
            }
        }

        private void ValidateAcceptanceState(Dictionary<string, object> dict, List<string> values, string symbol, List<string> newAcceptanceStatesList)
        {
            var oldAcceptanceStateList = (List<string>)dict["acceptanceStates"];
            if (values.Any(numero => oldAcceptanceStateList.Contains(numero)))
            {
                var concatenatedValues = string.Join("", values);
                newAcceptanceStatesList.Add(concatenatedValues);
            }
            else if (oldAcceptanceStateList.Contains(symbol))
            {
                newAcceptanceStatesList.Add(symbol);
            }
        }
        private void CreateTransitionByDestination(Dictionary<(string state, string symbol), List<string>> newTransitions, List<string> symbols, List<string> tr)
        {
            if (tr != null)
            {
                var destination = tr[0];
                if (tr.Count() > 1)
                {
                    destination = string.Join("", tr);
                }
                foreach (var symbol in symbols)
                {
                    if (!newTransitions.Keys.Contains((destination, symbol)))
                    {
                        newTransitions.Add((destination, symbol), new List<string>());
                    }
                }
            }
        }

        private void CreateInitialTransition(Dictionary<string, object> dict, Dictionary<(string state, string symbol), List<string>> transitions, Dictionary<(string state, string symbol), List<string>> newTransitions)
        {
            var initialState = (List<string>)dict["initialState"];
            var keys = transitions.Keys.Select(x => x.state).ToArray();
            var initialStateTransitions = transitions.Where(x => x.Key.state == initialState[0]);
            foreach (var tr in initialStateTransitions)
            {
                if (tr.Key.state != null && tr.Key.symbol != null)
                {
                    newTransitions.Add(tr.Key, new List<string>());
                }
            }

        }

        private void btnAddInitialState_Click(object sender, EventArgs e)
        {
            string initialState = txtInitialState.Text;
            AddInitialState(automaton, initialState);
            txtInitialState.Clear();
        }

        private void btnAcceptanceStates_Click(object sender, EventArgs e)
        {
            string acceptanceStates = txtAcceptanceStates.Text;
            AddAcceptanceStates(automaton, acceptanceStates);
            txtAcceptanceStates.Clear();
        }

        private void btnAddTransition_Click(object sender, EventArgs e)
        {
            string origin = cboOrigin.Text;
            string symbol = cboSymbol.Text;
            string destination = cboDestination.Text;

            AddTransitions(automaton, origin, symbol, destination);
            cboDestination.Text = "";
            cboOrigin.Text = "";
            cboSymbol.Text = "";
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = null;
            txtSymbols.Clear();
            txtStates.Clear();
            txtInitialState.Clear();
            txtAcceptanceStates.Clear();
            cboOrigin.Items.Clear();
            cboSymbol.Items.Clear();
            cboDestination.Items.Clear();
            btnGraph.Enabled = true;
            btnAddTransition.Enabled = true;
            btnAddStates.Enabled = true;
            btnAddsymbols.Enabled = true;
            btnAddInitialState.Enabled = true;
            btnAcceptanceStates.Enabled = true;
            btnRemoveAcceptanceStates.Enabled = true;
            btnRemoveStates.Enabled = true;
            btnRemoveSymbols.Enabled = true;
            btnRemoveInitialState.Enabled = true;
            btnModify.Enabled = false;
            CleanAutomaton(automaton);
        }

        private void btnViewAutomaton_Click(object sender, EventArgs e)
        {
            ShowAutomaton(automaton);
            /*
            if (IsNFA(automaton))
            {
                ShowTextinLog("Automaton is Finite NOT Deterministic (NFA)");
            }
            else
            {
                ShowTextinLog("Automaton is Finite Deterministic (DFA)");
            }
             */
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            foreach (var state in (List<string>)automaton["states"])
            {
                cboOrigin.Items.Add(state);
                cboDestination.Items.Add(state);
            }

            foreach (var symbol in (List<string>)automaton["symbols"])
            {
                cboSymbol.Items.Add(symbol);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            btnGraph.Enabled = true;
            btnAddTransition.Enabled = true;
            btnAddStates.Enabled = true;
            btnAddsymbols.Enabled = true;
            btnAddInitialState.Enabled = true;
            btnAcceptanceStates.Enabled = true;
            btnRemoveAcceptanceStates.Enabled = true;
            btnRemoveStates.Enabled = true;
            btnRemoveSymbols.Enabled = true;
            btnRemoveInitialState.Enabled = true;

            automaton = automatonCopy;
            ShowTextinLog($"Restored automaton.");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            Label label = new Label();
            label.Text = "Input symbol: En este campo debes ingresar los símbolos de entrada que vas a usar (ej: 1, 0), separados por coma.\n\n" +
                "States: En este campo debes ingresar los estados (ej: A, B, C), separados por coma.\n\n" +
                "Initial State: En este campo debes ingresar el estado inicial para graficar el autómata.\n\n" +
                "States of acceptance: En este campo debes ingresar los estados de aceptación del autómata.\n\n" +
                "Origin: En este campo debes escoger el estado de origen de tu nueva transición.\n\n" +
                "Symbol: En este campo debes escoger el símbolo de entrada para tu estado.\n\n" +
                "Destination: En este campo debes escoger el estado al que se dirige tu transición.\n\n" +
                "Botón Remove: Para eliminar los símbolos, estados o estados de aceptación, si es más de uno debes separarlos con coma (,).\n\n" +
                "Botón Graph: Grafica el autómata.\n\n" +
                "Data: Ver toda la información del autómata.\n\n" +
                "Clean automata: Limpia el autómata.\n\n" +
                "Modify initial automata: Permite hacerle modificaciones al autómata ingresado, NO al que es convertido.";
            label.AutoSize = false;
            label.Size = new System.Drawing.Size(400, 430);
            label.Location = new System.Drawing.Point(10, 10);
            label.BorderStyle = BorderStyle.FixedSingle;
            form.Controls.Add(label);
            form.Size = new System.Drawing.Size(450, 500);

            form.ShowDialog();

        }
    }
}
