using CommunalApp_Winforms.Controller;
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
            table.Columns.Add("Название");
            table.Columns.Add("Цена");
            table.Columns.Add("Показания счетчика за указанный период");
            table.Columns.Add("C");
            table.Columns.Add("По");
            table.Columns.Add("Итоговая цена в руб.");
            dataGridView1.DataSource = table;
            dataGridView1.ReadOnly = true;



            switch (Form1.GetSelectIndex)
            {
                case 0:
                    var water = new WaterController();
                    foreach (var item in water.GetAllItems())
                    {
                        DataRow r = table.NewRow();
                        r["Название"] = item.ServiceName;
                        r["Цена"] = item.PriceForOne;
                        r["Показания счетчика за указанный период"] = item.Volume;
                        r["C"] = item.FromDate;
                        r["По"] = item.ToDate;
                        r["Итоговая цена в руб."] = Math.Round(item.ResultPrice, 2);
                        table.Rows.Add(r);
                    }
                    break;
                case 1:
                    var electricity = new ElectricityController();
                    foreach (var item in electricity.GetAllItems())
                    {
                        DataRow r = table.NewRow();
                        r["Название"] = item.ServiceName;
                        r["Цена"] = item.PriceForOne;
                        r["Показания счетчика за указанный период"] = item.Volume;
                        r["C"] = item.FromDate;
                        r["По"] = item.ToDate;
                        r["Итоговая цена в руб."] = Math.Round(item.ResultPrice, 2);
                        table.Rows.Add(r);
                    }
                    break;
                case 2:
                    var gas = new GasController();
                    foreach (var item in gas.GetAllItems())
                    {
                        DataRow r = table.NewRow();
                        r["Название"] = item.ServiceName;
                        r["Цена"] = item.PriceForOne;
                        r["Показания счетчика за указанный период"] = item.Volume;
                        r["C"] = item.FromDate;
                        r["По"] = item.ToDate;
                        r["Итоговая цена в руб."] = Math.Round(item.ResultPrice, 2);
                        table.Rows.Add(r);
                    }
                    break;
            }

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            switch (Form1.GetSelectIndex)
            {
                case 0:
                    var water = new WaterController();
                    water.DeleteLast();
                    break;
                case 1:
                    var electricity = new ElectricityController();
                    electricity.DeleteLast();
                    break;

                case 2:
                    var gas = new GasController();
                    gas.DeleteLast();
                    break;
            }

            DialogResult result = MessageBox.Show(
               "Данные успешно удалены!",
               "Удаление",
               MessageBoxButtons.OK,
               MessageBoxIcon.Asterisk);

            if (result == DialogResult.OK)
            {
                this.Close();
                LoadTableForm newForm = new LoadTableForm();
                newForm.Show();
            }

        }

    }
}
