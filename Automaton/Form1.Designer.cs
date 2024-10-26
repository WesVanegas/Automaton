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
            this.label7 = new System.Windows.Forms.Label();
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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboOrigin = new System.Windows.Forms.ComboBox();
            this.cboSymbol = new System.Windows.Forms.ComboBox();
            this.cboDestination = new System.Windows.Forms.ComboBox();
            this.btnModify = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnRemoveSymbols = new System.Windows.Forms.Button();
            this.btnRemoveStates = new System.Windows.Forms.Button();
            this.btnRemoveInitialState = new System.Windows.Forms.Button();
            this.btnRemoveAcceptanceStates = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input symbol";
            // 
            // txtSymbols
            // 
            this.txtSymbols.Location = new System.Drawing.Point(142, 35);
            this.txtSymbols.MaxLength = 100;
            this.txtSymbols.Name = "txtSymbols";
            this.txtSymbols.Size = new System.Drawing.Size(100, 20);
            this.txtSymbols.TabIndex = 1;
            // 
            // txtAcceptanceStates
            // 
            this.txtAcceptanceStates.Location = new System.Drawing.Point(163, 114);
            this.txtAcceptanceStates.MaxLength = 10;
            this.txtAcceptanceStates.Name = "txtAcceptanceStates";
            this.txtAcceptanceStates.Size = new System.Drawing.Size(79, 20);
            this.txtAcceptanceStates.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "States of acceptance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "States";
            // 
            // txtStates
            // 
            this.txtStates.Location = new System.Drawing.Point(142, 61);
            this.txtStates.MaxLength = 100;
            this.txtStates.Name = "txtStates";
            this.txtStates.Size = new System.Drawing.Size(100, 20);
            this.txtStates.TabIndex = 3;
            // 
            // txtInitialState
            // 
            this.txtInitialState.Location = new System.Drawing.Point(142, 88);
            this.txtInitialState.MaxLength = 10;
            this.txtInitialState.Name = "txtInitialState";
            this.txtInitialState.Size = new System.Drawing.Size(100, 20);
            this.txtInitialState.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Initial state";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Transitions";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Origin";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Symbol";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(291, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Destination";
            // 
            // btnAddTransition
            // 
            this.btnAddTransition.Location = new System.Drawing.Point(164, 242);
            this.btnAddTransition.Name = "btnAddTransition";
            this.btnAddTransition.Size = new System.Drawing.Size(100, 25);
            this.btnAddTransition.TabIndex = 14;
            this.btnAddTransition.Text = "Add Transition";
            this.btnAddTransition.UseVisualStyleBackColor = true;
            this.btnAddTransition.Click += new System.EventHandler(this.btnAddTransition_Click);
            // 
            // btnGraph
            // 
            this.btnGraph.Location = new System.Drawing.Point(164, 321);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(100, 25);
            this.btnGraph.TabIndex = 15;
            this.btnGraph.Text = "Graph";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(269, 321);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(100, 25);
            this.btnClean.TabIndex = 16;
            this.btnClean.Text = "Clean automata";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(430, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(307, 537);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddsymbols
            // 
            this.btnAddsymbols.Location = new System.Drawing.Point(248, 35);
            this.btnAddsymbols.Name = "btnAddsymbols";
            this.btnAddsymbols.Size = new System.Drawing.Size(75, 23);
            this.btnAddsymbols.TabIndex = 18;
            this.btnAddsymbols.Text = "Add ";
            this.btnAddsymbols.UseVisualStyleBackColor = true;
            this.btnAddsymbols.Click += new System.EventHandler(this.btnAddsymbols_Click);
            // 
            // btnAddStates
            // 
            this.btnAddStates.Location = new System.Drawing.Point(248, 61);
            this.btnAddStates.Name = "btnAddStates";
            this.btnAddStates.Size = new System.Drawing.Size(75, 23);
            this.btnAddStates.TabIndex = 19;
            this.btnAddStates.Text = "Add ";
            this.btnAddStates.UseVisualStyleBackColor = true;
            this.btnAddStates.Click += new System.EventHandler(this.btnAddStates_Click);
            // 
            // btnAddInitialState
            // 
            this.btnAddInitialState.Location = new System.Drawing.Point(248, 86);
            this.btnAddInitialState.Name = "btnAddInitialState";
            this.btnAddInitialState.Size = new System.Drawing.Size(75, 23);
            this.btnAddInitialState.TabIndex = 20;
            this.btnAddInitialState.Text = "Add";
            this.btnAddInitialState.UseVisualStyleBackColor = true;
            this.btnAddInitialState.Click += new System.EventHandler(this.btnAddInitialState_Click);
            // 
            // btnAcceptanceStates
            // 
            this.btnAcceptanceStates.Location = new System.Drawing.Point(248, 114);
            this.btnAcceptanceStates.Name = "btnAcceptanceStates";
            this.btnAcceptanceStates.Size = new System.Drawing.Size(75, 23);
            this.btnAcceptanceStates.TabIndex = 21;
            this.btnAcceptanceStates.Text = "Add";
            this.btnAcceptanceStates.UseVisualStyleBackColor = true;
            this.btnAcceptanceStates.Click += new System.EventHandler(this.btnAcceptanceStates_Click);
            // 
            // btnViewAutomaton
            // 
            this.btnViewAutomaton.Location = new System.Drawing.Point(58, 321);
            this.btnViewAutomaton.Name = "btnViewAutomaton";
            this.btnViewAutomaton.Size = new System.Drawing.Size(100, 25);
            this.btnViewAutomaton.TabIndex = 22;
            this.btnViewAutomaton.Text = "Data";
            this.btnViewAutomaton.UseVisualStyleBackColor = true;
            this.btnViewAutomaton.Click += new System.EventHandler(this.btnViewAutomaton_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.Location = new System.Drawing.Point(58, 398);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(311, 120);
            this.txtLog.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(171, 373);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 24;
            // 
            // cboOrigin
            // 
            this.cboOrigin.FormattingEnabled = true;
            this.cboOrigin.Location = new System.Drawing.Point(58, 215);
            this.cboOrigin.Name = "cboOrigin";
            this.cboOrigin.Size = new System.Drawing.Size(100, 21);
            this.cboOrigin.TabIndex = 25;
            // 
            // cboSymbol
            // 
            this.cboSymbol.FormattingEnabled = true;
            this.cboSymbol.Location = new System.Drawing.Point(164, 215);
            this.cboSymbol.Name = "cboSymbol";
            this.cboSymbol.Size = new System.Drawing.Size(100, 21);
            this.cboSymbol.TabIndex = 26;
            // 
            // cboDestination
            // 
            this.cboDestination.FormattingEnabled = true;
            this.cboDestination.Location = new System.Drawing.Point(269, 215);
            this.cboDestination.Name = "cboDestination";
            this.cboDestination.Size = new System.Drawing.Size(100, 21);
            this.cboDestination.TabIndex = 27;
            // 
            // btnModify
            // 
            this.btnModify.Enabled = false;
            this.btnModify.Location = new System.Drawing.Point(164, 352);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(205, 25);
            this.btnModify.TabIndex = 28;
            this.btnModify.Text = "Modify initial automata";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(375, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "?";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRemoveSymbols
            // 
            this.btnRemoveSymbols.Location = new System.Drawing.Point(329, 35);
            this.btnRemoveSymbols.Name = "btnRemoveSymbols";
            this.btnRemoveSymbols.Size = new System.Drawing.Size(77, 23);
            this.btnRemoveSymbols.TabIndex = 30;
            this.btnRemoveSymbols.Text = "Remove";
            this.btnRemoveSymbols.UseVisualStyleBackColor = true;
            // 
            // btnRemoveStates
            // 
            this.btnRemoveStates.Location = new System.Drawing.Point(329, 61);
            this.btnRemoveStates.Name = "btnRemoveStates";
            this.btnRemoveStates.Size = new System.Drawing.Size(77, 23);
            this.btnRemoveStates.TabIndex = 31;
            this.btnRemoveStates.Text = "Remove";
            this.btnRemoveStates.UseVisualStyleBackColor = true;
            // 
            // btnRemoveInitialState
            // 
            this.btnRemoveInitialState.Location = new System.Drawing.Point(329, 86);
            this.btnRemoveInitialState.Name = "btnRemoveInitialState";
            this.btnRemoveInitialState.Size = new System.Drawing.Size(77, 23);
            this.btnRemoveInitialState.TabIndex = 32;
            this.btnRemoveInitialState.Text = "Remove";
            this.btnRemoveInitialState.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAcceptanceStates
            // 
            this.btnRemoveAcceptanceStates.Location = new System.Drawing.Point(329, 114);
            this.btnRemoveAcceptanceStates.Name = "btnRemoveAcceptanceStates";
            this.btnRemoveAcceptanceStates.Size = new System.Drawing.Size(77, 23);
            this.btnRemoveAcceptanceStates.TabIndex = 33;
            this.btnRemoveAcceptanceStates.Text = "Remove";
            this.btnRemoveAcceptanceStates.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnRemoveAcceptanceStates);
            this.Controls.Add(this.btnRemoveInitialState);
            this.Controls.Add(this.btnRemoveStates);
            this.Controls.Add(this.btnRemoveSymbols);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.cboDestination);
            this.Controls.Add(this.cboSymbol);
            this.Controls.Add(this.cboOrigin);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnViewAutomaton);
            this.Controls.Add(this.btnAcceptanceStates);
            this.Controls.Add(this.btnAddInitialState);
            this.Controls.Add(this.btnAddStates);
            this.Controls.Add(this.btnAddsymbols);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.btnAddTransition);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automaton";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Label label7;
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
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboOrigin;
        private System.Windows.Forms.ComboBox cboSymbol;
        private System.Windows.Forms.ComboBox cboDestination;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnRemoveSymbols;
        private System.Windows.Forms.Button btnRemoveStates;
        private System.Windows.Forms.Button btnRemoveInitialState;
        private System.Windows.Forms.Button btnRemoveAcceptanceStates;
    }
}

