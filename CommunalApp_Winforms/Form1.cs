using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CommunalApp_Winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            maskWaterBox1.Validating += waterBox_Validating;
            maskWaterVolBox2.Validating += waterValueBox_Validating;
        }

        private void waterValueBox_Validating(object sender, CancelEventArgs e)
        {
            if(String.IsNullOrEmpty(maskWaterBox1.Text))
            {
                errorProvider1.SetError(maskWaterBox1, "Укажите цену 1 куб. м. воды");
            }
            
        }

        private void waterBox_Validating(object sender, EventArgs e)
        {
            
        }
    }
}
