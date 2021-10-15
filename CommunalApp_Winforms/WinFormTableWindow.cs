using System;
using System.Data;
using System.Windows.Forms;

namespace CommunalApp_Winforms
{
    public partial class LoadTableForm : Form
    {
        public LoadTableForm()
        {
            InitializeComponent();
            var table = new DataTable();
            table.Columns.Add("Цена");
            table.Columns.Add("Показания счетчика за указанный период");
            table.Columns.Add("C");
            table.Columns.Add("По");
            table.Columns.Add("Итоговая цена в руб.");

            var waterData = Form1.waterController.WaterList;
            var electricityData = Form1.electricityController.ElectricityList;
            var gasController = Form1.gasController.GasList;
            if (Form1.pointerService == "water")
            {
                if(waterData == null)
                {
                    MessageBox.Show("Не найдено данных");
                }
                foreach (var item in waterData)
                {
                    DataRow r = table.NewRow();
                    r["Цена"] = item.PriceForOne;
                    r["Показания счетчика за указанный период"] = Math.Round(item.Volume, 3);
                    r["C"] = item.FromDate;
                    r["По"] = item.ToDate;
                    r["Итоговая цена в руб."] = Math.Round(item.ResultPrice, 2);
                    table.Rows.Add(r);
                }
            }
            
            
        }
    }
}
