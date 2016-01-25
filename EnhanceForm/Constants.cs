using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EnhanceForm
{
    public static class Constants
    {
        public const int AeroExtraBorder = 7;
        public const int SizingBorder = 5;

        public const int CS_DROPSHADOW = 0x20000;

        public const int WM_NULL = 0x0000;
        public const int WM_CREATE = 0x0001;
        public const int WM_MOVE = 0x03;
        public const int WM_ACTIVATE = 0x0006;
        public const int WM_PAINT = 0x000F;
        public const int WM_WINDOWPOSCHANGED = 0x0047;
        public const int WM_HELP = 0x0053;
        public const int WM_NCCALCSIZE = 0x0083;
        public const int WM_NCHITTEST = 0x84;
        public const int WM_NCPAINT = 0x0085;
        public const int WM_NCACTIVATE = 0x0086;
        public const int WM_NCMOUSEMOVE = 0xA0;
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        public const int WM_NCLBUTTONUP = 0x00A2;
        public const int WM_NCLBUTTONDBLCLK = 0x00A3;
        public const int WM_NCRBUTTONUP = 0x00A5;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int WM_NCMOUSELEAVE = 0x02A2;
        public const int WM_GETSYSMENU = 0x313;


        public const int WS_THICKFRAME = 0x00040000;
        public const int WS_SIZEBOX = 0x00040000;
        public const int WS_SYSMENU = 0x00080000;
        public const int WS_DLGFRAME = 0x00400000;
        public const int WS_BORDER = 0x00800000;
        public const int WS_CAPTION = 0x00C00000;

        public const int WVR_VALIDRECTS = 0x400;

        public const int DCX_WINDOW = 0x00000001;
        public const int DCX_CACHE = 0x00000002;
        public const int DCX_PARENTCLIP = 0x00000020;
        public const int DCX_CLIPSIBLINGS = 0x00000010;
        public const int DCX_CLIPCHILDREN = 0x00000008;
        public const int DCX_NORESETATTRS = 0x00000004;
        public const int DCX_LOCKWINDOWUPDATE = 0x00000400;
        public const int DCX_EXCLUDERGN = 0x00000040;
        public const int DCX_INTERSECTRGN = 0x00000080;
        public const int DCX_INTERSECTUPDATE = 0x00000200;
        public const int DCX_VALIDATE = 0x00200000;

        public enum SpecialCommands : int
        {
            /// <summary>
            /// Closes the window.
            /// </summary>
            SC_CLOSE = 0xF060,
            /// <summary>
            /// Changes the cursor to a question mark with a pointer.
            /// If the user then clicks a control in the dialog box, the control receives a <see cref="WM_HELP"/> message.
            /// </summary>
            SC_CONTEXTHELP = 0xF180,
            /// <summary>
            /// Selects the default item; the user double-clicked the window menu.
            /// </summary>
            SC_DEFAULT = 0xF160,
            /// <summary>
            /// Activates the window associated with the application-specified hot key.
            /// The lParam parameter identifies the window to activate.
            /// </summary>
            SC_HOTKEY = 0xF150,
            /// <summary>
            /// Scrolls horizontally.
            /// </summary>
            SC_HSCROLL = 0xF080,
            /// <summary>
            /// Indicates whether the screen saver is secure.
            /// </summary>
            SCF_ISSECURE = 0x00000001,
            /// <summary>
            /// Retrieves the window menu as a result of a keystroke.
            /// For more information, see the Remarks section.
            /// </summary>
            SC_KEYMENU = 0xF100,
            /// <summary>
            /// Maximizes the window.
            /// </summary>
            SC_MAXIMIZE = 0xF030,
            /// <summary>
            /// Minimizes the window.
            /// </summary>
            SC_MINIMIZE = 0xF020,
            /// <summary>
            /// Sets the state of the display. This command supports devices that have power-saving features, such as a battery-powered personal computer.
            /// The lParam parameter can have the following values:
            /// -1 (the display is powering on)
            ///  1 (the display is going to low power)
            ///  2 (the display is being shut off)
            /// </summary>
            SC_MONITORPOWER = 0xF170,
            /// <summary>
            /// Retrieves the window menu as a result of a mouse click.
            /// </summary>
            SC_MOUSEMENU = 0xF090,
            /// <summary>
            /// Moves the window.
            /// </summary>
            SC_MOVE = 0xF010,
            /// <summary>
            /// Moves to the next window.
            /// </summary>
            SC_NEXTWINDOW = 0xF040,
            /// <summary>
            /// Moves to the previous window.
            /// </summary>
            SC_PREVWINDOW = 0xF050,
            /// <summary>
            /// Restores the window to its normal position and size.
            /// </summary>
            SC_RESTORE = 0xF120,
            /// <summary>
            /// Executes the screen saver application specified in the [boot] section of the System.ini file.
            /// </summary>
            SC_SCREENSAVE = 0xF140,
            /// <summary>
            /// Sizes the window.
            /// </summary>
            SC_SIZE = 0xF000,
            /// <summary>
            /// Activates the Start menu.
            /// </summary>
            SC_TASKLIST = 0xF130,
            /// <summary>
            /// Scrolls vertically.
            /// </summary>
            SC_VSCROLL = 0xF070
        }

        public enum NCHitTest : int
        {
            /// <summary>
            /// On the screen background or on a dividing line between windows (same as <see cref="HTNOWHERE"/>, except that the DefWindowProc function produces a system beep to indicate an error).
            /// </summary>
            HTERROR = -2,
            /// <summary>
            /// In a window currently covered by another window in the same thread (the message will be sent to underlying windows in the same thread until one of them returns a code that is not <see cref="HTTRANSPARENT"/>).
            /// </summary>
            HTTRANSPARENT,
            /// <summary>
            /// On the screen background or on a dividing line between windows.
            /// </summary>
            HTNOWHERE,
            /// <summary>
            /// In a client area.
            /// </summary>
            HTCLIENT,
            /// <summary>
            /// In a title bar.
            /// </summary>
            HTCAPTION,
            /// <summary>
            /// In a window menu or in a Close button in a child window.
            /// </summary>
            HTSYSMENU,
            /// <summary>
            /// In a size box (same as <see cref="HTSIZE"/>).
            /// </summary>
            HTGROWBOX,
            /// <summary>
            /// In a size box (same as <see cref="HTGROWBOX"/>).
            /// </summary>
            HTSIZE = 4,
            /// <summary>
            /// In a menu.
            /// </summary>
            HTMENU,
            /// <summary>
            /// In a horizontal scroll bar.
            /// </summary>
            HTHSCROLL,
            /// <summary>
            /// In the vertical scroll bar.
            /// </summary>
            HTVSCROLL,
            /// <summary>
            /// In a Minimize button.
            /// </summary>
            HTMINBUTTON,
            /// <summary>
            /// In a Minimize button.
            /// </summary>
            HTREDUCE = 8,
            /// <summary>
            /// In a Maximize button.
            /// </summary>
            HTMAXBUTTON,
            /// <summary>
            /// In a Maximize button.
            /// </summary>
            HTZOOM = 9,
            /// <summary>
            /// In the left border of a resizable window (the user can click the mouse to resize the window horizontally).
            /// </summary>
            HTLEFT,
            /// <summary>
            /// In the right border of a resizable window (the user can click the mouse to resize the window horizontally).
            /// </summary>
            HTRIGHT,
            /// <summary>
            /// In the upper-horizontal border of a window.
            /// </summary>
            HTTOP,
            /// <summary>
            /// In the upper-left corner of a window border.
            /// </summary>
            HTTOPLEFT,
            /// <summary>
            /// In the upper-right corner of a window border.
            /// </summary>
            HTTOPRIGHT,
            /// <summary>
            /// In the lower-horizontal border of a resizable window (the user can click the mouse to resize the window vertically).
            /// </summary>
            HTBOTTOM,
            /// <summary>
            /// In the lower-left corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).
            /// </summary>
            HTBOTTOMLEFT,
            /// <summary>
            /// In the lower-right corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).
            /// </summary>
            HTBOTTOMRIGHT,
            /// <summary>
            /// In the border of a window that does not have a sizing border.
            /// </summary>
            HTBORDER,
            HTOBJECT,
            /// <summary>
            /// In a Close button.
            /// </summary>
            HTCLOSE,
            /// <summary>
            /// In a Help button.
            /// </summary>
            HTHELP
        }

        public enum SpecialButton
        {
            None,
            Close,
            Minimize,
            MaximizeRestore,
            Help
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public RECT(Rectangle rc)
        {
            Left = rc.Left;
            Top = rc.Top;
            Right = rc.Right;
            Bottom = rc.Bottom;
        }

        public Rectangle ToRectangle()
        {
            return Rectangle.FromLTRB(Left, Top, Right, Bottom);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MARGINS
    {
        public int leftWidth;
        public int rightWidth;
        public int topHeight;
        public int bottomHeight;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NCCALCSIZE_PARAMS
    {
        public RECT rgrc0, rgrc1, rgrc2;
        public WINDOWPOS lppos;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
        public IntPtr hWnd, hWndInsertAfter;
        public int x, y, cx, cy, flags;
    }
}
