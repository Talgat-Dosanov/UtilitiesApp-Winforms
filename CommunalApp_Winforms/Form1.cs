using CommunalApp_Winforms.Controller;
using CommunalApp_Winforms.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CommunalApp_Winforms
{
    public partial class Form1 : Form
    {

        public static WaterController WaterController { get; private set; }
        public static ElectricityController ElectricityController { get; private set; }
        public static GasController GasController { get; private set; }

        public static int GetSelectIndex { get; private set; }


        public Form1()
        {
            InitializeComponent();

            maskWaterBox1.Validating += maskWaterBox1_TextChanged;
            maskWaterVolBox2.Validating += maskWaterVolBox2_TextChanged;
            dateTimePickerStart1.Validating += dateTimePickerStart1_TextChanged;
            dateTimePickerEnd2.Validating += dateTimePickerEnd2_TextChanged;
            lastMonthBox.Validating += lastMonthBox_TextChanged;



            // ComboBox settings
            comboBoxService.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxService.Items.AddRange(new string[] { "Расчет водоснабжения",
                                                          "Расчет электроэнергии",
                                                          "Расчет газоснабжения"});
            comboBoxService.SelectedItem = comboBoxService.Items[1];


        }

        private void lastMonthBox_TextChanged(object sender, CancelEventArgs e)
        {
            if (maskWaterBox1.MaskFull && maskWaterVolBox2.MaskFull && lastMonthBox.MaskFull)
            {
                calcButton.Enabled = true;
            }
            else
            {
                calcButton.Enabled = false;
            }
            if (!lastMonthBox.MaskCompleted)
            {
                volumeError.SetError(lastMonthBox, "Значение не может быть пустым");
            }

            else
            {
                volumeError.Clear();
                calcButton.Enabled = true;

            }

        }


        private void dateTimePickerEnd2_TextChanged(object sender, CancelEventArgs e)
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

        private void dateTimePickerStart1_TextChanged(object sender, CancelEventArgs e)
        {
            if (dateTimePickerStart1.Value >= dateTimePickerEnd2.Value)
            {
                errorDate.SetError(dateTimePickerStart1, "Некорректная дата");

            }
            else
            {
                errorDate.Clear();

            }
        }

        private void maskWaterVolBox2_TextChanged(object sender, CancelEventArgs e)
        {
            if (maskWaterBox1.MaskFull && maskWaterVolBox2.MaskFull && lastMonthBox.MaskFull)
            {
                calcButton.Enabled = true;
            }
            else
            {
                calcButton.Enabled = false;
            }

            if (!maskWaterVolBox2.MaskCompleted)
            {
                errorService.SetError(maskWaterVolBox2, "Значение не может быть пустым");
            }
            else
            {
                errorService.Clear();
            }
        }

        private void maskWaterBox1_TextChanged(object sender, CancelEventArgs e)
        {
            if (maskWaterBox1.MaskFull && maskWaterVolBox2.MaskFull && lastMonthBox.MaskFull)
            {
                calcButton.Enabled = true;
            }
            else
            {
                calcButton.Enabled = false;
            }
            if (!maskWaterBox1.MaskCompleted)
            {
                errorService.SetError(maskWaterBox1, "Значение не может быть пустым");
            }
            else
            {
                errorService.Clear();

            }
        }


        private void calcButton_Click(object sender, EventArgs e)
        {
            var waterController = new WaterController();
            var electricityController = new ElectricityController();
            var gasController = new GasController();

            var price = Convert.ToDouble(maskWaterBox1.Text);

            var volumeNow = Convert.ToInt32(maskWaterVolBox2.Text);
            var volumeLast = Convert.ToInt32(lastMonthBox.Text);
            string serviceName;
            var beginDate  = dateTimePickerStart1.Value;
            var finishDate = dateTimePickerEnd2.Value;



            if (lastMonthBox.MaskFull == false)
            {
                MessageBox.Show("Значение прошлого показания счетчика не можеть быть пустым");
                return;
            }
            if (maskWaterVolBox2.MaskFull == false)
            {
                MessageBox.Show("Значение текущего показания счетчика не можеть быть пустым");
                return;
            }
            
            


            switch (comboBoxService.SelectedIndex)
            {
                case 0:
                    serviceName = "Вода";
                   
                    waterController.SetNewWaterData(serviceName,
                                                    price,
                                                    volumeLast,
                                                    volumeNow,
                                                    beginDate,
                                                    finishDate);

                    WaterController = waterController;

                    if (CheckDate(beginDate, finishDate) == false)
                    {
                        MessageBox.Show("Некорректная дата");
                        return;
                    }

                    break;
                case 1:
                    serviceName = "Электричество";
                    if (electricityController.ElectricityList.Count != 0)
                    {
                        beginDate = electricityController.GetLastInfo().FromDate;
                    }
                    else
                    {
                        beginDate = dateTimePickerStart1.Value;
                    }
                    electricityController.SetNewElectricityData(serviceName,
                                                                price,
                                                                volumeLast,
                                                                volumeNow,
                                                                beginDate,
                                                                finishDate);


                    ElectricityController = electricityController;

                    if (CheckDate(beginDate, finishDate) == false)
                    {
                        MessageBox.Show("Некорректная дата");
                        return;
                    }

                    break;

                case 2:
                    if (gasController.GasList.Count != 0)
                    {
                        beginDate = gasController.GetLastInfo().FromDate;
                    }
                    else
                    {
                        beginDate = dateTimePickerStart1.Value;
                    }
                    serviceName = "Газ";
                    gasController.SetNewGasData(serviceName,
                                                price,
                                                volumeLast,
                                                volumeNow,
                                                beginDate,
                                                finishDate);

                    GasController = gasController;
                    if (CheckDate(beginDate, finishDate) == false)
                    {
                        MessageBox.Show("Некорректная дата");
                        return;
                    }

                    break;


            }
            if (CheckEnter(volumeLast, volumeNow) == false)
            {
                MessageBox.Show("Текущее показание не может быть равно нулю или меньше показания прошлого месяца");
                return;
            }
            ShowReForm();
         
        }


        public void ShowReForm()
        {
            ResForm resForm = new ResForm();
            resForm.Show();
        }

        public static bool CheckDate(DateTime beginDate, DateTime finishDate)
        {
            if (beginDate >= finishDate || finishDate > DateTime.Now)
            {
                return false;
            }
            return true;

        }
        public static bool CheckEnter(int lastValue, int newValue)
        {
            if(newValue < lastValue || newValue == 0)
            {
                return false;
            }
            return true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            calcButton.Enabled = false;
            lastMonthBox.ReadOnly = false;

        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadTableForm loadInfo = new LoadTableForm();

            switch (comboBoxService.SelectedIndex)
            {
                case 0:
                    var water = new WaterController();

                    if (water.WaterList.Count == 0)
                    {
                        MessageBox.Show("Не найдено данных");
                        return;
                    }
                    loadInfo.Show();
                    break;
                case 1:
                    var electricity = new ElectricityController();
                    if (electricity.ElectricityList.Count == 0)
                    {
                        MessageBox.Show("Не найдено данных");
                        return;

                    }
                    loadInfo.Show();
                    break;
                case 2:
                    var gas = new GasController();
                    if (gas.GasList.Count == 0)
                    {
                        MessageBox.Show("Не найдено данных");
                        return;
                    }
                    loadInfo.Show();
                    break;
            }
        }
        public string GetMaskValue(string volume)
        {
            var mask = "00000000";
            var text = mask.Substring(0, (mask.Length - volume.Length)) + volume;
            return text;
        }

        private void comboBoxService_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectIndex = comboBoxService.SelectedIndex;
            if (comboBoxService.SelectedIndex == 0)
            {
                var waterController = new WaterController();
                if (waterController.WaterList.Count != 0)
                {
                    dateTimePickerStart1.Value = waterController.GetLastInfo().FromDate;
                    var volume = Convert.ToString(waterController.GetLastInfo().Volume);
                    lastMonthBox.Text = GetMaskValue(volume);
                    lastMonthBox.ReadOnly = true;
                }
                else
                {
                    lastMonthBox.ReadOnly = false;
                    lastMonthBox.Clear();
                }

            }
            else if (comboBoxService.SelectedIndex == 1)
            {
                var electricityController = new ElectricityController();
                if (electricityController.ElectricityList.Count != 0)
                {
                    dateTimePickerStart1.Value = electricityController.GetLastInfo().FromDate;
                    var volume = Convert.ToString(electricityController.GetLastInfo().Volume);
                    lastMonthBox.Text = GetMaskValue(volume);
                    lastMonthBox.ReadOnly = true;
                }
                else
                {
                    lastMonthBox.ReadOnly = false;
                    lastMonthBox.Clear();
                }

            }
            else if (comboBoxService.SelectedIndex == 2)
            {
                var gasController = new GasController();
                if (gasController.GasList.Count != 0)
                {
                    dateTimePickerStart1.Value = gasController.GetLastInfo().FromDate;
                    var volume = Convert.ToString(gasController.GetLastInfo().Volume);
                    lastMonthBox.Text = GetMaskValue(volume);
                    lastMonthBox.ReadOnly = true;
                }
                else
                {
                    lastMonthBox.ReadOnly = false;
                    lastMonthBox.Clear();
                }

            }
        }
    }
}
