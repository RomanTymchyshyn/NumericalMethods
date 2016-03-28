namespace MOLab4
{
    partial class ResultTable
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
            this.TableResult_dataGrid = new System.Windows.Forms.DataGridView();
            this.Hide_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TableResult_dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TableResult_dataGrid
            // 
            this.TableResult_dataGrid.AllowUserToAddRows = false;
            this.TableResult_dataGrid.AllowUserToDeleteRows = false;
            this.TableResult_dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.TableResult_dataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TableResult_dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TableResult_dataGrid.Location = new System.Drawing.Point(1, 1);
            this.TableResult_dataGrid.Name = "TableResult_dataGrid";
            this.TableResult_dataGrid.ReadOnly = true;
            this.TableResult_dataGrid.Size = new System.Drawing.Size(639, 276);
            this.TableResult_dataGrid.TabIndex = 0;
            // 
            // Hide_button
            // 
            this.Hide_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Hide_button.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Hide_button.Location = new System.Drawing.Point(284, 283);
            this.Hide_button.Name = "Hide_button";
            this.Hide_button.Size = new System.Drawing.Size(75, 28);
            this.Hide_button.TabIndex = 1;
            this.Hide_button.Text = "Hide";
            this.Hide_button.UseVisualStyleBackColor = true;
            this.Hide_button.Click += new System.EventHandler(this.Hide_button_Click);
            // 
            // ResultTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(642, 314);
            this.Controls.Add(this.Hide_button);
            this.Controls.Add(this.TableResult_dataGrid);
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Name = "ResultTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResultTable";
            this.Load += new System.EventHandler(this.ResultTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TableResult_dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TableResult_dataGrid;
        private System.Windows.Forms.Button Hide_button;

        public System.Windows.Forms.DataGridView TableResult
        {
            get
            {
                return TableResult_dataGrid;
            }
            set
            {
                TableResult_dataGrid = value;
            }
        }
    }
}