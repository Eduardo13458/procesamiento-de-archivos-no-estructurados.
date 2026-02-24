namespace procesamiento_de_archivos_no_estructurados_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabLog = new TabPage();
            txtLogResults = new TextBox();
            panel1 = new Panel();
            btnSearchLog = new Button();
            txtSearchLog = new TextBox();
            label2 = new Label();
            btnAnalyzeLog = new Button();
            btnLoadLog = new Button();
            tabSrt = new TabPage();
            txtSrtResults = new TextBox();
            panel2 = new Panel();
            btnSearchSrt = new Button();
            txtSearchSrt = new TextBox();
            label3 = new Label();
            btnExtractText = new Button();
            btnAnalyzeSrt = new Button();
            btnLoadSrt = new Button();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabLog.SuspendLayout();
            panel1.SuspendLayout();
            tabSrt.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabLog);
            tabControl1.Controls.Add(tabSrt);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 60);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1000, 590);
            tabControl1.TabIndex = 0;
            // 
            // tabLog
            // 
            tabLog.Controls.Add(txtLogResults);
            tabLog.Controls.Add(panel1);
            tabLog.Location = new Point(4, 29);
            tabLog.Name = "tabLog";
            tabLog.Padding = new Padding(3);
            tabLog.Size = new Size(992, 557);
            tabLog.TabIndex = 0;
            tabLog.Text = "Procesamiento .LOG";
            tabLog.UseVisualStyleBackColor = true;
            // 
            // txtLogResults
            // 
            txtLogResults.Dock = DockStyle.Fill;
            txtLogResults.Font = new Font("Consolas", 9F);
            txtLogResults.Location = new Point(3, 83);
            txtLogResults.Multiline = true;
            txtLogResults.Name = "txtLogResults";
            txtLogResults.ScrollBars = ScrollBars.Both;
            txtLogResults.Size = new Size(986, 471);
            txtLogResults.TabIndex = 1;
            txtLogResults.WordWrap = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSearchLog);
            panel1.Controls.Add(txtSearchLog);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnAnalyzeLog);
            panel1.Controls.Add(btnLoadLog);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(986, 80);
            panel1.TabIndex = 0;
            // 
            // btnSearchLog
            // 
            btnSearchLog.Location = new Point(570, 45);
            btnSearchLog.Name = "btnSearchLog";
            btnSearchLog.Size = new Size(100, 29);
            btnSearchLog.TabIndex = 4;
            btnSearchLog.Text = "Buscar";
            btnSearchLog.UseVisualStyleBackColor = true;
            btnSearchLog.Click += btnSearchLog_Click;
            // 
            // txtSearchLog
            // 
            txtSearchLog.Location = new Point(279, 46);
            txtSearchLog.Name = "txtSearchLog";
            txtSearchLog.PlaceholderText = "Ej: ERROR, WARNING";
            txtSearchLog.Size = new Size(285, 27);
            txtSearchLog.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(170, 49);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 2;
            label2.Text = "Buscar término:";
            // 
            // btnAnalyzeLog
            // 
            btnAnalyzeLog.Location = new Point(170, 10);
            btnAnalyzeLog.Name = "btnAnalyzeLog";
            btnAnalyzeLog.Size = new Size(150, 29);
            btnAnalyzeLog.TabIndex = 1;
            btnAnalyzeLog.Text = "Analizar LOG";
            btnAnalyzeLog.UseVisualStyleBackColor = true;
            btnAnalyzeLog.Click += btnAnalyzeLog_Click;
            // 
            // btnLoadLog
            // 
            btnLoadLog.Location = new Point(10, 10);
            btnLoadLog.Name = "btnLoadLog";
            btnLoadLog.Size = new Size(150, 29);
            btnLoadLog.TabIndex = 0;
            btnLoadLog.Text = "Cargar Archivo .LOG";
            btnLoadLog.UseVisualStyleBackColor = true;
            btnLoadLog.Click += btnLoadLog_Click;
            // 
            // tabSrt
            // 
            tabSrt.Controls.Add(txtSrtResults);
            tabSrt.Controls.Add(panel2);
            tabSrt.Location = new Point(4, 29);
            tabSrt.Name = "tabSrt";
            tabSrt.Padding = new Padding(3);
            tabSrt.Size = new Size(992, 557);
            tabSrt.TabIndex = 1;
            tabSrt.Text = "Procesamiento .SRT";
            tabSrt.UseVisualStyleBackColor = true;
            // 
            // txtSrtResults
            // 
            txtSrtResults.Dock = DockStyle.Fill;
            txtSrtResults.Font = new Font("Consolas", 9F);
            txtSrtResults.Location = new Point(3, 83);
            txtSrtResults.Multiline = true;
            txtSrtResults.Name = "txtSrtResults";
            txtSrtResults.ScrollBars = ScrollBars.Both;
            txtSrtResults.Size = new Size(986, 471);
            txtSrtResults.TabIndex = 1;
            txtSrtResults.WordWrap = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSearchSrt);
            panel2.Controls.Add(txtSearchSrt);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(btnExtractText);
            panel2.Controls.Add(btnAnalyzeSrt);
            panel2.Controls.Add(btnLoadSrt);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(986, 80);
            panel2.TabIndex = 0;
            // 
            // btnSearchSrt
            // 
            btnSearchSrt.Location = new Point(570, 45);
            btnSearchSrt.Name = "btnSearchSrt";
            btnSearchSrt.Size = new Size(100, 29);
            btnSearchSrt.TabIndex = 5;
            btnSearchSrt.Text = "Buscar";
            btnSearchSrt.UseVisualStyleBackColor = true;
            btnSearchSrt.Click += btnSearchSrt_Click;
            // 
            // txtSearchSrt
            // 
            txtSearchSrt.Location = new Point(279, 46);
            txtSearchSrt.Name = "txtSearchSrt";
            txtSearchSrt.PlaceholderText = "Ej: diálogo, palabra";
            txtSearchSrt.Size = new Size(285, 27);
            txtSearchSrt.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(170, 49);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 3;
            label3.Text = "Buscar texto:";
            // 
            // btnExtractText
            // 
            btnExtractText.Location = new Point(330, 10);
            btnExtractText.Name = "btnExtractText";
            btnExtractText.Size = new Size(150, 29);
            btnExtractText.TabIndex = 2;
            btnExtractText.Text = "Extraer Solo Texto";
            btnExtractText.UseVisualStyleBackColor = true;
            btnExtractText.Click += btnExtractText_Click;
            // 
            // btnAnalyzeSrt
            // 
            btnAnalyzeSrt.Location = new Point(170, 10);
            btnAnalyzeSrt.Name = "btnAnalyzeSrt";
            btnAnalyzeSrt.Size = new Size(150, 29);
            btnAnalyzeSrt.TabIndex = 1;
            btnAnalyzeSrt.Text = "Analizar SRT";
            btnAnalyzeSrt.UseVisualStyleBackColor = true;
            btnAnalyzeSrt.Click += btnAnalyzeSrt_Click;
            // 
            // btnLoadSrt
            // 
            btnLoadSrt.Location = new Point(10, 10);
            btnLoadSrt.Name = "btnLoadSrt";
            btnLoadSrt.Size = new Size(150, 29);
            btnLoadSrt.TabIndex = 0;
            btnLoadSrt.Text = "Cargar Archivo .SRT";
            btnLoadSrt.UseVisualStyleBackColor = true;
            btnLoadSrt.Click += btnLoadSrt_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(0, 120, 215);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1000, 60);
            label1.TabIndex = 1;
            label1.Text = "Procesamiento de Archivos No Estructurados (.LOG y .SRT)";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Procesamiento de Archivos No Estructurados";
            tabControl1.ResumeLayout(false);
            tabLog.ResumeLayout(false);
            tabLog.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabSrt.ResumeLayout(false);
            tabSrt.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabLog;
        private TabPage tabSrt;
        private Label label1;
        private TextBox txtLogResults;
        private Panel panel1;
        private Button btnLoadLog;
        private Button btnAnalyzeLog;
        private Label label2;
        private TextBox txtSearchLog;
        private Button btnSearchLog;
        private TextBox txtSrtResults;
        private Panel panel2;
        private Button btnLoadSrt;
        private Button btnAnalyzeSrt;
        private Button btnExtractText;
        private Label label3;
        private TextBox txtSearchSrt;
        private Button btnSearchSrt;
    }
}
