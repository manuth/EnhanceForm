using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EnhanceForm
{
    public class MinMaxButton : Button
    {
        public override void Draw(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Blue);
        }
    }
}
