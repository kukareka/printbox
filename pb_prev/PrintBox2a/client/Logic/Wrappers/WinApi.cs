using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PrintBox.Logic.Wrappers
{
    class WinApi
    {
        #region Constants
        public const int DM_DUPLEX = 0x1000;
        public const int DM_IN_BUFFER = 8;
        public const int DM_OUT_BUFFER = 2;
        public const int PRINTER_ACCESS_ADMINISTER = 0x4;
        public const int PRINTER_ACCESS_USE = 0x8;
        public const int STANDARD_RIGHTS_REQUIRED = 0xF0000;
        public const int PRINTER_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | PRINTER_ACCESS_ADMINISTER | PRINTER_ACCESS_USE);

        public const uint SB_VERT = 1;
        public const uint ESB_DISABLE_BOTH = 0x3;
        public const uint ESB_ENABLE_BOTH = 0x0;
        public const int WM_VSCROLL = 0x115;
        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;
        private static IntPtr HWND_TOP = IntPtr.Zero;
        private const int SWP_SHOWWINDOW = 64; // 0×0040

        public static uint SWP_DRAWFRAME = 0x20;
        public static uint SWP_NOMOVE = 0x2;
        public static uint SWP_NOSIZE = 0x1;
        public static uint SWP_NOZORDER = 0x4;

        public const int MF_BYPOSITION = 0x400;
        public const int MF_REMOVE = 0x1000;
        public const int SW_HIDE = 0x0;
        public const int SW_SHOW = 0x5;

        public static int WM_LBUTTONDOWN = 0x0201;
        public static int WM_DEVICECHANGE = 0x0219;
        public const int DBT_DEVICEARRIVAL = 0x8000;
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;

        public const uint DBT_DEVTYP_VOLUME = 0x00000002;
        public const int DBT_DEVTYP_DEVICEINTERFACE = 5;
        public const int DBTF_MEDIA = 0x0001;
        public const int WM_SETREDRAW = 11;
        public const int GWL_EXSTYLE = (-20);
        public const UInt32 WS_EX_TOPMOST = 0x0008;

        public const int DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 4;
        public const int DEVICE_NOTIFY_WINDOW_HANDLE = 0;

        [StructLayout(LayoutKind.Sequential)]
        public struct DEV_BROADCAST_HDR
        {
            public uint dbch_size;
            public uint dbch_devicetype;
            public uint dbch_reserved;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct DEV_BROADCAST_DEVICEINTERFACE
        {
            public int dbcc_size;
            public int dbcc_devicetype;
            public int dbcc_reserved;
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 16)]
            public byte[] dbcc_classguid;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public char[] dbcc_name;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DEV_BROADCAST_VOLUME
        {
            public uint dbcv_size;
            public uint dbch_devicetype;
            public uint dbcv_reserved;
            public uint dbcv_unitmask;
            public ushort dbcv_flags;
        }



        [StructLayout(LayoutKind.Sequential)]
        public struct PRINTER_DEFAULTS
        {
            public int pDatatype;
            public int pDevMode;
            public int DesiredAccess;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PRINTER_INFO_2
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pServerName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPrinterName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pShareName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPortName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDriverName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pComment;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pLocation;
            public IntPtr pDevMode;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pSepFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPrintProcessor;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDatatype;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pParameters;
            public IntPtr pSecurityDescriptor;
            public Int32 Attributes;
            public Int32 Priority;
            public Int32 DefaultPriority;
            public Int32 StartTime;
            public Int32 UntilTime;
            public Int32 Status;
            public Int32 cJobs;
            public Int32 AveragePPM;
        }
        private const short CCDEVICENAME = 32;
        private const short CCFORMNAME = 32;
        [StructLayout(LayoutKind.Sequential)]
        public struct DEVMODE
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCDEVICENAME)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public short dmOrientation;
            public short dmPaperSize;
            public short dmPaperLength;
            public short dmPaperWidth;
            public short dmScale;
            public short dmCopies;
            public short dmDefaultSource;
            public short dmPrintQuality;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCFORMNAME)]
            public string dmFormName;
            public short dmUnusedPadding;
            public short dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
        }
        #endregion

        #region Properties

        public static int ScreenX
        {
            get { return GetSystemMetrics(SM_CXSCREEN); }
        }

        public static int ScreenY
        {
            get { return GetSystemMetrics(SM_CYSCREEN); }
        }
        #endregion

        #region Headers

        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int which);

        [DllImport("user32.dll")]
        public static extern int WindowFromPoint(Point point);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(ref Point point);

        [DllImport("user32.dll")]
        public static extern void
            SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter,
                         int X, int Y, int width, int height, uint flags);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(
            int hWnd,               // handle to window
            int hWndInsertAfter,    // placement-order handle
            int X,                  // horizontal position
            int Y,                  // vertical position
            int cx,                 // width
            int cy,                 // height
            uint uFlags             // window-positioning options
            );

        public static void SetWinFullScreen(IntPtr hwnd)
        {
            SetWindowPos(hwnd, HWND_TOP, 0, 0, ScreenX, ScreenY, SWP_SHOWWINDOW);
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public static bool IsWindowTopMost(IntPtr Handle)
        {
            return (GetWindowLong(Handle, GWL_EXSTYLE) & WS_EX_TOPMOST) != 0;
        }

        [DllImport("user32.dll")]
        public static extern int FindWindow(string strclassName, string strWindowName);

        [DllImport("user32.dll")]
        public static extern int SetParent(int hWndChild, int hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern bool ShowWindow(int hWnd, int nCmdShow);

        [DllImport("user32.dll", EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(
            int hWnd,
            int X,
            int Y,
            int nWidth,
            int nHeight,
            bool bRepaint
            );

        [DllImport("user32.dll", EntryPoint = "DrawMenuBar")]
        public static extern Int32 DrawMenuBar(
            Int32 hWnd
            );

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, UIntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "EnableScrollBar")]
        public static extern bool EnableScrollBar(System.IntPtr hWnd, uint wSBflags, uint wArrows);

        [DllImport("user32.dll")]
        public static extern bool ShowScrollBar(System.IntPtr hWnd, int wBar, bool bShow);

        [DllImport("user32.dll", EntryPoint = "GetMenuItemCount")]
        public static extern Int32 GetMenuItemCount(
            Int32 hMenu
            );

        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        public static extern Int32 GetSystemMenu(
            Int32 hWnd,
            bool bRevert
            );

        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        public static extern Int32 RemoveMenu(
            Int32 hMenu,
            Int32 nPosition,
            Int32 wFlags
            );

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint RegisterWindowMessage(string lpString);

        [DllImport("kernel32.dll", EntryPoint = "GetLastError", SetLastError = false,
        ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern Int32 GetLastError();

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true,
        ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        //[DllImport("winspool.drv", EntryPoint = "ClosePrinter")]
        //public static extern int ClosePrinter(int hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "DocumentPropertiesA", SetLastError = true,
        ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int DocumentProperties(IntPtr hwnd, IntPtr hPrinter,
        [MarshalAs(UnmanagedType.LPStr)] string pDeviceNameg,
        IntPtr pDevModeOutput, ref IntPtr pDevModeInput, int fMode);

        [DllImport("winspool.Drv", EntryPoint = "GetPrinterA", SetLastError = true,
            CharSet = CharSet.Ansi, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetPrinter(IntPtr hPrinter, Int32 dwLevel, IntPtr pPrinter, Int32 dwBuf, out Int32 dwNeeded);

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA",
            SetLastError = true, CharSet = CharSet.Ansi,
            ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool
            OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter,
            out IntPtr hPrinter, ref PRINTER_DEFAULTS pd);
        [DllImport("winspool.drv", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern bool SetPrinter(IntPtr hPrinter, int Level, IntPtr
        pPrinter, int Command);

        //[DllImport("winspool.drv", EntryPoint = "OpenPrinter")]
        //public static extern int OpenPrinterA(string pPrinterName, ref int phPrinter, ref PRINTER_DEFAULTS pDefault);

        [DllImport("winspool.drv", EntryPoint = "SetJob")]
        public static extern int SetJobA(int hPrinter, int JobId, int Level, ref byte pJob, int Command_Renamed);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetLongPathName([MarshalAs(UnmanagedType.LPTStr)]string path, [MarshalAs(UnmanagedType.LPTStr)]StringBuilder longPath, int longPathLength);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName([MarshalAs(UnmanagedType.LPTStr)]string path, [MarshalAs(UnmanagedType.LPTStr)]StringBuilder shortPath, int shortPathLength);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        public static extern IntPtr GlobalFree(IntPtr handle);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        public static extern IntPtr GlobalLock(IntPtr handle);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        public static extern IntPtr GlobalUnlock(IntPtr handle);

        [System.Runtime.InteropServices.DllImport("urlmon.dll", EntryPoint = "FindMimeFromData", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private static extern int FindMimeFromData(IntPtr pBC, [MarshalAs(UnmanagedType.LPWStr)] string pwzUrl, [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer, int cbSize, [MarshalAs(UnmanagedType.LPWStr)] string pwzMimeProposed, int dwMimeFlags, [MarshalAs(UnmanagedType.LPWStr)] ref string ppwzMimeOut, int dwReserved);

        public static SupportedFileTypes GetFileType(string file)
        {
            SupportedFileTypes fileType = SupportedFileTypes.UNSUPPORTED;
            string mimeout = "";
            int MaxContent = 0;
            FileStream fs = null;
            byte[] buf = null;
            int result = 0;

            MaxContent = System.Convert.ToInt32(new FileInfo(file).Length);
            if (MaxContent > 4096)
            {
                MaxContent = 4096;
            }
            fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            buf = new byte[MaxContent + 1];
            fs.Read(buf, 0, MaxContent);
            fs.Close();

            result = FindMimeFromData(IntPtr.Zero, file, buf, MaxContent, null, 0, ref mimeout, 0);
            switch (mimeout)
            {
                case "application/msword":
                    fileType = SupportedFileTypes.DOC;
                    break;
                case "application/x-zip-compressed":
                    fileType = SupportedFileTypes.DOCX;
                    break;
                default:
                    break;
            }

            return fileType;
        }

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, (uint)WM_SETREDRAW, (System.UIntPtr)0, (System.IntPtr)0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, (uint)WM_SETREDRAW, (System.UIntPtr)1, (System.IntPtr)0);
            parent.Refresh();
        }

        #endregion

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr RegisterDeviceNotification(IntPtr IntPtr, IntPtr NotificationFilter, Int32 Flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern uint UnregisterDeviceNotification(IntPtr hHandle);

    }

    public enum SupportedFileTypes
    {
        DOC,
        DOCX,
        UNSUPPORTED
    }
}
