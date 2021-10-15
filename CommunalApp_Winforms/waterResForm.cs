using CommunalApp_Winforms.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            table.Columns.Add("Цена");
            table.Columns.Add("Показания счетчика за указанный период");
            table.Columns.Add("C");
            table.Columns.Add("По");
            table.Columns.Add("Итоговая цена в руб.");
            DataRow r = table.NewRow();
            r["Цена"] = Form1.Price;
            r["Показания счетчика за указанный период"] = Math.Round(Form1.Volume, 3);
            r["C"] = Form1.BeginDate;
            r["По"] = Form1.FinishDate;
            r["Итоговая цена в руб."] = Math.Round(Form1.PriceForService, 2);
            table.Rows.Add(r);
            dataGridForm2.DataSource = table;
            dataGridForm2.ReadOnly = true; 

        }

        private void saveResults_Click(object sender, EventArgs e)
        {
            if(Form1.pointerService == "water")
            {
                var controller = new WaterController();
                controller.Add(controller.newWaterData);
            }
        }
    }
}
