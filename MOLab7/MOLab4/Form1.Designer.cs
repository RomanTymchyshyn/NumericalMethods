namespace MOLab4
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.simpleOpenGlControl1 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.a = new System.Windows.Forms.Label();
            this.b = new System.Windows.Forms.Label();
            this.k = new System.Windows.Forms.Label();
            this.EPS = new System.Windows.Forms.Label();
            this.c = new System.Windows.Forms.Label();
            this.d = new System.Windows.Forms.Label();
            this.n = new System.Windows.Forms.Label();
            this.h = new System.Windows.Forms.Label();
            this.a_textBox = new System.Windows.Forms.TextBox();
            this.b_textBox = new System.Windows.Forms.TextBox();
            this.k_textBox = new System.Windows.Forms.TextBox();
            this.EPS_textBox = new System.Windows.Forms.TextBox();
            this.c_textBox = new System.Windows.Forms.TextBox();
            this.d_textBox = new System.Windows.Forms.TextBox();
            this.n_textBox = new System.Windows.Forms.TextBox();
            this.h_textBox = new System.Windows.Forms.TextBox();
            this.DrawExactSol = new System.Windows.Forms.Button();
            this.DrawApprox = new System.Windows.Forms.Button();
            this.RedrawButton = new System.Windows.Forms.Button();
            this.Exactcolor = new System.Windows.Forms.Label();
            this.Approx_color = new System.Windows.Forms.Label();
            this.l = new System.Windows.Forms.Label();
            this.l_textBox = new System.Windows.Forms.TextBox();
            this.BottomBorder_TextBox = new System.Windows.Forms.TextBox();
            this.BottomBorder_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TopBorder_TextBox = new System.Windows.Forms.TextBox();
            this.ShowResult_button = new System.Windows.Forms.Button();
            this.Step_comboBox = new System.Windows.Forms.ComboBox();
            this.Step_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // simpleOpenGlControl1
            // 
            this.simpleOpenGlControl1.AccumBits = ((byte)(0));
            this.simpleOpenGlControl1.AutoCheckErrors = false;
            this.simpleOpenGlControl1.AutoFinish = false;
            this.simpleOpenGlControl1.AutoMakeCurrent = true;
            this.simpleOpenGlControl1.AutoSwapBuffers = true;
            this.simpleOpenGlControl1.BackColor = System.Drawing.Color.Azure;
            this.simpleOpenGlControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("simpleOpenGlControl1.BackgroundImage")));
            this.simpleOpenGlControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.simpleOpenGlControl1.ColorBits = ((byte)(32));
            this.simpleOpenGlControl1.DepthBits = ((byte)(16));
            this.simpleOpenGlControl1.Location = new System.Drawing.Point(12, 12);
            this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
            this.simpleOpenGlControl1.Size = new System.Drawing.Size(900, 469);
            this.simpleOpenGlControl1.StencilBits = ((byte)(0));
            this.simpleOpenGlControl1.TabIndex = 0;
            this.simpleOpenGlControl1.VSync = false;
            this.simpleOpenGlControl1.Load += new System.EventHandler(this.simpleOpenGlControl1_Load);
            this.simpleOpenGlControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenGlControl1_Paint);
            this.simpleOpenGlControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.simpleOpenGlControl1_KeyDown);
            this.simpleOpenGlControl1.Resize += new System.EventHandler(this.simpleOpenGlControl1_Resize);
            // 
            // a
            // 
            this.a.Location = new System.Drawing.Point(921, 23);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(26, 15);
            this.a.TabIndex = 6;
            this.a.Text = "a = ";
            // 
            // b
            // 
            this.b.Location = new System.Drawing.Point(921, 69);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(27, 15);
            this.b.TabIndex = 8;
            this.b.Text = "b = ";
            // 
            // k
            // 
            this.k.Location = new System.Drawing.Point(921, 107);
            this.k.Name = "k";
            this.k.Size = new System.Drawing.Size(26, 15);
            this.k.TabIndex = 9;
            this.k.Text = "k = ";
            // 
            // EPS
            // 
            this.EPS.Location = new System.Drawing.Point(918, 140);
            this.EPS.Name = "EPS";
            this.EPS.Size = new System.Drawing.Size(37, 21);
            this.EPS.TabIndex = 10;
            this.EPS.Text = "EPS = ";
            // 
            // c
            // 
            this.c.Location = new System.Drawing.Point(1009, 23);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(26, 18);
            this.c.TabIndex = 11;
            this.c.Text = "c = ";
            // 
            // d
            // 
            this.d.Location = new System.Drawing.Point(1009, 70);
            this.d.Name = "d";
            this.d.Size = new System.Drawing.Size(31, 14);
            this.d.TabIndex = 12;
            this.d.Text = "d = ";
            // 
            // n
            // 
            this.n.Location = new System.Drawing.Point(1009, 107);
            this.n.Name = "n";
            this.n.Size = new System.Drawing.Size(26, 17);
            this.n.TabIndex = 13;
            this.n.Text = "n = ";
            // 
            // h
            // 
            this.h.Location = new System.Drawing.Point(1009, 140);
            this.h.Name = "h";
            this.h.Size = new System.Drawing.Size(25, 21);
            this.h.TabIndex = 14;
            this.h.Text = "h = ";
            this.h.UseMnemonic = false;
            // 
            // a_textBox
            // 
            this.a_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.a_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.a_textBox.Location = new System.Drawing.Point(953, 12);
            this.a_textBox.Multiline = true;
            this.a_textBox.Name = "a_textBox";
            this.a_textBox.Size = new System.Drawing.Size(55, 29);
            this.a_textBox.TabIndex = 15;
            this.a_textBox.Text = "-0,25";
            this.a_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // b_textBox
            // 
            this.b_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_textBox.Location = new System.Drawing.Point(953, 53);
            this.b_textBox.Multiline = true;
            this.b_textBox.Name = "b_textBox";
            this.b_textBox.Size = new System.Drawing.Size(56, 31);
            this.b_textBox.TabIndex = 16;
            this.b_textBox.Text = "2,0";
            this.b_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // k_textBox
            // 
            this.k_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.k_textBox.Location = new System.Drawing.Point(953, 93);
            this.k_textBox.Multiline = true;
            this.k_textBox.Name = "k_textBox";
            this.k_textBox.Size = new System.Drawing.Size(55, 31);
            this.k_textBox.TabIndex = 17;
            this.k_textBox.Text = "2,5";
            this.k_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EPS_textBox
            // 
            this.EPS_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EPS_textBox.Location = new System.Drawing.Point(953, 132);
            this.EPS_textBox.Multiline = true;
            this.EPS_textBox.Name = "EPS_textBox";
            this.EPS_textBox.Size = new System.Drawing.Size(55, 35);
            this.EPS_textBox.TabIndex = 18;
            this.EPS_textBox.Text = "0,001";
            this.EPS_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // c_textBox
            // 
            this.c_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.c_textBox.Location = new System.Drawing.Point(1041, 12);
            this.c_textBox.Multiline = true;
            this.c_textBox.Name = "c_textBox";
            this.c_textBox.Size = new System.Drawing.Size(59, 29);
            this.c_textBox.TabIndex = 19;
            this.c_textBox.Text = "-1,0";
            this.c_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // d_textBox
            // 
            this.d_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.d_textBox.Location = new System.Drawing.Point(1041, 53);
            this.d_textBox.Multiline = true;
            this.d_textBox.Name = "d_textBox";
            this.d_textBox.Size = new System.Drawing.Size(59, 31);
            this.d_textBox.TabIndex = 20;
            this.d_textBox.Text = "3,0";
            this.d_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // n_textBox
            // 
            this.n_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.n_textBox.Location = new System.Drawing.Point(1040, 93);
            this.n_textBox.Multiline = true;
            this.n_textBox.Name = "n_textBox";
            this.n_textBox.Size = new System.Drawing.Size(60, 33);
            this.n_textBox.TabIndex = 21;
            this.n_textBox.Text = "-2,0";
            this.n_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // h_textBox
            // 
            this.h_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.h_textBox.Location = new System.Drawing.Point(1039, 131);
            this.h_textBox.Multiline = true;
            this.h_textBox.Name = "h_textBox";
            this.h_textBox.Size = new System.Drawing.Size(61, 34);
            this.h_textBox.TabIndex = 22;
            this.h_textBox.Text = "0,1";
            this.h_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DrawExactSol
            // 
            this.DrawExactSol.Location = new System.Drawing.Point(934, 288);
            this.DrawExactSol.Name = "DrawExactSol";
            this.DrawExactSol.Size = new System.Drawing.Size(132, 23);
            this.DrawExactSol.TabIndex = 23;
            this.DrawExactSol.Text = "Draw Exact Solution (on/off)";
            this.DrawExactSol.UseVisualStyleBackColor = true;
            this.DrawExactSol.Click += new System.EventHandler(this.DrawExactSol_Click);
            // 
            // DrawApprox
            // 
            this.DrawApprox.Location = new System.Drawing.Point(934, 317);
            this.DrawApprox.Name = "DrawApprox";
            this.DrawApprox.Size = new System.Drawing.Size(132, 23);
            this.DrawApprox.TabIndex = 24;
            this.DrawApprox.Text = "Draw Approximate Solution (on/off)";
            this.DrawApprox.UseVisualStyleBackColor = true;
            this.DrawApprox.Click += new System.EventHandler(this.DrawApprox_Click);
            // 
            // RedrawButton
            // 
            this.RedrawButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.RedrawButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RedrawButton.Location = new System.Drawing.Point(934, 346);
            this.RedrawButton.Name = "RedrawButton";
            this.RedrawButton.Size = new System.Drawing.Size(165, 24);
            this.RedrawButton.TabIndex = 28;
            this.RedrawButton.Text = "Redraw";
            this.RedrawButton.UseVisualStyleBackColor = false;
            this.RedrawButton.Click += new System.EventHandler(this.RedrawButton_Click);
            // 
            // Exactcolor
            // 
            this.Exactcolor.BackColor = System.Drawing.Color.Red;
            this.Exactcolor.Cursor = System.Windows.Forms.Cursors.Default;
            this.Exactcolor.Location = new System.Drawing.Point(1072, 288);
            this.Exactcolor.Name = "Exactcolor";
            this.Exactcolor.Size = new System.Drawing.Size(27, 23);
            this.Exactcolor.TabIndex = 30;
            // 
            // Approx_color
            // 
            this.Approx_color.BackColor = System.Drawing.Color.ForestGreen;
            this.Approx_color.Location = new System.Drawing.Point(1072, 317);
            this.Approx_color.Name = "Approx_color";
            this.Approx_color.Size = new System.Drawing.Size(27, 23);
            this.Approx_color.TabIndex = 32;
            // 
            // l
            // 
            this.l.Location = new System.Drawing.Point(921, 176);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(27, 17);
            this.l.TabIndex = 40;
            this.l.Text = "l =";
            this.l.UseWaitCursor = true;
            // 
            // l_textBox
            // 
            this.l_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_textBox.Location = new System.Drawing.Point(953, 173);
            this.l_textBox.Multiline = true;
            this.l_textBox.Name = "l_textBox";
            this.l_textBox.Size = new System.Drawing.Size(55, 36);
            this.l_textBox.TabIndex = 41;
            this.l_textBox.Text = "2,0";
            this.l_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BottomBorder_TextBox
            // 
            this.BottomBorder_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BottomBorder_TextBox.Location = new System.Drawing.Point(953, 239);
            this.BottomBorder_TextBox.Multiline = true;
            this.BottomBorder_TextBox.Name = "BottomBorder_TextBox";
            this.BottomBorder_TextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BottomBorder_TextBox.Size = new System.Drawing.Size(54, 35);
            this.BottomBorder_TextBox.TabIndex = 42;
            this.BottomBorder_TextBox.Text = "0,0";
            this.BottomBorder_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BottomBorder_Label
            // 
            this.BottomBorder_Label.AutoSize = true;
            this.BottomBorder_Label.Location = new System.Drawing.Point(935, 223);
            this.BottomBorder_Label.Name = "BottomBorder_Label";
            this.BottomBorder_Label.Size = new System.Drawing.Size(74, 13);
            this.BottomBorder_Label.TabIndex = 43;
            this.BottomBorder_Label.Text = "Bottom Border";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1036, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Top Border";
            // 
            // TopBorder_TextBox
            // 
            this.TopBorder_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TopBorder_TextBox.Location = new System.Drawing.Point(1041, 239);
            this.TopBorder_TextBox.Multiline = true;
            this.TopBorder_TextBox.Name = "TopBorder_TextBox";
            this.TopBorder_TextBox.Size = new System.Drawing.Size(54, 34);
            this.TopBorder_TextBox.TabIndex = 45;
            this.TopBorder_TextBox.Text = "10,0";
            this.TopBorder_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ShowResult_button
            // 
            this.ShowResult_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowResult_button.Location = new System.Drawing.Point(934, 379);
            this.ShowResult_button.Name = "ShowResult_button";
            this.ShowResult_button.Size = new System.Drawing.Size(165, 29);
            this.ShowResult_button.TabIndex = 46;
            this.ShowResult_button.Text = "Show table with results";
            this.ShowResult_button.UseVisualStyleBackColor = true;
            this.ShowResult_button.Click += new System.EventHandler(this.ShowResult_button_Click);
            // 
            // Step_comboBox
            // 
            this.Step_comboBox.FormattingEnabled = true;
            this.Step_comboBox.Items.AddRange(new object[] {
            "Auto",
            "Fixed"});
            this.Step_comboBox.Location = new System.Drawing.Point(978, 414);
            this.Step_comboBox.Name = "Step_comboBox";
            this.Step_comboBox.Size = new System.Drawing.Size(121, 21);
            this.Step_comboBox.TabIndex = 47;
            this.Step_comboBox.Text = "Auto";
            this.Step_comboBox.UseWaitCursor = true;
            // 
            // Step_label
            // 
            this.Step_label.AutoSize = true;
            this.Step_label.Location = new System.Drawing.Point(935, 417);
            this.Step_label.Name = "Step_label";
            this.Step_label.Size = new System.Drawing.Size(29, 13);
            this.Step_label.TabIndex = 48;
            this.Step_label.Text = "Step";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 504);
            this.Controls.Add(this.Step_label);
            this.Controls.Add(this.Step_comboBox);
            this.Controls.Add(this.ShowResult_button);
            this.Controls.Add(this.TopBorder_TextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BottomBorder_Label);
            this.Controls.Add(this.BottomBorder_TextBox);
            this.Controls.Add(this.l_textBox);
            this.Controls.Add(this.l);
            this.Controls.Add(this.Approx_color);
            this.Controls.Add(this.Exactcolor);
            this.Controls.Add(this.RedrawButton);
            this.Controls.Add(this.DrawApprox);
            this.Controls.Add(this.DrawExactSol);
            this.Controls.Add(this.h_textBox);
            this.Controls.Add(this.n_textBox);
            this.Controls.Add(this.d_textBox);
            this.Controls.Add(this.c_textBox);
            this.Controls.Add(this.EPS_textBox);
            this.Controls.Add(this.k_textBox);
            this.Controls.Add(this.b_textBox);
            this.Controls.Add(this.a_textBox);
            this.Controls.Add(this.h);
            this.Controls.Add(this.n);
            this.Controls.Add(this.d);
            this.Controls.Add(this.c);
            this.Controls.Add(this.EPS);
            this.Controls.Add(this.k);
            this.Controls.Add(this.b);
            this.Controls.Add(this.a);
            this.Controls.Add(this.simpleOpenGlControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "МО Лабораторна 7 (Тимчишин Роман, ОМ - 3)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
        private System.Windows.Forms.Label a;
        private System.Windows.Forms.Label b;
        private System.Windows.Forms.Label k;
        private System.Windows.Forms.Label EPS;
        private System.Windows.Forms.Label c;
        private System.Windows.Forms.Label d;
        private System.Windows.Forms.Label n;
        private System.Windows.Forms.Label h;
        private System.Windows.Forms.TextBox a_textBox;
        private System.Windows.Forms.TextBox b_textBox;
        private System.Windows.Forms.TextBox k_textBox;
        private System.Windows.Forms.TextBox EPS_textBox;
        private System.Windows.Forms.TextBox c_textBox;
        private System.Windows.Forms.TextBox d_textBox;
        private System.Windows.Forms.TextBox n_textBox;
        private System.Windows.Forms.TextBox h_textBox;
        private System.Windows.Forms.Button DrawExactSol;
        private System.Windows.Forms.Button DrawApprox;
        private System.Windows.Forms.Button RedrawButton;
        private System.Windows.Forms.Label Exactcolor;
        private System.Windows.Forms.Label Approx_color;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.TextBox l_textBox;
        private System.Windows.Forms.TextBox BottomBorder_TextBox;
        private System.Windows.Forms.Label BottomBorder_Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TopBorder_TextBox;
        private System.Windows.Forms.Button ShowResult_button;
        private System.Windows.Forms.ComboBox Step_comboBox;
        private System.Windows.Forms.Label Step_label;
    }
}

