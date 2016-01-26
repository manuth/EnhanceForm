using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnhanceForm
{
    /// <summary>
    /// Defines a button which can be drawn to the border
    /// </summary>
    public abstract class Button
    {
        /// <summary>
        /// The button's anchor
        /// </summary>
        private AnchorStyles anchor = AnchorStyles.Top | AnchorStyles.Right;

        /// <summary>
        /// The area of the button
        /// </summary>
        private Rectangle area = new Rectangle
        {
            X = 0,
            Y = 0,
            Width = 45,
            Height = 20
        };

        /// <summary>
        /// A value which describes whether the button is hovered
        /// </summary>
        private ButtonHoverState hovered = ButtonHoverState.None;

        /// <summary>
        /// Inizializes a button which can be drawn to the border
        /// </summary>
        public Button()
        {
        }

        /// <summary>
        /// Returns the button's function
        /// </summary>
        public virtual Constants.SpecialButton ButtonFunction
        {
            get
            {
                return Constants.SpecialButton.None;
            }
        }

        /// <summary>
        /// Returns or sets the button's anchor
        /// </summary>
        public AnchorStyles Anchor
        {
            get
            {
                return anchor;
            }
            set
            {
                anchor = value;
            }
        }

        /// <summary>
        /// Returns or sets the width of the button
        /// </summary>
        public int Width
        {
            get
            {
                return area.Width;
            }
            set
            {
                area.Width = value;
            }
        }

        /// <summary>
        /// Returns or sets the height of the button
        /// </summary>
        public int Height
        {
            get
            {
                return area.Height;
            }
            set
            {
                area.Height = value;
            }
        }

        /// <summary>
        /// Returns or sets the location of the button
        /// </summary>
        public Point Location
        {
            get
            {
                return area.Location;
            }
            set
            {
                area.Location = value;
            }
        }

        /// <summary>
        /// Returns or sets the area of the button
        /// </summary>
        public Rectangle Area
        {
            get
            {
                return area;
            }
            set
            {
                area = value;
            }
        }

        /// <summary>
        /// Returns or sets a value which describes whether the button is hovered
        /// </summary>
        public ButtonHoverState Hovered
        {
            get
            {
                return hovered;
            }
            set
            {
                hovered = value;
            }
        }

        /// <summary>
        /// Draws the button to the border
        /// </summary>
        /// <param name="sender">The form which contains the button</param>
        /// <param name="e">The PaintEventArgs of the form's Paint-Event</param>
        public abstract void Draw(object sender, PaintEventArgs e);

        public enum ButtonHoverState
        {
            None,
            Hovered,
            Clicked
        }
    }
}
