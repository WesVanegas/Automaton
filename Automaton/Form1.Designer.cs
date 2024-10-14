namespace Automaton
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSymbols = new System.Windows.Forms.TextBox();
            this.txtAcceptanceStates = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStates = new System.Windows.Forms.TextBox();
            this.txtInitialState = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOrigin = new System.Windows.Forms.TextBox();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddTransition = new System.Windows.Forms.Button();
            this.btnGraph = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddsymbols = new System.Windows.Forms.Button();
            this.btnAddStates = new System.Windows.Forms.Button();
            this.btnAddInitialState = new System.Windows.Forms.Button();
            this.btnAcceptanceStates = new System.Windows.Forms.Button();
            this.btnViewAutomaton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Símbolos entrada";
            // 
            // txtSymbols
            // 
            this.txtSymbols.Location = new System.Drawing.Point(179, 31);
            this.txtSymbols.Name = "txtSymbols";
            this.txtSymbols.Size = new System.Drawing.Size(100, 20);
            this.txtSymbols.TabIndex = 1;
            // 
            // txtAcceptanceStates
            // 
            this.txtAcceptanceStates.Location = new System.Drawing.Point(179, 109);
            this.txtAcceptanceStates.Name = "txtAcceptanceStates";
            this.txtAcceptanceStates.Size = new System.Drawing.Size(100, 20);
            this.txtAcceptanceStates.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Estados aceptación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Estados";
            // 
            // txtStates
            // 
            this.txtStates.Location = new System.Drawing.Point(179, 57);
            this.txtStates.Name = "txtStates";
            this.txtStates.Size = new System.Drawing.Size(100, 20);
            this.txtStates.TabIndex = 3;
            // 
            // txtInitialState
            // 
            this.txtInitialState.Location = new System.Drawing.Point(179, 83);
            this.txtInitialState.Name = "txtInitialState";
            this.txtInitialState.Size = new System.Drawing.Size(100, 20);
            this.txtInitialState.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Estado inicial";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(565, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Transiciones";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(480, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Origen";
            // 
            // txtOrigin
            // 
            this.txtOrigin.Location = new System.Drawing.Point(466, 86);
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.Size = new System.Drawing.Size(67, 20);
            this.txtOrigin.TabIndex = 8;
            // 
            // txtSymbol
            // 
            this.txtSymbol.Location = new System.Drawing.Point(568, 86);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(67, 20);
            this.txtSymbol.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(577, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Símbolo";
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(675, 86);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(67, 20);
            this.txtDestination.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(689, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Destino";
            // 
            // btnAddTransition
            // 
            this.btnAddTransition.Location = new System.Drawing.Point(550, 121);
            this.btnAddTransition.Name = "btnAddTransition";
            this.btnAddTransition.Size = new System.Drawing.Size(120, 23);
            this.btnAddTransition.TabIndex = 14;
            this.btnAddTransition.Text = "Agregar transición";
            this.btnAddTransition.UseVisualStyleBackColor = true;
            this.btnAddTransition.Click += new System.EventHandler(this.btnAddTransition_Click);
            // 
            // btnGraph
            // 
            this.btnGraph.Location = new System.Drawing.Point(72, 282);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(75, 23);
            this.btnGraph.TabIndex = 15;
            this.btnGraph.Text = "Graficar";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(72, 367);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 16;
            this.btnClean.Text = "Limpiar";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(209, 166);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(533, 313);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddsymbols
            // 
            this.btnAddsymbols.Location = new System.Drawing.Point(294, 29);
            this.btnAddsymbols.Name = "btnAddsymbols";
            this.btnAddsymbols.Size = new System.Drawing.Size(75, 23);
            this.btnAddsymbols.TabIndex = 18;
            this.btnAddsymbols.Text = "Add simbolo";
            this.btnAddsymbols.UseVisualStyleBackColor = true;
            this.btnAddsymbols.Click += new System.EventHandler(this.btnAddsymbols_Click);
            // 
            // btnAddStates
            // 
            this.btnAddStates.Location = new System.Drawing.Point(294, 55);
            this.btnAddStates.Name = "btnAddStates";
            this.btnAddStates.Size = new System.Drawing.Size(75, 23);
            this.btnAddStates.TabIndex = 19;
            this.btnAddStates.Text = "Add Estado";
            this.btnAddStates.UseVisualStyleBackColor = true;
            this.btnAddStates.Click += new System.EventHandler(this.btnAddStates_Click);
            // 
            // btnAddInitialState
            // 
            this.btnAddInitialState.Location = new System.Drawing.Point(294, 81);
            this.btnAddInitialState.Name = "btnAddInitialState";
            this.btnAddInitialState.Size = new System.Drawing.Size(75, 23);
            this.btnAddInitialState.TabIndex = 20;
            this.btnAddInitialState.Text = "Add E Inicial";
            this.btnAddInitialState.UseVisualStyleBackColor = true;
            this.btnAddInitialState.Click += new System.EventHandler(this.btnAddInitialState_Click);
            // 
            // btnAcceptanceStates
            // 
            this.btnAcceptanceStates.Location = new System.Drawing.Point(294, 107);
            this.btnAcceptanceStates.Name = "btnAcceptanceStates";
            this.btnAcceptanceStates.Size = new System.Drawing.Size(75, 23);
            this.btnAcceptanceStates.TabIndex = 21;
            this.btnAcceptanceStates.Text = "Add E Final";
            this.btnAcceptanceStates.UseVisualStyleBackColor = true;
            this.btnAcceptanceStates.Click += new System.EventHandler(this.btnAcceptanceStates_Click);
            // 
            // btnViewAutomaton
            // 
            this.btnViewAutomaton.Location = new System.Drawing.Point(72, 199);
            this.btnViewAutomaton.Name = "btnViewAutomaton";
            this.btnViewAutomaton.Size = new System.Drawing.Size(75, 23);
            this.btnViewAutomaton.TabIndex = 22;
            this.btnViewAutomaton.Text = "Ver automata";
            this.btnViewAutomaton.UseVisualStyleBackColor = true;
            this.btnViewAutomaton.Click += new System.EventHandler(this.btnViewAutomaton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 504);
            this.Controls.Add(this.btnViewAutomaton);
            this.Controls.Add(this.btnAcceptanceStates);
            this.Controls.Add(this.btnAddInitialState);
            this.Controls.Add(this.btnAddStates);
            this.Controls.Add(this.btnAddsymbols);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.btnAddTransition);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSymbol);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtOrigin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtInitialState);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStates);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAcceptanceStates);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSymbols);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Automaton";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSymbols;
        private System.Windows.Forms.TextBox txtAcceptanceStates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStates;
        private System.Windows.Forms.TextBox txtInitialState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOrigin;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddTransition;
        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddsymbols;
        private System.Windows.Forms.Button btnAddStates;
        private System.Windows.Forms.Button btnAddInitialState;
        private System.Windows.Forms.Button btnAcceptanceStates;
        private System.Windows.Forms.Button btnViewAutomaton;
    }
}

