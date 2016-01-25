using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EnhanceForm
{
    public class MaxRestoreButton : Button
    {
        public override Constants.SpecialButton ButtonFunction
        {
            get
            {
                return Constants.SpecialButton.MaximizeRestore;
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
            Image image = null;
            if ((sender as Form).WindowState == FormWindowState.Maximized)
                image = Properties.Resources.Restore;
            else
                image = Properties.Resources.Maximize;
            e.Graphics.DrawImage(image, new PointF
            {
                X = Location.X + Width / 2 - image.Width / 2 + (Hovered == ButtonHoverState.Clicked ? 2 : 0),
                Y = Location.Y + Height / 2 - image.Height / 2 + (Hovered == ButtonHoverState.Clicked ? 2 : 0)
            });
        }
    }
}
