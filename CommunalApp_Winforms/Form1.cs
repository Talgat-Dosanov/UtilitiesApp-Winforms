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
            var beginDate  = dateTimePickerStart1.Value.Date;
            var finishDate = dateTimePickerEnd2.Value.Date;



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
                    try
                    {
                        serviceName = "Вода";

                        waterController.SetNewWaterData(serviceName,
                                                        price,
                                                        volumeLast,
                                                        volumeNow,
                                                        beginDate,
                                                        finishDate);

                        WaterController = waterController;
                    }
                    catch (ArgumentException ex) when (ex.ParamName == "volumeNow")
                    {
                        MessageBox.Show("Некорректный ввод текущего показания счетчика");
                        return;
                    }
                    catch(ArgumentException ex) when (ex.ParamName == "priceForOne")
                    {
                        MessageBox.Show("Цена за единицу измерения не может быть меньше или равно нулю");
                        return;
                    }
                    catch(ArgumentException ex) when (ex.ParamName == "fromDate")
                    {
                        MessageBox.Show("Некорректная дата");
                        return;
                    }
                    break;
                case 1:
                    try
                    {
                        serviceName = "Электричество";

                        electricityController.SetNewElectricityData(serviceName,
                                                                    price,
                                                                    volumeLast,
                                                                    volumeNow,
                                                                    beginDate,
                                                                    finishDate);


                        ElectricityController = electricityController;
                    }
                    catch (ArgumentException ex) when (ex.ParamName == "volumeNow")
                    {
                        MessageBox.Show("Некорректный ввод текущего показания счетчика");
                        return;
                    }
                    catch (ArgumentException ex) when (ex.ParamName == "priceForOne")
                    {
                        MessageBox.Show("Цена за единицу измерения не может быть меньше или равно нулю");
                        return;
                    }
                    catch (ArgumentException ex) when (ex.ParamName == "fromDate")
                    {
                        MessageBox.Show("Некорректная дата");
                        return;
                    }
                    break;

                case 2:
                    try
                    {

                        serviceName = "Газ";
                        gasController.SetNewGasData(serviceName,
                                                    price,
                                                    volumeLast,
                                                    volumeNow,
                                                    beginDate,
                                                    finishDate);

                        GasController = gasController;
                    }
                    catch (ArgumentException ex) when (ex.ParamName == "volumeNow")
                    {
                        MessageBox.Show("Некорректный ввод текущего показания счетчика");
                        return;
                    }
                    catch (ArgumentException ex) when (ex.ParamName == "priceForOne")
                    {
                        MessageBox.Show("Цена за единицу измерения не может быть меньше или равно нулю");
                        return;
                    }
                    catch (ArgumentException ex) when (ex.ParamName == "fromDate")
                    {
                        MessageBox.Show("Некорректная дата");
                        return;
                    }
                    break;


            }
            ShowReForm();
         
        }


        public void ShowReForm()
        {
            ResForm resForm = new ResForm();
            resForm.Show();
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
        public static string GetMaskValue(string volume)
        {
            var mask = "00000000";
            string text;
            if (mask.Length > volume.Length)
            {
                text = mask.Substring(0, (mask.Length - (volume.Length))) + volume;
            }
            else
            {
                text = volume;
            }
            return text;
        }
        public string GetMaskPrice(string price)
        {
            var mask = "0000";
            string text;
            if (mask.Length > price.Length - 1)
            {
                text = mask.Substring(0, (mask.Length - (price.Length - 1))) + price;
            }
            else
            {
                text = price;
            }
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
                    var price = Convert.ToString(waterController.GetLastInfo().PriceForOne);
                    maskWaterBox1.Text = GetMaskPrice(price);
                    dateTimePickerStart1.Value = waterController.GetLastInfo().ToDate.Date;
                    var volume = Convert.ToString(waterController.GetLastInfo().VolumeNow);
                    lastMonthBox.Text = GetMaskValue(volume);
                    WaterController = waterController;
                }
                else
                {
                    lastMonthBox.Clear();
                }
                

            }
            else if (comboBoxService.SelectedIndex == 1)
            {
                var electricityController = new ElectricityController();
                if (electricityController.ElectricityList.Count != 0)
                {
                    var price = Convert.ToString(electricityController.GetLastInfo().PriceForOne);
                    maskWaterBox1.Text = GetMaskPrice(price);
                    dateTimePickerStart1.Value = electricityController.GetLastInfo().ToDate.Date;
                    var volume = Convert.ToString(electricityController.GetLastInfo().VolumeNow);
                    lastMonthBox.Text = GetMaskValue(volume);
                    ElectricityController = electricityController;
                }
                else
                {
                    lastMonthBox.Clear();
                }

            }
            else if (comboBoxService.SelectedIndex == 2)
            {
                var gasController = new GasController();
                if (gasController.GasList.Count != 0)
                {
                    var price = Convert.ToString(gasController.GetLastInfo().PriceForOne);
                    maskWaterBox1.Text = GetMaskPrice(price);
                    dateTimePickerStart1.Value = gasController.GetLastInfo().ToDate;
                    var volume = Convert.ToString(gasController.GetLastInfo().VolumeNow);
                    lastMonthBox.Text = GetMaskValue(volume);
                    GasController = gasController;
                }
                else
                {
                    lastMonthBox.Clear();
                }

            }
        }
    }
}
