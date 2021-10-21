using CommunalApp_Winforms.Controller;
using System;
using System.Data;
using System.Windows.Forms;

namespace CommunalApp_Winforms
{
    public partial class ResForm : Form
    {
        public ResForm()
        {
            InitializeComponent();
            var table = new DataTable();
            table.Columns.Add("Название");
            table.Columns.Add("Цена");
            table.Columns.Add("Показания счетчика за указанный период");
            table.Columns.Add("C");
            table.Columns.Add("По");
            table.Columns.Add("Итоговая цена в руб.");
            DataRow r = table.NewRow();
            switch (Form1.GetSelectIndex)
            {
                case 0:
                    r["Название"] = Form1.WaterController.newWaterData.ServiceName;
                    r["Цена"] = Form1.WaterController.newWaterData.PriceForOne;
                    r["Показания счетчика за указанный период"] = Form1.WaterController.newWaterData.Volume;
                    r["C"] = Form1.WaterController.newWaterData.FromDate;
                    r["По"] = Form1.WaterController.newWaterData.ToDate;
                    r["Итоговая цена в руб."] = Math.Round(Form1.WaterController.newWaterData.ResultPrice, 2);
                    break;
                case 1:
                    r["Название"] = Form1.ElectricityController.newElectricityData.ServiceName;
                    r["Цена"] = Form1.ElectricityController.newElectricityData.PriceForOne;
                    r["Показания счетчика за указанный период"] = Form1.ElectricityController.newElectricityData.Volume;
                    r["C"] = Form1.ElectricityController.newElectricityData.FromDate;
                    r["По"] = Form1.ElectricityController.newElectricityData.ToDate;
                    r["Итоговая цена в руб."] = Math.Round(Form1.ElectricityController.newElectricityData.ResultPrice, 2);
                    break;
                case 2:
                    r["Название"] = Form1.GasController.newGasData.ServiceName;
                    r["Цена"] = Form1.GasController.newGasData.PriceForOne;
                    r["Показания счетчика за указанный период"] = Form1.GasController.newGasData.Volume;
                    r["C"] = Form1.GasController.newGasData.FromDate;
                    r["По"] = Form1.GasController.newGasData.ToDate;
                    r["Итоговая цена в руб."] = Math.Round(Form1.GasController.newGasData.ResultPrice, 2);
                    break;

            }


            table.Rows.Add(r);
            dataGridForm2.DataSource = table;
            dataGridForm2.ReadOnly = true;

        }

        private void saveResults_Click(object sender, EventArgs e)
        {
            switch (Form1.GetSelectIndex)
            {
                case 0:
                    var waterList = Form1.WaterController.WaterList;
                    Form1.WaterController.Add(waterList, Form1.WaterController.newWaterData);
                    break;
                case 1:

                    var electricityList = Form1.ElectricityController.ElectricityList;
                    Form1.ElectricityController.Add(electricityList, Form1.ElectricityController.newElectricityData);
                    break;
                case 2:
                    var gasList = Form1.GasController.GasList;
                    Form1.GasController.Add(gasList, Form1.GasController.newGasData);
                    break;
            }

            DialogResult result = MessageBox.Show(
                "Данные успешно сохранены!",
                "Сохранение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
        }
       

    }
    
}
