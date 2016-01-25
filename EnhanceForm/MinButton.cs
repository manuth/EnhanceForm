using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EnhanceForm
{
    public class MinButton : Button
    {
        public override Constants.SpecialButton ButtonFunction
        {
            get
            {
                return Constants.SpecialButton.Minimize;
            }
        }

        public override void Draw(object sender, PaintEventArgs e)
        {
            Color darkDarkBlue = Color.FromArgb(Color.DarkBlue.R, Color.DarkBlue.G, Color.DarkBlue.B - 50);
            Color darkerDarkBlue = Color.FromArgb(darkDarkBlue.R, darkDarkBlue.G, darkDarkBlue.B - 20);
            switch (Hovered)
            {
                case ButtonHoverState.None:
                    e.Graphics.Clear(Color.DarkBlue);
                    break;
                case ButtonHoverState.Hovered:
                    e.Graphics.Clear(darkDarkBlue);
                    break;
                case ButtonHoverState.Clicked:
                    e.Graphics.Clear(darkerDarkBlue);
                    e.Graphics.SetClip(new Rectangle(Location.X + 2, Location.Y + 2, Width - 2, Height - 2));
                    e.Graphics.Clear(darkDarkBlue);
                    break;
            }
            e.Graphics.DrawImage(Properties.Resources.Minimize, new PointF
            {
                X = Location.X + Width / 2 - Properties.Resources.Minimize.Width / 2 + (Hovered == ButtonHoverState.Clicked ? 2 : 0),
                Y = Location.Y + Height / 2 - Properties.Resources.Minimize.Height / 2 + (Hovered == ButtonHoverState.Clicked ? 2 : 0)
            });
        }
    }
}
