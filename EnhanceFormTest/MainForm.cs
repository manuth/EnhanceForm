using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnhanceFormTest
{
    public partial class MainForm : EnhanceForm.EnhanceForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void button1_Click_2(object sender, EventArgs e)
        {
            MaximumSize = Screen.GetWorkingArea(this).Size;
        }
    }
}
