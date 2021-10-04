using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CommunalApp_Winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            maskWaterBox1.Validating += maskWaterBox1_Validating;
            maskWaterVolBox2.Validating += maskWaterVolBox2_Validating;
            dateTimePickerStart1.Validating += dateTimePickerStart1_Validating;
            dateTimePickerEnd2.Validating += dateTimePickerEnd2_Validating;
            //table

            var table = new DataTable();
            table.Columns.Add("Цена куб.м. воды");
            table.Columns.Add("Показания счетчика куб. м.");
            table.Columns.Add("C");
            table.Columns.Add("По");
            table.Columns.Add("Итоговая цена в руб.");
            dataGridView1.DataSource = table;

            // ComboBox settings
            comboBoxService.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxService.Items.AddRange(new string[] { "Расчет водоснабжения",
                                                    "Расчет электроэнергии",
                                                    "Расчет газоснабжения"});
            comboBoxService.SelectedIndexChanged += comboBoxService_SelectedIndexChanged;
            comboBoxService.SelectedItem = comboBoxService.Items[1];

            //dateTimePicker setting
        }

        private void dateTimePickerEnd2_Validating(object sender, CancelEventArgs e)
        {
            if (dateTimePickerEnd2.Value <= dateTimePickerStart1.Value)
            {
                errorDate.SetError(dateTimePickerEnd2, "Некорректная дата");
            }
            else
            {
                errorDate.Clear();
            }
        }

        private void dateTimePickerStart1_Validating(object sender, CancelEventArgs e)
        {
            if(dateTimePickerStart1.Value >= dateTimePickerEnd2.Value)
                {
                    errorDate.SetError(dateTimePickerStart1, "Некорректная дата");
                }
            else
            {
                errorDate.Clear();
            }
        }

        private void maskWaterVolBox2_Validating(object sender, CancelEventArgs e)
        {
            if (!maskWaterVolBox2.MaskCompleted)
            {
                errorService.SetError(maskWaterVolBox2, "Значение не может быть пустым");
            }
            else
            {
                errorService.Clear();
            }
        }

        private void maskWaterBox1_Validating(object sender, CancelEventArgs e)
        {
            if(!maskWaterBox1.MaskCompleted)
            {
                errorService.SetError(maskWaterBox1, "Значение не может быть пустым");
            }
        }

        private void comboBoxService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxService.SelectedIndex == 0)
            {
                
            }
        }

        // Error event ComboBox
        
              
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskWaterBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
