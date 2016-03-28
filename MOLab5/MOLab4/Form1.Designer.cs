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
            this.p = new System.Windows.Forms.Label();
            this.c = new System.Windows.Forms.Label();
            this.w = new System.Windows.Forms.Label();
            this.n = new System.Windows.Forms.Label();
            this.m = new System.Windows.Forms.Label();
            this.a_textBox = new System.Windows.Forms.TextBox();
            this.b_textBox = new System.Windows.Forms.TextBox();
            this.k_textBox = new System.Windows.Forms.TextBox();
            this.p_textBox = new System.Windows.Forms.TextBox();
            this.c_textBox = new System.Windows.Forms.TextBox();
            this.w_textBox = new System.Windows.Forms.TextBox();
            this.n_textBox = new System.Windows.Forms.TextBox();
            this.m_textBox = new System.Windows.Forms.TextBox();
            this.DrawFButton = new System.Windows.Forms.Button();
            this.DrawQ1Button = new System.Windows.Forms.Button();
            this.DrawQ2Button = new System.Windows.Forms.Button();
            this.DrawQ3Button = new System.Windows.Forms.Button();
            this.DrawQ4Button = new System.Windows.Forms.Button();
            this.RedrawButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.f_color = new System.Windows.Forms.Label();
            this.Q1_color = new System.Windows.Forms.Label();
            this.Q2_color = new System.Windows.Forms.Label();
            this.Q3_color = new System.Windows.Forms.Label();
            this.Q4_color = new System.Windows.Forms.Label();
            this.DevQ1 = new System.Windows.Forms.TextBox();
            this.DevQ2 = new System.Windows.Forms.TextBox();
            this.DevQ3 = new System.Windows.Forms.TextBox();
            this.DevQ4 = new System.Windows.Forms.TextBox();
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
            this.simpleOpenGlControl1.Size = new System.Drawing.Size(834, 469);
            this.simpleOpenGlControl1.StencilBits = ((byte)(0));
            this.simpleOpenGlControl1.TabIndex = 0;
            this.simpleOpenGlControl1.VSync = false;
            this.simpleOpenGlControl1.Load += new System.EventHandler(this.simpleOpenGlControl1_Load);
            this.simpleOpenGlControl1.Click += new System.EventHandler(this.simpleOpenGlControl1_Click);
            this.simpleOpenGlControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenGlControl1_Paint);
            this.simpleOpenGlControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.simpleOpenGlControl1_KeyDown);
            this.simpleOpenGlControl1.Resize += new System.EventHandler(this.simpleOpenGlControl1_Resize);
            // 
            // a
            // 
            this.a.Location = new System.Drawing.Point(852, 23);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(26, 15);
            this.a.TabIndex = 6;
            this.a.Text = "a = ";
            // 
            // b
            // 
            this.b.Location = new System.Drawing.Point(852, 69);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(27, 15);
            this.b.TabIndex = 8;
            this.b.Text = "b = ";
            // 
            // k
            // 
            this.k.Location = new System.Drawing.Point(852, 107);
            this.k.Name = "k";
            this.k.Size = new System.Drawing.Size(26, 15);
            this.k.TabIndex = 9;
            this.k.Text = "k = ";
            // 
            // p
            // 
            this.p.Location = new System.Drawing.Point(852, 145);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(27, 21);
            this.p.TabIndex = 10;
            this.p.Text = "p = ";
            // 
            // c
            // 
            this.c.Location = new System.Drawing.Point(940, 23);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(26, 18);
            this.c.TabIndex = 11;
            this.c.Text = "c = ";
            // 
            // w
            // 
            this.w.Location = new System.Drawing.Point(940, 70);
            this.w.Name = "w";
            this.w.Size = new System.Drawing.Size(31, 14);
            this.w.TabIndex = 12;
            this.w.Text = "w = ";
            // 
            // n
            // 
            this.n.Location = new System.Drawing.Point(940, 107);
            this.n.Name = "n";
            this.n.Size = new System.Drawing.Size(26, 17);
            this.n.TabIndex = 13;
            this.n.Text = "n = ";
            // 
            // m
            // 
            this.m.Location = new System.Drawing.Point(940, 145);
            this.m.Name = "m";
            this.m.Size = new System.Drawing.Size(25, 20);
            this.m.TabIndex = 14;
            this.m.Text = "m = ";
            // 
            // a_textBox
            // 
            this.a_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.a_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.a_textBox.Location = new System.Drawing.Point(884, 12);
            this.a_textBox.Multiline = true;
            this.a_textBox.Name = "a_textBox";
            this.a_textBox.Size = new System.Drawing.Size(55, 29);
            this.a_textBox.TabIndex = 15;
            this.a_textBox.Text = "1,0";
            this.a_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // b_textBox
            // 
            this.b_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_textBox.Location = new System.Drawing.Point(884, 53);
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
            this.k_textBox.Location = new System.Drawing.Point(884, 93);
            this.k_textBox.Multiline = true;
            this.k_textBox.Name = "k_textBox";
            this.k_textBox.Size = new System.Drawing.Size(55, 31);
            this.k_textBox.TabIndex = 17;
            this.k_textBox.Text = "2";
            this.k_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // p_textBox
            // 
            this.p_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.p_textBox.Location = new System.Drawing.Point(884, 132);
            this.p_textBox.Multiline = true;
            this.p_textBox.Name = "p_textBox";
            this.p_textBox.Size = new System.Drawing.Size(55, 35);
            this.p_textBox.TabIndex = 18;
            this.p_textBox.Text = "2,0";
            this.p_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // c_textBox
            // 
            this.c_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.c_textBox.Location = new System.Drawing.Point(972, 12);
            this.c_textBox.Multiline = true;
            this.c_textBox.Name = "c_textBox";
            this.c_textBox.Size = new System.Drawing.Size(59, 29);
            this.c_textBox.TabIndex = 19;
            this.c_textBox.Text = "0,5";
            this.c_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // w_textBox
            // 
            this.w_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.w_textBox.Location = new System.Drawing.Point(972, 53);
            this.w_textBox.Multiline = true;
            this.w_textBox.Name = "w_textBox";
            this.w_textBox.Size = new System.Drawing.Size(59, 31);
            this.w_textBox.TabIndex = 20;
            this.w_textBox.Text = "0,5";
            this.w_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // n_textBox
            // 
            this.n_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.n_textBox.Location = new System.Drawing.Point(971, 93);
            this.n_textBox.Multiline = true;
            this.n_textBox.Name = "n_textBox";
            this.n_textBox.Size = new System.Drawing.Size(60, 33);
            this.n_textBox.TabIndex = 21;
            this.n_textBox.Text = "4";
            this.n_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_textBox
            // 
            this.m_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.m_textBox.Location = new System.Drawing.Point(970, 131);
            this.m_textBox.Multiline = true;
            this.m_textBox.Name = "m_textBox";
            this.m_textBox.Size = new System.Drawing.Size(61, 34);
            this.m_textBox.TabIndex = 22;
            this.m_textBox.Text = "20";
            this.m_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DrawFButton
            // 
            this.DrawFButton.Location = new System.Drawing.Point(852, 334);
            this.DrawFButton.Name = "DrawFButton";
            this.DrawFButton.Size = new System.Drawing.Size(132, 23);
            this.DrawFButton.TabIndex = 23;
            this.DrawFButton.Text = "Draw function (on/off)";
            this.DrawFButton.UseVisualStyleBackColor = true;
            this.DrawFButton.Click += new System.EventHandler(this.DrawFButton_Click);
            // 
            // DrawQ1Button
            // 
            this.DrawQ1Button.Location = new System.Drawing.Point(852, 363);
            this.DrawQ1Button.Name = "DrawQ1Button";
            this.DrawQ1Button.Size = new System.Drawing.Size(132, 23);
            this.DrawQ1Button.TabIndex = 24;
            this.DrawQ1Button.Text = "Draw Q1 (on/off)";
            this.DrawQ1Button.UseVisualStyleBackColor = true;
            this.DrawQ1Button.Click += new System.EventHandler(this.DrawQ1Button_Click);
            // 
            // DrawQ2Button
            // 
            this.DrawQ2Button.Location = new System.Drawing.Point(852, 392);
            this.DrawQ2Button.Name = "DrawQ2Button";
            this.DrawQ2Button.Size = new System.Drawing.Size(132, 23);
            this.DrawQ2Button.TabIndex = 25;
            this.DrawQ2Button.Text = "Draw Q2 (on/off)";
            this.DrawQ2Button.UseVisualStyleBackColor = true;
            this.DrawQ2Button.Click += new System.EventHandler(this.DrawQ2Button_Click);
            // 
            // DrawQ3Button
            // 
            this.DrawQ3Button.Location = new System.Drawing.Point(852, 421);
            this.DrawQ3Button.Name = "DrawQ3Button";
            this.DrawQ3Button.Size = new System.Drawing.Size(132, 23);
            this.DrawQ3Button.TabIndex = 26;
            this.DrawQ3Button.Text = "Draw Q3 (on/off)";
            this.DrawQ3Button.UseVisualStyleBackColor = true;
            this.DrawQ3Button.Click += new System.EventHandler(this.DrawQ3Button_Click);
            // 
            // DrawQ4Button
            // 
            this.DrawQ4Button.Location = new System.Drawing.Point(852, 450);
            this.DrawQ4Button.Name = "DrawQ4Button";
            this.DrawQ4Button.Size = new System.Drawing.Size(132, 23);
            this.DrawQ4Button.TabIndex = 27;
            this.DrawQ4Button.Text = "Draw Q4 (on/off)";
            this.DrawQ4Button.UseVisualStyleBackColor = true;
            this.DrawQ4Button.Click += new System.EventHandler(this.DrawQ4Button_Click);
            // 
            // RedrawButton
            // 
            this.RedrawButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.RedrawButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RedrawButton.Location = new System.Drawing.Point(852, 476);
            this.RedrawButton.Name = "RedrawButton";
            this.RedrawButton.Size = new System.Drawing.Size(162, 24);
            this.RedrawButton.TabIndex = 28;
            this.RedrawButton.Text = "Redraw";
            this.RedrawButton.UseVisualStyleBackColor = false;
            this.RedrawButton.Click += new System.EventHandler(this.RedrawButton_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Khaki;
            this.label1.Location = new System.Drawing.Point(852, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 159);
            this.label1.TabIndex = 29;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // f_color
            // 
            this.f_color.BackColor = System.Drawing.Color.Red;
            this.f_color.Cursor = System.Windows.Forms.Cursors.Default;
            this.f_color.Location = new System.Drawing.Point(990, 334);
            this.f_color.Name = "f_color";
            this.f_color.Size = new System.Drawing.Size(27, 23);
            this.f_color.TabIndex = 30;
            // 
            // Q1_color
            // 
            this.Q1_color.BackColor = System.Drawing.Color.Yellow;
            this.Q1_color.Location = new System.Drawing.Point(990, 363);
            this.Q1_color.Name = "Q1_color";
            this.Q1_color.Size = new System.Drawing.Size(27, 23);
            this.Q1_color.TabIndex = 31;
            // 
            // Q2_color
            // 
            this.Q2_color.BackColor = System.Drawing.Color.ForestGreen;
            this.Q2_color.Location = new System.Drawing.Point(990, 392);
            this.Q2_color.Name = "Q2_color";
            this.Q2_color.Size = new System.Drawing.Size(27, 23);
            this.Q2_color.TabIndex = 32;
            // 
            // Q3_color
            // 
            this.Q3_color.BackColor = System.Drawing.Color.DarkBlue;
            this.Q3_color.Location = new System.Drawing.Point(990, 421);
            this.Q3_color.Name = "Q3_color";
            this.Q3_color.Size = new System.Drawing.Size(27, 23);
            this.Q3_color.TabIndex = 33;
            // 
            // Q4_color
            // 
            this.Q4_color.BackColor = System.Drawing.Color.MediumVioletRed;
            this.Q4_color.Location = new System.Drawing.Point(990, 450);
            this.Q4_color.Name = "Q4_color";
            this.Q4_color.Size = new System.Drawing.Size(27, 23);
            this.Q4_color.TabIndex = 34;
            // 
            // DevQ1
            // 
            this.DevQ1.Location = new System.Drawing.Point(1022, 363);
            this.DevQ1.Multiline = true;
            this.DevQ1.Name = "DevQ1";
            this.DevQ1.Size = new System.Drawing.Size(88, 23);
            this.DevQ1.TabIndex = 36;
            this.DevQ1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DevQ2
            // 
            this.DevQ2.Location = new System.Drawing.Point(1022, 392);
            this.DevQ2.Multiline = true;
            this.DevQ2.Name = "DevQ2";
            this.DevQ2.Size = new System.Drawing.Size(88, 23);
            this.DevQ2.TabIndex = 37;
            this.DevQ2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DevQ3
            // 
            this.DevQ3.Location = new System.Drawing.Point(1022, 421);
            this.DevQ3.Multiline = true;
            this.DevQ3.Name = "DevQ3";
            this.DevQ3.Size = new System.Drawing.Size(88, 23);
            this.DevQ3.TabIndex = 38;
            this.DevQ3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DevQ4
            // 
            this.DevQ4.Location = new System.Drawing.Point(1022, 450);
            this.DevQ4.Multiline = true;
            this.DevQ4.Name = "DevQ4";
            this.DevQ4.Size = new System.Drawing.Size(88, 22);
            this.DevQ4.TabIndex = 39;
            this.DevQ4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 504);
            this.Controls.Add(this.DevQ4);
            this.Controls.Add(this.DevQ3);
            this.Controls.Add(this.DevQ2);
            this.Controls.Add(this.DevQ1);
            this.Controls.Add(this.Q4_color);
            this.Controls.Add(this.Q3_color);
            this.Controls.Add(this.Q2_color);
            this.Controls.Add(this.Q1_color);
            this.Controls.Add(this.f_color);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RedrawButton);
            this.Controls.Add(this.DrawQ4Button);
            this.Controls.Add(this.DrawQ3Button);
            this.Controls.Add(this.DrawQ2Button);
            this.Controls.Add(this.DrawQ1Button);
            this.Controls.Add(this.DrawFButton);
            this.Controls.Add(this.m_textBox);
            this.Controls.Add(this.n_textBox);
            this.Controls.Add(this.w_textBox);
            this.Controls.Add(this.c_textBox);
            this.Controls.Add(this.p_textBox);
            this.Controls.Add(this.k_textBox);
            this.Controls.Add(this.b_textBox);
            this.Controls.Add(this.a_textBox);
            this.Controls.Add(this.m);
            this.Controls.Add(this.n);
            this.Controls.Add(this.w);
            this.Controls.Add(this.c);
            this.Controls.Add(this.p);
            this.Controls.Add(this.k);
            this.Controls.Add(this.b);
            this.Controls.Add(this.a);
            this.Controls.Add(this.simpleOpenGlControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "МО Лабораторна 5 (Тимчишин Роман, ОМ - 3)";
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
        private System.Windows.Forms.Label p;
        private System.Windows.Forms.Label c;
        private System.Windows.Forms.Label w;
        private System.Windows.Forms.Label n;
        private System.Windows.Forms.Label m;
        private System.Windows.Forms.TextBox a_textBox;
        private System.Windows.Forms.TextBox b_textBox;
        private System.Windows.Forms.TextBox k_textBox;
        private System.Windows.Forms.TextBox p_textBox;
        private System.Windows.Forms.TextBox c_textBox;
        private System.Windows.Forms.TextBox w_textBox;
        private System.Windows.Forms.TextBox n_textBox;
        private System.Windows.Forms.TextBox m_textBox;
        private System.Windows.Forms.Button DrawFButton;
        private System.Windows.Forms.Button DrawQ1Button;
        private System.Windows.Forms.Button DrawQ2Button;
        private System.Windows.Forms.Button DrawQ3Button;
        private System.Windows.Forms.Button DrawQ4Button;
        private System.Windows.Forms.Button RedrawButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label f_color;
        private System.Windows.Forms.Label Q1_color;
        private System.Windows.Forms.Label Q2_color;
        private System.Windows.Forms.Label Q3_color;
        private System.Windows.Forms.Label Q4_color;
        private System.Windows.Forms.TextBox DevQ1;
        private System.Windows.Forms.TextBox DevQ2;
        private System.Windows.Forms.TextBox DevQ3;
        private System.Windows.Forms.TextBox DevQ4;

        public System.Windows.Forms.TextBox DeviationQ1
        {
            get
            {
                return DevQ1;
            }
            set
            {
                DevQ1 = value;
            }
        }
        public System.Windows.Forms.TextBox DeviationQ2
        {
            get
            {
                return DevQ2;
            }
            set
            {
                DevQ2 = value;
            }
        }
        public System.Windows.Forms.TextBox DeviationQ3
        {
            get
            {
                return DevQ3;
            }
            set
            {
                DevQ3 = value;
            }
        }
        public System.Windows.Forms.TextBox DeviationQ4
        {
            get
            {
                return DevQ4;
            }
            set
            {
                DevQ4 = value;
            }
        }
    }
}

