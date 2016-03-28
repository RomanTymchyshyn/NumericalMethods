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
            this.ChooseNodes = new System.Windows.Forms.ComboBox();
            this.EnterN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Redraw = new System.Windows.Forms.Button();
            this.DrawW = new System.Windows.Forms.Button();
            this.NotDrawW = new System.Windows.Forms.Button();
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
            // ChooseNodes
            // 
            this.ChooseNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChooseNodes.FormattingEnabled = true;
            this.ChooseNodes.Items.AddRange(new object[] {
            "Chebyshev Nodes",
            "Equally distant nodes"});
            this.ChooseNodes.Location = new System.Drawing.Point(12, 487);
            this.ChooseNodes.Name = "ChooseNodes";
            this.ChooseNodes.Size = new System.Drawing.Size(121, 21);
            this.ChooseNodes.TabIndex = 2;
            this.ChooseNodes.Text = "Chose Type of Nodes";
            this.ChooseNodes.SelectedIndexChanged += new System.EventHandler(this.ChooseNodes_SelectedIndexChanged);
            this.ChooseNodes.TextUpdate += new System.EventHandler(this.ChooseNodes_TextUpdate);
            // 
            // EnterN
            // 
            this.EnterN.Location = new System.Drawing.Point(197, 488);
            this.EnterN.Name = "EnterN";
            this.EnterN.Size = new System.Drawing.Size(32, 20);
            this.EnterN.TabIndex = 3;
            this.EnterN.Tag = "";
            this.EnterN.TextChanged += new System.EventHandler(this.EnterN_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 490);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter N";
            // 
            // Redraw
            // 
            this.Redraw.Location = new System.Drawing.Point(256, 488);
            this.Redraw.Name = "Redraw";
            this.Redraw.Size = new System.Drawing.Size(75, 23);
            this.Redraw.TabIndex = 5;
            this.Redraw.Text = "Redraw";
            this.Redraw.UseVisualStyleBackColor = true;
            this.Redraw.Click += new System.EventHandler(this.Redraw_Click);
            // 
            // DrawW
            // 
            this.DrawW.Location = new System.Drawing.Point(337, 488);
            this.DrawW.Name = "DrawW";
            this.DrawW.Size = new System.Drawing.Size(75, 23);
            this.DrawW.TabIndex = 6;
            this.DrawW.Text = "DrawW";
            this.DrawW.UseVisualStyleBackColor = true;
            this.DrawW.Click += new System.EventHandler(this.DrawW_Click);
            // 
            // NotDrawW
            // 
            this.NotDrawW.Location = new System.Drawing.Point(418, 488);
            this.NotDrawW.Name = "NotDrawW";
            this.NotDrawW.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NotDrawW.Size = new System.Drawing.Size(109, 23);
            this.NotDrawW.TabIndex = 7;
            this.NotDrawW.Text = "Don\'t draw W";
            this.NotDrawW.UseVisualStyleBackColor = true;
            this.NotDrawW.Click += new System.EventHandler(this.NotDrawW_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 520);
            this.Controls.Add(this.NotDrawW);
            this.Controls.Add(this.DrawW);
            this.Controls.Add(this.Redraw);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnterN);
            this.Controls.Add(this.ChooseNodes);
            this.Controls.Add(this.simpleOpenGlControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
        private System.Windows.Forms.ComboBox ChooseNodes;
        private System.Windows.Forms.TextBox EnterN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Redraw;
        private System.Windows.Forms.Button DrawW;
        private System.Windows.Forms.Button NotDrawW;
    }
}

