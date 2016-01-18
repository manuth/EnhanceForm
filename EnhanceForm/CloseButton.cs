using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnhanceForm
{
    public class CloseButton : Button
    {
        /// <summary>
        /// Returns the button's function
        /// </summary>
        public override Constants.SpecialButton ButtonFunction
        {
            get
            {
                return Constants.SpecialButton.Close;
            }
        }

        /// <summary>
        /// Draws the button to the border
        /// </summary>
        /// <param name="sender">The form which contains the button</param>
        /// <param name="e">The PaintEventArgs of the form's Paint-Event</param>
        public override void Draw(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(System.Drawing.Color.DarkRed);
            e.Graphics.DrawImage(Properties.Resources.Close, new System.Drawing.PointF
            {
                X = Location.X + Width / 2 - Properties.Resources.Close.Width / 2,
                Y = Location.Y + Height / 2 - Properties.Resources.Close.Height / 2
            });
        }
    }
}
