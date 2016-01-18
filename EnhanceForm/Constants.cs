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
        public const int CS_DROPSHADOW = 0x20000;

        public const int WM_NULL = 0x0000;
        public const int WM_CREATE = 0x0001;
        public const int WM_ACTIVATE = 0x0006;
        public const int WM_PAINT = 0x000F;
        public const int WM_WINDOWPOSCHANGED = 0x0047;
        public const int WM_NCCALCSIZE = 0x0083;
        public const int WM_NCHITTEST = 0x84;
        public const int WM_NCPAINT = 0x0085;
        public const int WM_NCACTIVATE = 0x0086;
        public const int WM_NCMOUSEMOVE = 0xA0;
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        public const int WM_SYSCOMMAND = 0x0112;

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

        public const int SC_MOVE = 0xF010;

        public enum NCHitTest
        {
            HTCAPTION = 2,
            HTCLOSE = 20
        }

        public enum SpecialButton
        {
            None,
            Close,
            Minimize,
            Maximize,
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
