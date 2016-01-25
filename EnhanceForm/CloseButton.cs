using System;
using System.Collections.Generic;
using System.Drawing;
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
            Color darkDarkRed = Color.FromArgb(Color.Red.R - 130, Color.Red.G, Color.Red.B);
            Color darkerDarkRed = Color.FromArgb(Color.Red.R - 150, Color.Red.G, Color.Red.B);

            switch (Hovered)
            {
                case ButtonHoverState.None:
                    e.Graphics.Clear(Color.DarkRed);
                    break;
                case ButtonHoverState.Hovered:
                    e.Graphics.Clear(darkDarkRed);
                    break;
                case ButtonHoverState.Clicked:
                    e.Graphics.Clear(darkerDarkRed);
                    e.Graphics.SetClip(new Rectangle(Location.X + 2, Location.Y + 2, Width - 2, Height - 2));
                    e.Graphics.Clear(darkDarkRed);
                    break;
            }
            e.Graphics.DrawImage(Properties.Resources.Close, new PointF
            {
                X = Location.X + Width / 2 - Properties.Resources.Close.Width / 2 + (Hovered == ButtonHoverState.Clicked ? 2 : 0),
                Y = Location.Y + Height / 2 - Properties.Resources.Close.Height / 2 + (Hovered == ButtonHoverState.Clicked ? 2 : 0)
            });
        }
    }
}
