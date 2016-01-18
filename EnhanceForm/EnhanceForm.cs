using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace EnhanceForm
{
    public partial class EnhanceForm : Form
    {
        #region Fields
        #region Private fields

        /// <summary>
        /// Contains the form's size on ResizeBegin
        /// </summary>
        private Rectangle tmpSize;
        /// <summary>
        /// The border's thickness
        /// </summary>
        private Padding borderSizes = new Padding(5, 30, 5, 5);
        /// <summary>
        /// The color of the border
        /// </summary>
        private Color borderColor = Color.Black;
        /// <summary>
        /// The thickness of the outline
        /// </summary>
        private int outlineSize = 1;
        /// <summary>
        /// The color of the outline
        /// </summary>
        private Color outlineColor = Color.FromArgb(0x77, 0x77, 0x77);
        /// <summary>
        /// The thickness of the inline
        /// </summary>
        private int inlineSize = 1;
        /// <summary>
        /// The color of the inline
        /// </summary>
        private Color inlineColor = Color.FromArgb(0x88, 0x88, 0x88, 0x88);
        /// <summary>
        /// A set of buttons to draw to the border
        /// </summary>
        private ButtonCollection buttons = new ButtonCollection();
        /// <summary>
        /// A value which defines whether the form is active
        /// </summary>
        private bool formActive = false;

        #endregion
        #endregion

        #region Constructors

        public EnhanceForm()
        {
            InitializeComponent();
            tmpSize = ClientRectangle;
            tmpSize.Location = Location;
            Button closeButton = new CloseButton();
            closeButton.Location = new Point
            {
                X = Width - 14 - OutlineSize - closeButton.Width - BorderSizes.Right,
                Y = OutlineSize
            };
            closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttons.Add(closeButton);
        }

        #endregion

        #region Properties
        #region Public properties
        
        [Category("Frame"), Browsable(true)]
        [Description("Defines the thickness of the border")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Padding BorderSizes
        {
            get
            {
                return borderSizes;
            }
            set
            {
                borderSizes = value;
                OnPaddingChanged(EventArgs.Empty);
                Invalidate(true);
            }
        }

        [Category("Frame"), Browsable(true)]
        [Description("Defines the color of the border")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor= value;
                Invalidate(true);
            }
        }

        [Category("Frame"), Browsable(true)]
        [Description("Defines the thickness of the form's outline")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int OutlineSize
        {
            get
            {
                return outlineSize;
            }
            set
            {
                if (value < 0)
                    outlineSize = 1;
                else
                    outlineSize = value;
                OnPaddingChanged(EventArgs.Empty);
                Invalidate(true);
            }
        }

        [Category("Frame"), Browsable(true)]
        [Description("Defines the color of the form's outline")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color OutlineColor
        {
            get
            {
                return outlineColor;
            }
            set
            {
                outlineColor = value;
                Invalidate(true);
            }
        }

        [Category("Frame"), Browsable(true)]
        [Description("Defines the thickness of the form's inline")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int InlineSize
        {
            get
            {
                return inlineSize;
            }
            set
            {
                inlineSize = value;
                OnPaddingChanged(EventArgs.Empty);
                Invalidate(true);
            }
        }

        [Category("Frame"), Browsable(true)]
        [Description("Defines the color of the form's inline")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color InlineColor
        {
            get
            {
                return inlineColor;
            }
            set
            {
                inlineColor = value;
                Invalidate(true);
            }
        }

        [Category("Frame"), Browsable(true)]
        [Description("Defines a set of buttons to draw to the border")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ButtonCollection Buttons
        {
            get
            {
                return buttons;
            }
            set
            {
                buttons = value;
                Invalidate(true);
            }
        }

        #endregion

        #region Private properties

        private Rectangle window
        {
            get
            {
                return new Rectangle
                (
                    0,
                    0,
                    Width,
                    Height
                );
            }
        }

        private Rectangle outline
        {
            get
            {
                return new Rectangle
                (
                    OutlineSize / 2,
                    OutlineSize / 2,
                    Width - OutlineSize,
                    Height - OutlineSize
                );
            }
        }

        private Rectangle outerBorder
        {
            get
            {
                return new Rectangle
                (
                    OutlineSize,
                    OutlineSize,
                    Width - (OutlineSize * 2),
                    Height - (OutlineSize * 2)
                );
            }
        }

        private Rectangle innerBorder
        {
            get
            {
                return new Rectangle
                (
                    Padding.Left - InlineSize,
                    Padding.Top - InlineSize,
                    Width - Padding.Horizontal + (InlineSize * 2),
                    Height - Padding.Vertical + (InlineSize * 2)
                );
            }
        }

        private Rectangle inline
        {
            get
            {
                return new Rectangle
                (
                    Padding.Left - InlineSize + (InlineSize / 2),
                    Padding.Top - InlineSize + (InlineSize / 2),
                    Width - Padding.Horizontal + InlineSize,
                    Height - Padding.Vertical + InlineSize
                );
            }
        }

        private Rectangle clientArea
        {
            get
            {
                return new Rectangle
                (
                    Padding.Left,
                    Padding.Top,
                    Padding.Horizontal,
                    Padding.Vertical
                );
            }
        }

        #endregion

        #region Overridden properties

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                Invalidate(true);
            }
        }

        /// <summary>
        /// Adding dropshadow-effects if aero-shadows aren't available
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp =  base.CreateParams;
                cp.Style |= Constants.WS_SYSMENU;
                if (!Utilities.AeroEnabled)
                   cp.ClassStyle |= Constants.CS_DROPSHADOW;
                if (!DesignMode && Utilities.AeroEnabled)
                {
                    cp.Style |= Constants.WS_SIZEBOX;
                }
                return cp;
            }
        }

        #endregion
        #endregion

        #region Methods
        #region Private methods

        #endregion

        #region Virtual methods

        /// <summary>
        /// Draws the form's outline
        /// </summary>
        protected virtual void PaintOutline(PaintEventArgs e, Rectangle outline)
        {
            e.Graphics.DrawRectangle(new Pen(OutlineColor, OutlineSize), outline);
        }

        /// <summary>
        /// Draws the form's border and buttons etc.
        /// </summary>
        protected virtual void PaintNonClientArea(PaintEventArgs e)
        {
            e.Graphics.Clear(BorderColor);
        }

        /// <summary>
        /// Draws the form's inline
        /// </summary>
        protected virtual void PaintInline(PaintEventArgs e, Rectangle inline)
        {
            e.Graphics.DrawRectangle(new Pen(InlineColor, InlineSize), inline);
        }

        protected virtual void NoClientHitTest(ref Message m)
        {
            Constants.NCHitTest noClientPosition;
            
        }

        #endregion

        #region Public methods

        #endregion

        #region Overridden Methods

        /// <summary>
        /// Drawing stuff
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {

            // Drawing outline
            PaintOutline(e, outline);
            // Drawing border
            e.Graphics.SetClip(outerBorder);
            e.Graphics.ExcludeClip(innerBorder);
            PaintNonClientArea(e);
            e.Graphics.ResetClip();
            // Drawing inline
            e.Graphics.SetClip(innerBorder);
            e.Graphics.ExcludeClip(clientArea);
            PaintInline(e, inline);
            // Drawing buttons
            foreach (Button button in buttons)
            {
                e.Graphics.ResetClip();
                e.Graphics.SetClip(button.Area);
                button.Draw(this, e);
            }
        }

        /// <summary>
        /// Sets the MainContainer's padding and sets it to the border, outline and inline-value
        /// </summary>
        protected override void OnPaddingChanged(EventArgs e)
        {
            Padding = Padding.Add(new Padding(InlineSize), Padding.Add(BorderSizes, new Padding(OutlineSize)));
            Invalidate(true);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            if (tmpSize.Location == Point.Empty)
                tmpSize.Location = Location;
        }

        /// <summary>
        /// Calculate the each button's new position
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            Rectangle currentSize = ClientRectangle;
            currentSize.Location = Location;
            if (tmpSize != Rectangle.Empty)
            {
                Padding difference = new Padding
                {
                    Left = currentSize.Left - tmpSize.Left,
                    Top = currentSize.Top - tmpSize.Top,
                    Right = currentSize.Right - tmpSize.Right,
                    Bottom = currentSize.Bottom - tmpSize.Bottom
                };
                foreach (Button button in buttons)
                {
                    if (button.Anchor.HasFlag(AnchorStyles.Left | AnchorStyles.Right))
                    {
                        button.Location = new Point
                        {
                            X = button.Location.X + difference.Horizontal / 2,
                            Y = button.Location.Y
                        };
                    }
                    else if (button.Anchor.HasFlag(AnchorStyles.Right))
                    {
                        button.Location = new Point
                        {
                            X = button.Location.X + difference.Right - difference.Left,
                            Y = button.Location.Y
                        };
                    }
                    if (button.Anchor.HasFlag(AnchorStyles.Top | AnchorStyles.Bottom))
                    {
                        button.Location = new Point
                        {
                            X = button.Location.X,
                            Y = button.Location.Y + difference.Vertical / 2
                        };
                    }
                    else if (button.Anchor.HasFlag(AnchorStyles.Bottom))
                    {
                        button.Location = new Point
                        {
                            X = button.Location.X,
                            Y = button.Location.Y + difference.Bottom - difference.Top
                        };
                    }
                }
                tmpSize = currentSize;
            }
            Invalidate(true);
            base.OnResize(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                // Avoid message processing if the form is maximized
                // and certain parameteres are given.
                if (m.Msg == Constants.WM_SYSCOMMAND &&
                    m.WParam.ToInt32() == Constants.SC_MOVE ||
                    m.Msg == Constants.WM_NCLBUTTONDOWN &&
                    m.WParam.ToInt32() == (int)Constants.NCHitTest.HTCAPTION)
                {
                    m.Msg = Constants.WM_NULL;
                }
            }
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case Constants.WM_NCCALCSIZE:
                    if (Utilities.AeroEnabled)
                    {
                        int value = 2;
                        Utilities.DwmSetWindowAttribute(Handle, 2, ref value, 4);
                        MARGINS margins = new MARGINS()
                        {
                            leftWidth = OutlineSize,
                            topHeight = OutlineSize,
                            rightWidth = OutlineSize,
                            bottomHeight = OutlineSize
                        };
                        Utilities.DwmExtendFrameIntoClientArea(Handle, ref margins);
                        if (!DesignMode)
                            if (m.WParam.Equals(IntPtr.Zero))
                            {
                                RECT structrect = (RECT)m.GetLParam(typeof(RECT));
                                Rectangle normalrect = structrect.ToRectangle(); normalrect.Inflate(7, 7);
                                Marshal.StructureToPtr(new RECT(normalrect), m.LParam, true);
                            }
                            else
                            {
                                NCCALCSIZE_PARAMS csp = (NCCALCSIZE_PARAMS)m.GetLParam(typeof(NCCALCSIZE_PARAMS));
                                Rectangle normalrect = csp.rgrc0.ToRectangle(); normalrect.Inflate(7, 7); csp.rgrc0 = new RECT(normalrect);
                                Marshal.StructureToPtr(csp, m.LParam, true);
                            }
                        m.Result = IntPtr.Zero;
                    }
                    break;
                case Constants.WM_NCACTIVATE:
                    formActive = m.WParam.ToInt32() != 0;
                    Invalidate(true);
                    break;
                case Constants.WM_NCHITTEST:
                    NoClientHitTest(ref m);
                    if (buttons[0].Area.Contains(PointToClient(MousePosition)))
                        m.Result = new IntPtr((int)Constants.NCHitTest.HTCLOSE);
                    break;
                case Constants.WM_NCMOUSEMOVE:
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        #endregion

        #endregion
    }
}
