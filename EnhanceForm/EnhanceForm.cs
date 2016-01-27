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
using System.Drawing.Drawing2D;
using System.Threading;

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
        /// The icon's position
        /// </summary>
        private Rectangle iconPosition = new Rectangle(8, 8, 16, 16);
        /// <summary>
        /// A set of buttons to draw to the border
        /// </summary>
        private ButtonCollection buttons = new ButtonCollection();
        /// <summary>
        /// The taskbar-progressbar-style
        /// </summary>
        private TaskbarProgressBarState progressState = TaskbarProgressBarState.Normal;
        /// <summary>
        /// The progress of the taskbar-progressbar
        /// </summary>
        private int progressPercentage = 0;
        /// <summary>
        /// A value which defines whether the form is active
        /// </summary>
        private bool formActive = false;
        /// <summary>
        /// The font of the form title
        /// </summary>
        private Font titleFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        /// <summary>
        /// The color of the form title
        /// </summary>
        private Color titleFontColor = Color.White;

        #endregion
        #endregion

        #region Properties
        #region Public properties
        
        [Category("EnhanceForm"), Browsable(true)]
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

        [Category("EnhanceForm"), Browsable(true)]
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

        [Category("EnhanceForm"), Browsable(true)]
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

        [Category("EnhanceForm"), Browsable(true)]
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

        [Category("EnhanceForm"), Browsable(true)]
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

        [Category("EnhanceForm"), Browsable(true)]
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

        [Category("EnhanceForm")]
        [Description("Defines the position of the icon")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Rectangle IconPosition
        {
            get
            {
                return iconPosition;
            }
            set
            {
                iconPosition = value;
                Invalidate(true);
            }
        }

        [Category("EnhanceForm"), Browsable(true)]
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

        [Category("EnhanceForm"), Browsable(true)]
        [Description("Defines the form's progress-state")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public TaskbarProgressBarState ProgressState
        {
            get
            {
                return progressState;
            }
            set
            {
                if (!DesignMode)
                    try
                    {
                        TaskbarManager.Instance.SetProgressState(value);
                    }
                    catch { }
                progressState = value;
            }
        }

        [Category("EnhanceForm"), Browsable(true)]
        [Description("Defines the form's progress-percentage")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ProgressPercentage
        {
            get
            {
                return progressPercentage;
            }
            set
            {
                if (!DesignMode)
                    try
                    {
                        TaskbarManager.Instance.SetProgressValue(value, 100);
                    }
                    catch { }
                progressPercentage = value;
            }
        }

        [Category("Darstellung"), Browsable(true)]
        [Description("Defines the font of the form-title")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font TitleFont
        {
            get
            {
                return titleFont;
            }
            set
            {
                titleFont = value;
                Invalidate(true);
            }
        }

        [Category("Darstellung"), Browsable(true)]
        [Description("Defines the color of the form-title")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TitleFontColor
        {
            get
            {
                return titleFontColor;
            }
            set
            {
                titleFontColor = value;
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

        private Rectangle sizingBorder
        {
            get
            {
                return new Rectangle
                (
                    Constants.SizingBorder,
                    Constants.SizingBorder,
                    Width - Constants.SizingBorder * 2,
                    Height - Constants.SizingBorder * 2
                );
            }
        }

        private Rectangle controlBox
        {
            get
            {
                return new Rectangle
                (
                    IconPosition.Right,
                    0,
                    Width - IconPosition.Right,
                    caption.Height
                );
            }
        }

        private Rectangle outline
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

        private Rectangle caption
        {
            get
            {
                return new Rectangle
                (
                    outerBorder.X,
                    outerBorder.Y,
                    outerBorder.Width,
                    innerBorder.Y - outerBorder.Y
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

        private Rectangle titleBox
        {
            get
            {
                return Rectangle.FromLTRB
                (
                    IconPosition.Right + 5,
                    OutlineSize,
                    Buttons.Count > 0 ? Buttons.Min(button => button.Area.Left) : Width - OutlineSize,
                    BorderSizes.Top
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

        #region Constructors

        public EnhanceForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            tmpSize = ClientRectangle;
            tmpSize.Location = Location;
            Button closeButton = new CloseButton();
            closeButton.Location = new Point
            {
                X = Width - OutlineSize - closeButton.Width - BorderSizes.Right - (Utilities.AeroEnabled ? 2 * Constants.AeroExtraBorder : 0),
                Y = OutlineSize
            };
            Button maxRestoreButton = new MaxRestoreButton();
            maxRestoreButton.Location = new Point
            {
                X = closeButton.Area.X - maxRestoreButton.Width - 2,
                Y = OutlineSize
            };
            Button minButton = new MinButton();
            minButton.Location = new Point
            {
                X = maxRestoreButton.Area.X - minButton.Width - 1,
                Y = OutlineSize
            };
            minButton.Anchor = maxRestoreButton.Anchor = closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttons.Add(closeButton);
            buttons.Add(maxRestoreButton);
            buttons.Add(minButton);
        }

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
            Pen outlinePen = new Pen(OutlineColor, OutlineSize);
            outline.Width -= (outlinePen.Width <= 1 ? 1 : 0);
            outline.Height -= (outlinePen.Width <= 1 ? 1 : 0);
            outlinePen.Alignment = PenAlignment.Inset;
            e.Graphics.DrawRectangle(outlinePen, outline);
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

        /// <summary>
        /// Draws the form's icon
        /// </summary>
        protected virtual void PaintIcon(PaintEventArgs e, Rectangle iconPosition)
        {
            e.Graphics.DrawImage(Icon.ToBitmap(), IconPosition);
        }

        protected virtual IntPtr NonClientHitTest(IntPtr param)
        {
            Constants.NCHitTest nonClientPosition = Constants.NCHitTest.HTCLIENT;
            Point mousePosition = PointToClient(new Point(param.ToInt32()));
            if (caption.Contains(mousePosition))
                nonClientPosition = Constants.NCHitTest.HTCAPTION;
            if (window.Contains(mousePosition) && !sizingBorder.Contains(mousePosition))
            {
                int edge = Padding.Left;
                if (Padding.Top > edge)
                    edge = Padding.Top;
                if (Padding.Right > edge)
                    edge = Padding.Right;
                if (Padding.Bottom > edge)
                    edge = Padding.Bottom;

                if (mousePosition.X < edge)
                {
                    if (mousePosition.Y < edge)
                        nonClientPosition = Constants.NCHitTest.HTTOPLEFT;
                    else if (mousePosition.Y > Height - edge)
                        nonClientPosition = Constants.NCHitTest.HTBOTTOMLEFT;
                    else
                        nonClientPosition = Constants.NCHitTest.HTLEFT;
                }
                else if (mousePosition.X > Width - edge)
                {
                    if (mousePosition.Y < edge)
                        nonClientPosition = Constants.NCHitTest.HTTOPRIGHT;
                    else if (mousePosition.Y > Height - edge)
                        nonClientPosition = Constants.NCHitTest.HTBOTTOMRIGHT;
                    else
                        nonClientPosition = Constants.NCHitTest.HTRIGHT;
                }
                else
                {
                    if (mousePosition.Y < edge)
                        nonClientPosition = Constants.NCHitTest.HTTOP;
                    else if (mousePosition.Y > Height - edge)
                        nonClientPosition = Constants.NCHitTest.HTBOTTOM;
                }
            }
            foreach (Button button in buttons)
            {
                if (button.Area.Contains(mousePosition))
                {
                    nonClientPosition = Constants.NCHitTest.HTBORDER;
                    if (!MouseButtons.HasFlag(MouseButtons.Left))
                        button.Hovered = Button.ButtonHoverState.Hovered;
                    else
                        button.Hovered = Button.ButtonHoverState.Clicked;
                }
                else
                    button.Hovered = Button.ButtonHoverState.None;
            }
            if (IconPosition.Contains(mousePosition))
                nonClientPosition = Constants.NCHitTest.HTBORDER;
            return new IntPtr((int)nonClientPosition);
        }

        protected virtual void OnNonClientDoubleClick(IntPtr lParam)
        {
            Point mousePosition = PointToClient(new Point(lParam.ToInt32()));
            if (IconPosition.Contains(mousePosition))
                sendMessage(Constants.WM_SYSCOMMAND, (IntPtr)Constants.SpecialCommands.SC_CLOSE, IntPtr.Zero);
        }

        private void OnNonClientLButtonDown(IntPtr lParam)
        {
            Point mousePosition = PointToClient(new Point(lParam.ToInt32()));
            foreach (Button button in buttons)
            {
                if (button.Area.Contains(mousePosition))
                {
                    button.Hovered = Button.ButtonHoverState.Clicked;
                }
            }
            Invalidate();
        }

        protected virtual void OnNonClientLButtonUp(IntPtr lParam)
        {
            Constants.SpecialCommands command = Constants.SpecialCommands.SC_DEFAULT;
            Point mousePosition = PointToClient(new Point(lParam.ToInt32()));
            if (IconPosition.Contains(mousePosition))
            {
                Point contextMenuPosition = new Point
                {
                    X = MousePosition.X,
                    Y = MousePosition.Y + 25
                };
                IntPtr hWnd = Handle;
                RECT pos;
                Utilities.GetWindowRect(hWnd, out pos);
                IntPtr hMenu = Utilities.GetSystemMenu(hWnd, false);
                int cmd = Utilities.TrackPopupMenu(hMenu, 0x100, contextMenuPosition.X, contextMenuPosition.Y, 0, hWnd, IntPtr.Zero);
                if (cmd > 0) Utilities.SendMessage(hWnd, 0x112, (IntPtr)cmd, IntPtr.Zero);
            }
            else
            {
                foreach (Button button in buttons)
                {
                    if (button.Area.Contains(mousePosition))
                    {
                        button.Hovered = Button.ButtonHoverState.Hovered;
                        switch (button.ButtonFunction)
                        {
                            case Constants.SpecialButton.Minimize:
                                command = Constants.SpecialCommands.SC_MINIMIZE;
                                break;
                            case Constants.SpecialButton.MaximizeRestore:
                                if (WindowState == FormWindowState.Maximized)
                                    command = Constants.SpecialCommands.SC_RESTORE;
                                else
                                    command = Constants.SpecialCommands.SC_MAXIMIZE;
                                break;
                            case Constants.SpecialButton.Help:
                                command = Constants.SpecialCommands.SC_CONTEXTHELP;
                                break;
                            case Constants.SpecialButton.Close:
                                command = Constants.SpecialCommands.SC_CLOSE;
                                break;
                        }
                    }
                }
                sendMessage(Constants.WM_SYSCOMMAND, (IntPtr)command, IntPtr.Zero);
                Invalidate();
            }
        }

        private void OnNonClientRButtonUp(IntPtr lParam)
        {
            Point mousePosition = PointToClient(new Point(lParam.ToInt32()));
            if (controlBox.Contains(mousePosition))
                sendMessage(Constants.WM_GETSYSMENU, IntPtr.Zero, lParam);
        }

        /// <summary>
        /// Sends a message into the message loop.
        /// </summary>
        private void sendMessage(int msg, IntPtr wParam, IntPtr lParam)
        {
            var message = Message.Create(this.Handle, msg, wParam, lParam);
            this.WndProc(ref message);
        }

        #endregion

        #region Public methods

        public void FlashTaskbar(bool Revert)
        {
            Utilities.FlashWindow(Handle, Revert);
        }

        #endregion

        #region Overridden Methods

        protected override void OnLoad(EventArgs e)
        {
            MaximizedBounds = Screen.GetWorkingArea(this);
            base.OnLoad(e);
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            if (!DesignMode)
            {
                try
                {
                    TaskbarManager.Instance.SetProgressState(ProgressState);
                    TaskbarManager.Instance.SetProgressValue(ProgressPercentage, 100);
                }
                catch { }
            }
            base.OnInvalidated(e);
        }

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
            e.Graphics.ResetClip();
            // Drawing button
            e.Graphics.SetClip(IconPosition);
            PaintIcon(e, IconPosition);
            // Drawing buttons
            foreach (Button button in buttons)
            {
                e.Graphics.ResetClip();
                e.Graphics.SetClip(button.Area);
                button.Draw(this, e);
            }
            string title = Text;
            Size textSize = new Size();
            if ((textSize = TextRenderer.MeasureText(title, TitleFont)).Width > titleBox.Width)
            {
                while ((textSize = TextRenderer.MeasureText(title + "…", TitleFont)).Width > titleBox.Width && title.Length > 0)
                {
                    title = title.Remove(title.Length - 1);
                }
                if (title.Length > 0)
                    title += "…";
            }
            e.Graphics.ResetClip();
            e.Graphics.SetClip(titleBox);
            e.Graphics.DrawString(title, TitleFont, new SolidBrush(TitleFontColor), titleBox.X + titleBox.Width / 2 - textSize.Width / 2, titleBox.Y + titleBox.Height / 2 - textSize.Height / 2);
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
                            leftWidth = 1,
                            topHeight = 1,
                            rightWidth = 1,
                            bottomHeight = 1
                        };
                        Utilities.DwmExtendFrameIntoClientArea(Handle, ref margins);
                        if (!DesignMode)
                            if (m.WParam.Equals(IntPtr.Zero))
                            {
                                RECT structrect = (RECT)m.GetLParam(typeof(RECT));
                                Rectangle normalrect = structrect.ToRectangle();
                                normalrect.Inflate(Constants.AeroExtraBorder, Constants.AeroExtraBorder);
                                Marshal.StructureToPtr(new RECT(normalrect), m.LParam, true);
                            }
                            else
                            {
                                NCCALCSIZE_PARAMS csp = (NCCALCSIZE_PARAMS)m.GetLParam(typeof(NCCALCSIZE_PARAMS));
                                Rectangle normalrect = csp.rgrc0.ToRectangle();
                                normalrect.Inflate(Constants.AeroExtraBorder, Constants.AeroExtraBorder);
                                csp.rgrc0 = new RECT(normalrect);
                                Marshal.StructureToPtr(csp, m.LParam, true);
                            }
                        m.Result = IntPtr.Zero;
                    }
                    break;
                case Constants.WM_NCLBUTTONDOWN:
                    OnNonClientLButtonDown(m.LParam);
                    break;
                case Constants.WM_NCLBUTTONUP:
                    OnNonClientLButtonUp(m.LParam);
                    break;
                case Constants.WM_NCRBUTTONUP:
                    OnNonClientRButtonUp(m.LParam);
                    break;
                case Constants.WM_NCLBUTTONDBLCLK:
                    OnNonClientDoubleClick(m.LParam);
                    break;
                case Constants.WM_NCACTIVATE:
                    formActive = m.WParam.ToInt32() != 0;
                    Invalidate(true);
                    break;
                case Constants.WM_NCHITTEST:
                    m.Result = NonClientHitTest(m.LParam);
                    break;
                case Constants.WM_NCMOUSEMOVE:
                    Invalidate();
                    break;
                case Constants.WM_NCMOUSELEAVE:
                    foreach (Button button in buttons)
                        button.Hovered = Button.ButtonHoverState.None;
                    Invalidate();
                    break;
                case Constants.WM_MOVE:
                    Rectangle bounds = Screen.GetWorkingArea(this);
                    bounds.Location = Point.Empty;
                    MaximizedBounds = bounds;
                    break;
                case Constants.WM_SIZE:
                    if (m.WParam.ToInt32() == 2)
                    {
                        if (MaximumSize != Screen.GetWorkingArea(this).Size)
                        {
                            sendMessage(Constants.WM_SYSCOMMAND, (IntPtr)Constants.SpecialCommands.SC_RESTORE, IntPtr.Zero);
                            MaximumSize = Screen.GetWorkingArea(this).Size;
                            sendMessage(Constants.WM_SYSCOMMAND, (IntPtr)Constants.SpecialCommands.SC_MAXIMIZE, IntPtr.Zero);
                        }
                    }
                    else if (MaximumSize == Screen.GetWorkingArea(this).Size)
                    {
                        MaximumSize = Size.Empty;
                    }
                    break;
            }
        }

        #endregion

        #endregion
    }
}
