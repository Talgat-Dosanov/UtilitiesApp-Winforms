
namespace CommunalApp_Winforms
{
    partial class ResForm
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
            this.dataGridForm2 = new System.Windows.Forms.DataGridView();
            this.saveResults = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridForm2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridForm2
            // 
            this.dataGridForm2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridForm2.Location = new System.Drawing.Point(12, 35);
            this.dataGridForm2.Name = "dataGridForm2";
            this.dataGridForm2.Size = new System.Drawing.Size(542, 118);
            this.dataGridForm2.TabIndex = 0;
            // 
            // saveResults
            // 
            this.saveResults.Location = new System.Drawing.Point(217, 165);
            this.saveResults.Name = "saveResults";
            this.saveResults.Size = new System.Drawing.Size(139, 23);
            this.saveResults.TabIndex = 1;
            this.saveResults.Text = "Сохранить результат";
            this.saveResults.UseVisualStyleBackColor = true;
            this.saveResults.Click += new System.EventHandler(this.saveResults_Click);
            // 
            // ResForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 194);
            this.Controls.Add(this.saveResults);
            this.Controls.Add(this.dataGridForm2);
            this.Name = "ResForm";
            this.Text = "Результат расчета";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridForm2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridForm2;
        private System.Windows.Forms.Button saveResults;
    }
}