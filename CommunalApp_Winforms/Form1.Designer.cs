
namespace CommunalApp_Winforms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorService = new System.Windows.Forms.ErrorProvider(this.components);
            this.maskWaterBox1 = new System.Windows.Forms.MaskedTextBox();
            this.maskWaterVolBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerStart1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd2 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxService = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.errorDate = new System.Windows.Forms.ErrorProvider(this.components);
            this.calcButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lastMonthBox = new System.Windows.Forms.MaskedTextBox();
            this.volumeError = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeError)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.AliceBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(21, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите цену  за 1  ед. изм.: ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(21, 218);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введите текущее показание счетчика : ";
            // 
            // errorService
            // 
            this.errorService.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorService.ContainerControl = this;
            this.errorService.Icon = ((System.Drawing.Icon)(resources.GetObject("errorService.Icon")));
            // 
            // maskWaterBox1
            // 
            this.maskWaterBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskWaterBox1.Location = new System.Drawing.Point(378, 123);
            this.maskWaterBox1.Margin = new System.Windows.Forms.Padding(4);
            this.maskWaterBox1.Mask = "0.00";
            this.maskWaterBox1.Name = "maskWaterBox1";
            this.maskWaterBox1.Size = new System.Drawing.Size(155, 26);
            this.maskWaterBox1.TabIndex = 4;
            this.maskWaterBox1.ValidatingType = typeof(int);
            // 
            // maskWaterVolBox2
            // 
            this.maskWaterVolBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskWaterVolBox2.Location = new System.Drawing.Point(378, 218);
            this.maskWaterVolBox2.Margin = new System.Windows.Forms.Padding(4);
            this.maskWaterVolBox2.Mask = "00000000";
            this.maskWaterVolBox2.Name = "maskWaterVolBox2";
            this.maskWaterVolBox2.Size = new System.Drawing.Size(155, 26);
            this.maskWaterVolBox2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(21, 265);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(314, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Выберите дату  начала расчета: ";
            // 
            // dateTimePickerStart1
            // 
            this.dateTimePickerStart1.CustomFormat = "";
            this.dateTimePickerStart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerStart1.Location = new System.Drawing.Point(378, 265);
            this.dateTimePickerStart1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerStart1.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerStart1.Name = "dateTimePickerStart1";
            this.dateTimePickerStart1.Size = new System.Drawing.Size(155, 26);
            this.dateTimePickerStart1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(21, 314);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(314, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Выберите дату конца расчета :";
            // 
            // dateTimePickerEnd2
            // 
            this.dateTimePickerEnd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerEnd2.Location = new System.Drawing.Point(378, 313);
            this.dateTimePickerEnd2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerEnd2.Name = "dateTimePickerEnd2";
            this.dateTimePickerEnd2.Size = new System.Drawing.Size(155, 26);
            this.dateTimePickerEnd2.TabIndex = 10;
            // 
            // comboBoxService
            // 
            this.comboBoxService.FormattingEnabled = true;
            this.comboBoxService.Location = new System.Drawing.Point(16, 59);
            this.comboBoxService.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxService.Name = "comboBoxService";
            this.comboBoxService.Size = new System.Drawing.Size(219, 24);
            this.comboBoxService.TabIndex = 11;
            this.comboBoxService.SelectedIndexChanged += new System.EventHandler(this.comboBoxService_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.SkyBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(16, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Вид расчета";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(20, 383);
            this.loadButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(167, 28);
            this.loadButton.TabIndex = 13;
            this.loadButton.Text = "Прошлые показания";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // errorDate
            // 
            this.errorDate.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorDate.ContainerControl = this;
            this.errorDate.Icon = ((System.Drawing.Icon)(resources.GetObject("errorDate.Icon")));
            // 
            // calcButton
            // 
            this.calcButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calcButton.Location = new System.Drawing.Point(378, 383);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(129, 28);
            this.calcButton.TabIndex = 15;
            this.calcButton.Text = "Расчитать";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(20, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(315, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "Показания счетчика за прошлый месяц: ";
            // 
            // lastMonthBox
            // 
            this.lastMonthBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastMonthBox.Location = new System.Drawing.Point(378, 175);
            this.lastMonthBox.Mask = "00000000";
            this.lastMonthBox.Name = "lastMonthBox";
            this.lastMonthBox.Size = new System.Drawing.Size(155, 26);
            this.lastMonthBox.TabIndex = 17;
            this.lastMonthBox.ValidatingType = typeof(int);
            // 
            // volumeError
            // 
            this.volumeError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.volumeError.ContainerControl = this;
            this.volumeError.Icon = ((System.Drawing.Icon)(resources.GetObject("volumeError.Icon")));
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(577, 447);
            this.Controls.Add(this.lastMonthBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.calcButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxService);
            this.Controls.Add(this.dateTimePickerEnd2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerStart1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maskWaterVolBox2);
            this.Controls.Add(this.maskWaterBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorService;
        private System.Windows.Forms.MaskedTextBox maskWaterVolBox2;
        private System.Windows.Forms.MaskedTextBox maskWaterBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd2;
        private System.Windows.Forms.ComboBox comboBoxService;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.ErrorProvider errorDate;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.MaskedTextBox lastMonthBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider volumeError;
    }
}

