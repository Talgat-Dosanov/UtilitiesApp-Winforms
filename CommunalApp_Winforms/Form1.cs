using CommunalApp_Winforms.Controller;
using CommunalApp_Winforms.Model;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CommunalApp_Winforms
{
    public partial class Form1 : Form
    {
        public static double Price { get; private set; }
        public static double Volume { get; private set; }
        public static DateTime BeginDate { get; private set; }
        public static DateTime FinishDate { get; private set; }
        public static double PriceForService { get; private set; }

        public static WaterController waterController { get; private set; }
        public static ElectricityController electricityController { get; private set; }
        public static GasController gasController { get; private set; }
        public static string pointerService { get; private set; }

        

        delegate T ControllerManager<T>() where T : class;
        public Form1()
        {
            InitializeComponent();
            
            maskWaterBox1.Validating += maskWaterBox1_TextChanged;
            maskWaterVolBox2.Validating += maskWaterVolBox2_TextChanged;
            dateTimePickerStart1.Validating += dateTimePickerStart1_TextChanged;
            dateTimePickerEnd2.Validating += dateTimePickerEnd2_TextChanged;
            lastMonthBox.Validating += lastMonthBox_TextChanged;
            //table

           

            // ComboBox settings
            comboBoxService.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxService.Items.AddRange(new string[] { "Расчет водоснабжения",
                                                          "Расчет электроэнергии",
                                                          "Расчет газоснабжения"});
            comboBoxService.SelectedItem = comboBoxService.Items[1];
            
            
        }

        private void lastMonthBox_TextChanged(object sender, CancelEventArgs e)
        {
            if(maskWaterBox1.MaskFull && maskWaterVolBox2.MaskFull && lastMonthBox.MaskFull)
            {
                calcButton.Enabled = true;
            }
            else
            {
                calcButton.Enabled = false;
            }
            if(!lastMonthBox.MaskCompleted)
            {
                volumeError.SetError(lastMonthBox, "Значение не может быть пустым");
            }

            else
            {
                volumeError.Clear();
                
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
            if(dateTimePickerStart1.Value >= dateTimePickerEnd2.Value)
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

        private void maskWaterBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
            if(comboBoxService.SelectedIndex == 0)
            {
                var tableForm = new LoadTableForm();
                
            }
        }
    
        private void calcButton_Click(object sender, EventArgs e)
        {
            waterController = new WaterController();
            electricityController = new ElectricityController();
            gasController = new GasController();
            
            var price = Convert.ToDouble(maskWaterBox1.Text);
            
            double volumeLast;
            var volumeNow = Convert.ToDouble(maskWaterVolBox2.Text);
            var beginDate = dateTimePickerStart1.Value;
            var finishDate = dateTimePickerEnd2.Value;

            

            switch (comboBoxService.SelectedIndex)
            {
                case 0:
                    
                    if (waterController.GetWaterLastInfo() == null)
                    {
                        volumeLast = Convert.ToDouble(lastMonthBox.Text);

                    }
                    else
                    {
                        volumeLast = Convert.ToDouble(waterController.GetLastInfo());
                        lastMonthBox.RejectInputOnFirstFailure = true;
                    }
                    waterController.SetNewWaterData(price,
                                                    volumeLast,
                                                    volumeNow,
                                                    beginDate,
                                                    finishDate);
                    Price = price;
                    Volume = waterController.newWaterData.Volume;
                    BeginDate = beginDate;
                    FinishDate = finishDate;
                    PriceForService = waterController.newWaterData.ResultPrice;

                    CheckVolume(Volume);
                    CheckDate(BeginDate, FinishDate);
                    pointerService = "water";
                    break;
                case 1:
                    if (electricityController.GetElectricityLastInfo() == null)
                    {
                        volumeLast = Convert.ToDouble(lastMonthBox.Text);

                    }
                    else
                    {
                        volumeLast = Convert.ToDouble(electricityController.GetLastInfo());
                        lastMonthBox.RejectInputOnFirstFailure = true;
                    }
                    electricityController.SetNewElectricityData(price,
                                                                volumeLast,
                                                                volumeNow,
                                                                beginDate,
                                                                finishDate);
                    electricityController.SetNewElectricityData(price,
                                                                volumeLast,
                                                                volumeNow,
                                                                beginDate,
                                                                finishDate);
                    Price = price;
                    Volume = electricityController.newElectricityData.Volume;
                    BeginDate = beginDate;
                    FinishDate = finishDate;
                    PriceForService = electricityController.newElectricityData.ResultPrice;
                    CheckVolume(Volume);
                    CheckDate(BeginDate, FinishDate);
                    pointerService = "electricity";
                    break;

                case 2:
                    if (gasController.GetGasLastInfo() == null)
                    {
                        volumeLast = Convert.ToDouble(lastMonthBox.Text);

                    }
                    else
                    {
                        volumeLast = Convert.ToDouble(gasController.GetLastInfo());
                        lastMonthBox.RejectInputOnFirstFailure = true;
                    }
                    gasController.SetNewGasData(price,
                                                volumeLast,
                                                volumeNow,
                                                beginDate,
                                                finishDate);
                    Price = price;
                    Volume = gasController.newGasData.Volume;
                    BeginDate = beginDate;
                    FinishDate = finishDate;
                    PriceForService = gasController.newGasData.ResultPrice;
                    CheckVolume(Volume);
                    CheckDate(BeginDate, FinishDate);
                    pointerService = "gas";
                    break;

            }            
            
        }
        
        public static void CheckVolume(double volume)
        {
            if(volume <= 0)
            {
                MessageBox.Show("Показания счетчика на текущий момент не может быть меньше показания прошлого");
            }
            else
            {
                ResForm resultForm = new ResForm();
                resultForm.Show();
            }
           
        }
           
        public static void CheckDate(DateTime beginDate, DateTime finishDate)
        {
            if(beginDate >= finishDate)
            {
                MessageBox.Show("Некорректная дата");
                
            }
            
        }
        public static bool CheckEnter(string data)
        {
            if(string.IsNullOrEmpty(data))
            {
                MessageBox.Show($"Поля не могут быть пустыми");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calcButton.Enabled = false;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadTableForm loadInfo = new LoadTableForm();
            switch (comboBoxService.SelectedIndex)
            {
                case 0:
                    pointerService = "water";
                    loadInfo.Show();
                    break;
                case 1:
                    pointerService = "electricity";
                    loadInfo.Show();
                    break;
                case 2:
                    pointerService = "gas";
                    loadInfo.Show();
                    break;
            }
        }
    }   
}
